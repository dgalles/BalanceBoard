using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiimoteLib;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace WindowsFormsApplication1
{
    public partial class BalanceTestMain : Form
    {
        System.Timers.Timer infoUpdateTimer = new System.Timers.Timer() { Interval = 10, Enabled = false };
        public Wiimote wiiDevice = new Wiimote();
        RunningTestForm testForm;
        public BalanceTestMain()
        {
            InitializeComponent();
            infoUpdateTimer.Elapsed += new ElapsedEventHandler(infoUpdateTimer_Elapsed);
             testForm = new RunningTestForm(this, wiiDevice);
            testForm.Hide();
            
        }

        public Boolean xInverted { get { return InvertX.Checked; } }
        public Boolean yInverted { get { return InvertY.Checked; } }

        void infoUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Pass event onto the form GUI thread.

            this.BeginInvoke(new Action(() => InfoUpdate()));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StatusDat_Click(object sender, EventArgs e)
        {

        }



        private bool connect()
        {
            try
            {
                // Find all connected Wii devices.

                StatusDat.Text = "Looking for Balance Board";
                StatusDat.Refresh();
                StatusContainer.Update();


                var deviceCollection = new WiimoteCollection();
                deviceCollection.FindAllWiimotes();

                for (int i = 0; i < deviceCollection.Count; i++)
                {
                    wiiDevice = deviceCollection[i];

                    // Device type can only be found after connection, so prompt for multiple devices.

                    if (deviceCollection.Count > 1)
                    {
                        var devicePathId = new Regex("e_pid&.*?&(.*?)&").Match(wiiDevice.HIDDevicePath).Groups[1].Value.ToUpper();

                        //var response = MessageBox.Show("Connect to HID " + devicePathId + " device " + (i + 1) + " of " + deviceCollection.Count + " ?", "Multiple Wii Devices Found", MessageBoxButtons.YesNoCancel);
                        //if (response == DialogResult.Cancel) return;
                        //if (response == DialogResult.No) continue;
                    }

                    // Setup update handlers.

                    //   wiiDevice.WiimoteChanged += wiiDevice_WiimoteChanged;
                    //  wiiDevice.WiimoteExtensionChanged += wiiDevice_WiimoteExtensionChanged;

                    // Connect and send a request to verify it worked.

                    StatusDat.Text = "Found Device, connecting ...";
                    StatusDat.Refresh();
                    StatusContainer.Update();


                    wiiDevice.Connect();
                    wiiDevice.SetReportType(InputReport.IRAccel, false); //ALSE = DEVICE ONLY SENDS UPDATES WHEN VALUES CHANGE!
                    wiiDevice.SetLEDs(true, false, false, false);


                    // Enable processing of updates.

                    infoUpdateTimer.Enabled = true;

                    // Prevent connect being pressed more than once.

                    //   button_Connect.Enabled = false;
                    //   button_BluetoothAddDevice.Enabled = false;
                    break;
                }
            }
            catch (Exception ex)
            {
                StatusDat.Text = ex.Message;
                StatusDat.Refresh();
                StatusContainer.Update();

                return false;
               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Connect.Enabled = false;
            Start30.Enabled = true;
            Start60.Enabled = true;
            Disconnect.Enabled = true;
            return true;
        }

        private bool blueToothConnect()
        {
            bool success = false;
            try
            {
                using (var btClient = new BluetoothClient())
                {
                    // PROBLEM:
                    // false false true: finds only unknown devices, which excludes existing but broken device entries.
                    // false true  true: finds broken entries, but even if powered off, so pairing attempts then crash.
                    // WORK-AROUND:
                    // Remove existing entries first, then find powered on entries.

                    var btIgnored = 0;

                    // Find remembered bluetooth devices.

                    //label_Status.Text = "Removing existing bluetooth devices...";
                    //label_Status.Refresh();

                    // Remove existing connections
                        var btExistingList = btClient.DiscoverDevices(255, false, true, false);

                        foreach (var btItem in btExistingList)
                        {
                            if (!btItem.DeviceName.Contains("Nintendo")) continue;

                            BluetoothSecurity.RemoveDevice(btItem.DeviceAddress);
                            btItem.SetServiceState(BluetoothService.HumanInterfaceDevice, false);
                        }

                    // Find unknown bluetooth devices.

                        StatusDat.Text = "Press the SYNC button (inside battery case of Balance Board)";
                        StatusDat.Refresh();

                    var btDiscoveredList = btClient.DiscoverDevices(255, false, false, true);

                    foreach (var btItem in btDiscoveredList)
                    {
                        // Just in-case any non Wii devices are waiting to be paired.

                        if ( !btItem.DeviceName.Contains("Nintendo"))
                        {
                            btIgnored += 1;
                            continue;
                        }

                        StatusDat.Text = "Adding: " + btItem.DeviceName + " ( " + btItem.DeviceAddress + " )";
                        StatusDat.Refresh();
                        StatusContainer.Update();

                        // Send special pin for permanent sync.


                        // Install as a HID device and allow some time for it to finish.

                        success = true;
                        btItem.SetServiceState(BluetoothService.HumanInterfaceDevice, true);
                    }

                    // Allow slow computers to finish installation before connecting.

                    if (success)
                    {
                        System.Threading.Thread.Sleep(4000);
                    }
                    // Connect and send a command, otherwise they sleep and the device disappears.

                    //try
                    //{
                    //    if (btDiscoveredList.Length > btIgnored)
                    //    {
                    //        var deviceCollection = new WiimoteCollection();
                    //        deviceCollection.FindAllWiimotes();

                    //        foreach (var wiiDevice in deviceCollection)
                    //        {
                    //            wiiDevice.Connect();
                    //            wiiDevice.SetLEDs(true, false, false, false);
                    //            wiiDevice.Disconnect();
                    //        }
                    //    }
                    //}
                    //catch (Exception) { }

                    // Status report.

                    //label_Status.Text = "Finished - You can now close this window. Found: " + btDiscoveredList.Length + " Ignored: " + btIgnored;
                    //label_Status.Refresh();
                }
            }
            catch (Exception ex)
            {
                //label_Status.Text = "Error: " + ex.Message;
            }
            return success;

        }
        private void Connect_Click(object sender, EventArgs e)
        {
            if (!connect())
            {
                if (blueToothConnect())
                {
                    if (connect())
                    {
                        StatusDat.Text = "Connected";
                        StatusDat.Update();
                        StatusContainer.Update();

                    }
                    else
                    {
                        StatusDat.Text = "Connection Problem.  Paired with bluetooth but did not connect.  Try again.";
                        StatusDat.Update();
                        StatusContainer.Update();

                    }
                }
                else
                {
                    StatusDat.Text = "Bluetooth pairing timed out.   Try to connect again, and be sure to press the sync button on Balance Board";
                    StatusDat.Update();
                    StatusContainer.Update();

                }
            }
            else
            {
                StatusDat.Text = "Connected";
                StatusDat.Update();
                StatusContainer.Update();

            }
        }

        private void InfoUpdate()
        {
            // Get the current raw sensor KG values.

            var rwWeight = wiiDevice.WiimoteState.BalanceBoardState.WeightKg;

            var rwTopLeft = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.TopLeft;
            var rwTopRight = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.TopRight;
            var rwBottomLeft = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.BottomLeft;
            var rwBottomRight = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.BottomRight;

            float pointX = wiiDevice.WiimoteState.BalanceBoardState.CenterOfGravity.X;
            float pointY = wiiDevice.WiimoteState.BalanceBoardState.CenterOfGravity.Y;

           // label_rwWT.Text = rwWeight.ToString("0.0");
            LeftTopVal.Text = rwTopLeft.ToString("0.0");
            RightTopDat.Text = rwTopRight.ToString("0.0");
            LeftBottomDat.Text = rwBottomLeft.ToString("0.0");
            RightBottomDat.Text = rwBottomRight.ToString("0.0");
            WeightDat.Text = rwWeight.ToString("0.0");

            CenterGravityX.Text = pointX.ToString("0.0");
            CenterGravityY.Text = pointY.ToString("0.0");

            Bitmap bufl = new Bitmap(DrawingPanel.Width, DrawingPanel.Height);
            using (Graphics g = Graphics.FromImage(bufl))
            using (System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Black))
            using (System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red))

            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, DrawingPanel.Width, DrawingPanel.Height));

                g.DrawLine(blackPen, 0, DrawingPanel.Height / 2, DrawingPanel.Width, DrawingPanel.Height/2);
                g.DrawLine(blackPen, DrawingPanel.Width/2, 0,  DrawingPanel.Width/2, DrawingPanel.Height);



                int Xpos = DrawingPanel.Width / 2 + (int) (pointX * 10);
                if (InvertX.Checked)
                {
                    Xpos = DrawingPanel.Width - Xpos;
                }
                int Ypos = DrawingPanel.Height / 2 + (int)(pointY * 10);
                if (InvertY.Checked)
                {
                    Ypos = DrawingPanel.Height - Ypos;
                }
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(Xpos - 1, Ypos -1,2, 2);
                g.DrawRectangle(System.Drawing.Pens.Red, rectangle);

                g.DrawLine(redPen, Xpos - 5, Ypos, Xpos + 5, Ypos);
                g.DrawLine(redPen, Xpos, Ypos - 5, Xpos, Ypos + 5);


                DrawingPanel.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Start30_Click(object sender, EventArgs e)
        {
            this.Hide();
            testForm.Show();
            testForm.start30(AutoStart.Checked, Countdown.Checked, (int) CountdownValue.Value);
        }

        private void Start60_Click(object sender, EventArgs e)
        {
            this.Hide();
            testForm.Show();
            testForm.start60(AutoStart.Checked, Countdown.Checked, (int) CountdownValue.Value);
        }

        private void BalanceTestMain_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void InvertY_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Disconnect_Click(object sender, EventArgs e)
        {

            wiiDevice.Disconnect();
            Connect.Enabled = true;
            Start30.Enabled = false;
            Start60.Enabled = false;
            Disconnect.Enabled = false;

            StatusDat.Text = "Not Connected";
            StatusDat.Refresh();
            StatusContainer.Update();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CursorSize_ValueChanged(object sender, EventArgs e)
        {
            testForm.setCursorSize((int) CursorSize.Value);
        }
    }
}
