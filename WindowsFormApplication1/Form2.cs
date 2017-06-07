using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using WiimoteLib;
using System.Windows.Media.Imaging;


namespace WindowsFormsApplication1
{

    public struct BalanceData
    {


    }

    public partial class RunningTestForm : Form
    {
        BalanceTestMain parent;
        System.Timers.Timer infoUpdateTimer = new System.Timers.Timer() { Interval = 10, Enabled = false };
        DateTime currentTime = new DateTime(0);
        TimeSpan remainingTime;
        Boolean waitingToStart;
        TimeSpan testTime;
        List<BalanceBoardState> data = new List<BalanceBoardState>();
        Boolean started;
        bool saved;
        bool testComplete;
        float currentBalanceBoardX = 0;
        float currentBalanceBoardY = 0;
        int cursorSize = 3;

        public RunningTestForm(BalanceTestMain parent, Wiimote wiiDevice)
        {
            InitializeComponent();
            infoUpdateTimer.Elapsed += new ElapsedEventHandler(infoUpdateTimer_Elapsed);
          //  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.parent = parent;
        }

        public void setCursorSize(int size)
        {
            this.cursorSize = size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (testComplete)
            {
                showComplete(trackBar1.Value);
            }
            else
            {
                showCurrentPosition();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            parent.Show();
            e.Cancel = true;
            infoUpdateTimer.Enabled = false;

        }
        void infoUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Pass event onto the form GUI thread.

            this.BeginInvoke(new Action(() => Update(e)));
           // Update(e);
            
        }



        private void setupStart(bool autoStart, int timer)
        {
            testComplete = false;
            remainingTime = new TimeSpan(0, 0, timer);
            currentTime = new DateTime(0);
            waitingToStart = true;
            Save.Enabled = false;
            data.Clear();
            infoUpdateTimer.Enabled = true;
            Timer.Text = "Ready to start";
            saved = false;
            Done.Enabled = false;
            if (autoStart)
            {
                started = true;
                startButton.Enabled = false;
            }
            else
            {
                started = false;
                startButton.Enabled = true;
            }
           
 
        }

        public void start30(bool autoStart, bool countdown, int timer)
        {
            if (!countdown)
            {
                timer = 0;
            }
            testTime = new TimeSpan(0, 0, 30);
            setupStart(autoStart, timer);
        }

        public void start60(bool autoStart, bool countdown, int timer)
        {
            if (!countdown)
            {
                timer = 0;
            }
            testTime = new TimeSpan(0, 0, 60);
            setupStart(autoStart, timer);
        }

        private void Update(ElapsedEventArgs e)
        {
            if (testComplete)
            {
                Invalidate();
                return;
            }
            BalanceBoardState b = parent.wiiDevice.WiimoteState.BalanceBoardState;
           
            currentBalanceBoardX = b.CenterOfGravity.X;
            currentBalanceBoardY = b.CenterOfGravity.Y;
           // showCurrentPosition();

            if (!started)
            {
                Invalidate();
                return;
            } 
            if (currentTime == new DateTime(0))
            {
                currentTime = e.SignalTime;
            }
            else
            {
                remainingTime -= e.SignalTime - currentTime;
                currentTime = e.SignalTime;
                int secondsLeft = remainingTime.Seconds;
                if (remainingTime.Milliseconds > 0)
                {
                    secondsLeft += 1;
                }

                if (waitingToStart)
                {
                    Timer.Text = "Starting in " + secondsLeft + " Seconds";
                    if (remainingTime <= new TimeSpan(0))
                    {
                        waitingToStart = false;
                        remainingTime = testTime;
                    }
                    Timer.Invalidate();

                }
                else
                {
                    Timer.Text = "Test Started.  Time Remaining: " + secondsLeft + " Seconds";
                    Timer.Invalidate();

                    if (remainingTime <= new TimeSpan(0))
                    {
                        Timer.Text = "Test Complete";
                        waitingToStart = false;
                        remainingTime = testTime;
                        infoUpdateTimer.Enabled = false;
                        Save.Enabled = true;
                        Done.Enabled = true;
                        testComplete = true;
                        trackBar1.SetRange(0, data.Count);
                        trackBar1.Value = data.Count;
                    }
                    else
                    {
                        collectDataPoint();
                    }
                }
               
            }
            this.Invalidate();

            
        }


        private Bitmap getOutpanelBitmap(int lastPoint, String name)
        {
            int width = OutputPanel.Width;
            int height = OutputPanel.Height;

            int smallest = Math.Min(width, height) - 1;

            // BalanceBoardState b = data.Last();
            //  var b = parent.wiiDevice.WiimoteState.BalanceBoardState;
            bool changeColor = lastPoint < data.Count;
            Bitmap bufl = new Bitmap(width, height);
            int x = 10;

            Graphics g = Graphics.FromImage(bufl);
            System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Black); 

                g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));


                System.Drawing.Rectangle drawingRegion = new System.Drawing.Rectangle((width - smallest) / 2, (height - smallest) / 2, smallest, smallest);

                g.DrawEllipse(System.Drawing.Pens.Black, drawingRegion);

                g.DrawLine(blackPen, (width - smallest) / 2, height / 2, width - (width - smallest) / 2, height / 2);
                g.DrawLine(blackPen, width / 2, (height - smallest) / 2, width / 2, height - (height - smallest) / 2);


                int lastXPos = -1;
                int lastYPos = -1;

                for (int i = 0; i < lastPoint; i++)
                {
                    BalanceBoardState b = data[i];
                    int Xpos = width / 2 + (int)((float)b.CenterOfGravity.X / 20.0 * smallest);
                    int Ypos = height / 2 + (int)((float)b.CenterOfGravity.Y / 20.0 * smallest);

                    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(Xpos - 1, Ypos - 1, 2, 2);
                    if (changeColor)
                    {
                        int red = (int)((float)i * 255 / (float)lastPoint);
                        int blue = 255 - (int)((float)i * 255 / (float)lastPoint);
                        redPen.Color = Color.FromArgb(red, 0, blue);

                    }

                    g.DrawRectangle(redPen, rectangle);
                    if ((lastXPos >= 0) && (lastYPos >= 0))
                    {
                        g.DrawLine(redPen, lastXPos, lastYPos, Xpos, Ypos);
                    }
                    lastXPos = Xpos;
                    lastYPos = Ypos;
                }


            x = 11;

            return bufl;

        }

        private void showComplete(int lastPoint)
        {
            OutputPanel.CreateGraphics().DrawImageUnscaled(getOutpanelBitmap(lastPoint, ""), 0, 0);

            return;

          

        }


        private void showCurrentPosition()
        {
            int width = OutputPanel.Width;
            int height = OutputPanel.Height;

            int smallest = Math.Min(width, height) - 1;

            using (Bitmap bufl = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(bufl))
            using (System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Black))
            using (System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0,0, width, height));


                System.Drawing.Rectangle drawingRegion = new System.Drawing.Rectangle((width - smallest) / 2, (height - smallest) / 2, smallest, smallest); 

                g.DrawEllipse(System.Drawing.Pens.Black, drawingRegion);

                g.DrawLine(blackPen, (width - smallest) / 2, height / 2, width - (width - smallest) / 2, height / 2);
                g.DrawLine(blackPen, width/2, (height - smallest) / 2, width/2, height - (height - smallest) / 2);


                int Xpos = width / 2 + (int)((float)currentBalanceBoardX / 20.0 * smallest);
                int Ypos = height / 2 + (int)((float)currentBalanceBoardY / 20.0 * smallest);

                if (parent.xInverted)
                {
                    Xpos = width - Xpos;
                }
                if (parent.yInverted)
                {
                    Ypos = height - Ypos;
                }

                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(Xpos -  cursorSize, Ypos - cursorSize, 2 * cursorSize, 2 * cursorSize);

                g.FillRectangle(Brushes.Red, rectangle);
                g.DrawLine(redPen, Xpos-5*cursorSize, Ypos, Xpos+5*cursorSize, Ypos);
                g.DrawLine(redPen, Xpos, Ypos - 5 * cursorSize, Xpos, Ypos + 5*cursorSize);
                
                OutputPanel.CreateGraphics().DrawImage(bufl, 0, 0);
               

            }



           // throw new NotImplementedException();
        }

        private void collectDataPoint()
        {
            data.Add(parent.wiiDevice.WiimoteState.BalanceBoardState);



            //// label_rwWT.Text = rwWeight.ToString("0.0");
            //LeftTopVal.Text = rwTopLeft.ToString("0.0");
            //RightTopDat.Text = rwTopRight.ToString("0.0");
            //LeftBottomDat.Text = rwBottomLeft.ToString("0.0");
            //RightBottomDat.Text = rwBottomRight.ToString("0.0");
            //WeightDat.Text = rwWeight.ToString("0.0");

            //CenterGravityX.Text = pointX.ToString("0.0");
            //CenterGravityY.Text = pointY.ToString("0.0");

           // throw new NotImplementedException();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.ValidateNames = true;
            DateTime currentTime = DateTime.Now;
            saveFileDialog1.FileName = "BalanceData_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            saveFileDialog1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            started = true;
            startButton.Enabled = false;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            string name = saveFileDialog1.FileName;
            // Write to the file name selected.
            // ... You can write the text from a TextBox instead of a string literal.
            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(name))
            {

                file.WriteLine("TopLeft,TopRight,BottomLeft,BottomRight,CenterOfGravityX,CenterOfGravityY");
                foreach (BalanceBoardState b in data)
                {
                    file.WriteLine(b.SensorValuesKg.TopLeft + "," + b.SensorValuesKg.TopRight + "," + b.SensorValuesKg.BottomLeft + "," + b.SensorValuesKg.BottomRight + "," + b.CenterOfGravity.X + "," + b.CenterOfGravity.Y);
                }
                file.Close();
            }



               // BitmapEncoder encoder = new PngBitmapEncoder();

            int index = name.LastIndexOf(".csv");
            String newName = name;
            if (index > 0)
            {
                newName = name.Substring(0, index);
            }
            String DisplayName = newName;
            index = DisplayName.LastIndexOf("/");
            if (index >= 0)
            {
                DisplayName = DisplayName.Substring(index + 1);
            }
            index = DisplayName.LastIndexOf("\\");
            if (index >= 0)
            {
                DisplayName = DisplayName.Substring(index + 1);
            }

                Bitmap bufl = getOutpanelBitmap(data.Count, name);

                Graphics g = Graphics.FromImage(bufl);

                Font drawFont = new Font("Arial", 16);
                 SolidBrush drawBrush = new SolidBrush(Color.Black);

                 g.DrawString(DisplayName, drawFont, drawBrush, 0, 0);



                bufl.Save(newName + ".png");

            saved = true;

        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult res = MessageBox.Show("Exit without saving?", "Data not yet saved", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    this.Hide();
                    parent.Show();
                }

            }
            else
            {
                this.Hide();
                parent.Show();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void OutputPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
