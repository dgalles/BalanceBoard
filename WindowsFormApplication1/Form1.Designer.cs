namespace WindowsFormsApplication1
{
    partial class BalanceTestMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LeftTopVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LeftBottomDat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RightBottomDat = new System.Windows.Forms.Label();
            this.RightTopDat = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.StatusDat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WeightDat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CenterGravityX = new System.Windows.Forms.Label();
            this.CenterGravityY = new System.Windows.Forms.Label();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.Start30 = new System.Windows.Forms.Button();
            this.Start60 = new System.Windows.Forms.Button();
            this.InvertX = new System.Windows.Forms.CheckBox();
            this.InvertY = new System.Windows.Forms.CheckBox();
            this.StatusContainer = new System.Windows.Forms.GroupBox();
            this.AutoStart = new System.Windows.Forms.CheckBox();
            this.Disconnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CountdownValue = new System.Windows.Forms.NumericUpDown();
            this.Countdown = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CursorSize = new System.Windows.Forms.NumericUpDown();
            this.StatusContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountdownValue)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CursorSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LeftTop";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LeftTopVal
            // 
            this.LeftTopVal.AutoSize = true;
            this.LeftTopVal.Location = new System.Drawing.Point(61, 25);
            this.LeftTopVal.Name = "LeftTopVal";
            this.LeftTopVal.Size = new System.Drawing.Size(24, 13);
            this.LeftTopVal.TabIndex = 1;
            this.LeftTopVal.Text = "n/a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LeftBottm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // LeftBottomDat
            // 
            this.LeftBottomDat.AutoSize = true;
            this.LeftBottomDat.Location = new System.Drawing.Point(61, 53);
            this.LeftBottomDat.Name = "LeftBottomDat";
            this.LeftBottomDat.Size = new System.Drawing.Size(24, 13);
            this.LeftBottomDat.TabIndex = 3;
            this.LeftBottomDat.Text = "n/a";
            this.LeftBottomDat.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "RightTop";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RightBottomDat
            // 
            this.RightBottomDat.AutoSize = true;
            this.RightBottomDat.Location = new System.Drawing.Point(201, 53);
            this.RightBottomDat.Name = "RightBottomDat";
            this.RightBottomDat.Size = new System.Drawing.Size(24, 13);
            this.RightBottomDat.TabIndex = 5;
            this.RightBottomDat.Text = "n/a";
            // 
            // RightTopDat
            // 
            this.RightTopDat.AutoSize = true;
            this.RightTopDat.Location = new System.Drawing.Point(201, 25);
            this.RightTopDat.Name = "RightTopDat";
            this.RightTopDat.Size = new System.Drawing.Size(24, 13);
            this.RightTopDat.TabIndex = 6;
            this.RightTopDat.Text = "n/a";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "RightBottom";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(21, 28);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(176, 23);
            this.Connect.TabIndex = 8;
            this.Connect.Text = "Connect to Balance Board";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // StatusDat
            // 
            this.StatusDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusDat.AutoSize = true;
            this.StatusDat.Location = new System.Drawing.Point(20, 22);
            this.StatusDat.Name = "StatusDat";
            this.StatusDat.Size = new System.Drawing.Size(79, 13);
            this.StatusDat.TabIndex = 10;
            this.StatusDat.Text = "Not Connected";
            this.StatusDat.Click += new System.EventHandler(this.StatusDat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Weight";
            // 
            // WeightDat
            // 
            this.WeightDat.AutoSize = true;
            this.WeightDat.Location = new System.Drawing.Point(442, 34);
            this.WeightDat.Name = "WeightDat";
            this.WeightDat.Size = new System.Drawing.Size(24, 13);
            this.WeightDat.TabIndex = 12;
            this.WeightDat.Text = "n/a";
            this.WeightDat.Click += new System.EventHandler(this.label6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Center of Gravity X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Center of Gravity Y";
            // 
            // CenterGravityX
            // 
            this.CenterGravityX.AutoSize = true;
            this.CenterGravityX.Location = new System.Drawing.Point(349, 25);
            this.CenterGravityX.Name = "CenterGravityX";
            this.CenterGravityX.Size = new System.Drawing.Size(24, 13);
            this.CenterGravityX.TabIndex = 15;
            this.CenterGravityX.Text = "n/a";
            // 
            // CenterGravityY
            // 
            this.CenterGravityY.AutoSize = true;
            this.CenterGravityY.Location = new System.Drawing.Point(349, 53);
            this.CenterGravityY.Name = "CenterGravityY";
            this.CenterGravityY.Size = new System.Drawing.Size(24, 13);
            this.CenterGravityY.TabIndex = 16;
            this.CenterGravityY.Text = "n/a";
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingPanel.AutoSize = true;
            this.DrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingPanel.Location = new System.Drawing.Point(15, 25);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(252, 221);
            this.DrawingPanel.TabIndex = 17;
            // 
            // Start30
            // 
            this.Start30.Enabled = false;
            this.Start30.Location = new System.Drawing.Point(16, 19);
            this.Start30.Name = "Start30";
            this.Start30.Size = new System.Drawing.Size(152, 23);
            this.Start30.TabIndex = 18;
            this.Start30.Text = "Start 30 Second Trial";
            this.Start30.UseVisualStyleBackColor = true;
            this.Start30.Click += new System.EventHandler(this.Start30_Click);
            // 
            // Start60
            // 
            this.Start60.Enabled = false;
            this.Start60.Location = new System.Drawing.Point(16, 58);
            this.Start60.Name = "Start60";
            this.Start60.Size = new System.Drawing.Size(152, 23);
            this.Start60.TabIndex = 19;
            this.Start60.Text = "Start 60 Second Trial";
            this.Start60.UseVisualStyleBackColor = true;
            this.Start60.Click += new System.EventHandler(this.Start60_Click);
            // 
            // InvertX
            // 
            this.InvertX.AutoSize = true;
            this.InvertX.Location = new System.Drawing.Point(56, 252);
            this.InvertX.Name = "InvertX";
            this.InvertX.Size = new System.Drawing.Size(63, 17);
            this.InvertX.TabIndex = 20;
            this.InvertX.Text = "Invert X";
            this.InvertX.UseVisualStyleBackColor = true;
            this.InvertX.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // InvertY
            // 
            this.InvertY.AutoSize = true;
            this.InvertY.Location = new System.Drawing.Point(155, 252);
            this.InvertY.Name = "InvertY";
            this.InvertY.Size = new System.Drawing.Size(63, 17);
            this.InvertY.TabIndex = 21;
            this.InvertY.Text = "Invert Y";
            this.InvertY.UseVisualStyleBackColor = true;
            this.InvertY.CheckedChanged += new System.EventHandler(this.InvertY_CheckedChanged);
            // 
            // StatusContainer
            // 
            this.StatusContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusContainer.Controls.Add(this.StatusDat);
            this.StatusContainer.Location = new System.Drawing.Point(12, 303);
            this.StatusContainer.Name = "StatusContainer";
            this.StatusContainer.Size = new System.Drawing.Size(796, 47);
            this.StatusContainer.TabIndex = 22;
            this.StatusContainer.TabStop = false;
            this.StatusContainer.Text = "Status";
            this.StatusContainer.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // AutoStart
            // 
            this.AutoStart.AllowDrop = true;
            this.AutoStart.AutoSize = true;
            this.AutoStart.Location = new System.Drawing.Point(15, 93);
            this.AutoStart.Name = "AutoStart";
            this.AutoStart.Size = new System.Drawing.Size(97, 17);
            this.AutoStart.TabIndex = 23;
            this.AutoStart.Text = "Auto Start Test";
            this.AutoStart.UseVisualStyleBackColor = true;
            // 
            // Disconnect
            // 
            this.Disconnect.Location = new System.Drawing.Point(21, 67);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(176, 23);
            this.Disconnect.TabIndex = 24;
            this.Disconnect.Text = "Disconnect from Balance Board";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LeftTopVal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LeftBottomDat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RightBottomDat);
            this.groupBox1.Controls.Add(this.RightTopDat);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CenterGravityY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CenterGravityX);
            this.groupBox1.Controls.Add(this.WeightDat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 83);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Balance Board Values";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Connect);
            this.groupBox2.Controls.Add(this.Disconnect);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 112);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Balance Board Connection";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CursorSize);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.CountdownValue);
            this.groupBox3.Controls.Add(this.Countdown);
            this.groupBox3.Controls.Add(this.Start30);
            this.groupBox3.Controls.Add(this.Start60);
            this.groupBox3.Controls.Add(this.AutoStart);
            this.groupBox3.Location = new System.Drawing.Point(292, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 187);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Run Tests";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Seconds";
            // 
            // CountdownValue
            // 
            this.CountdownValue.Location = new System.Drawing.Point(35, 134);
            this.CountdownValue.Name = "CountdownValue";
            this.CountdownValue.Size = new System.Drawing.Size(43, 20);
            this.CountdownValue.TabIndex = 25;
            this.CountdownValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.CountdownValue.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Countdown
            // 
            this.Countdown.AutoSize = true;
            this.Countdown.Checked = true;
            this.Countdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Countdown.Location = new System.Drawing.Point(15, 116);
            this.Countdown.Name = "Countdown";
            this.Countdown.Size = new System.Drawing.Size(109, 17);
            this.Countdown.TabIndex = 24;
            this.Countdown.Text = "Contdoown Timer";
            this.Countdown.UseVisualStyleBackColor = true;
            this.Countdown.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DrawingPanel);
            this.groupBox4.Controls.Add(this.InvertY);
            this.groupBox4.Controls.Add(this.InvertX);
            this.groupBox4.Location = new System.Drawing.Point(510, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 275);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Center of Gravity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Cursor Size";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // CursorSize
            // 
            this.CursorSize.Location = new System.Drawing.Point(79, 158);
            this.CursorSize.Name = "CursorSize";
            this.CursorSize.Size = new System.Drawing.Size(54, 20);
            this.CursorSize.TabIndex = 28;
            this.CursorSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.CursorSize.ValueChanged += new System.EventHandler(this.CursorSize_ValueChanged);
            // 
            // BalanceTestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 362);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusContainer);
            this.Name = "BalanceTestMain";
            this.Text = "Balance Test";
            this.Load += new System.EventHandler(this.BalanceTestMain_Load);
            this.StatusContainer.ResumeLayout(false);
            this.StatusContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountdownValue)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CursorSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LeftTopVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LeftBottomDat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label RightBottomDat;
        private System.Windows.Forms.Label RightTopDat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label StatusDat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WeightDat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CenterGravityX;
        private System.Windows.Forms.Label CenterGravityY;
        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.Button Start30;
        private System.Windows.Forms.Button Start60;
        private System.Windows.Forms.CheckBox InvertX;
        private System.Windows.Forms.CheckBox InvertY;
        private System.Windows.Forms.GroupBox StatusContainer;
        private System.Windows.Forms.CheckBox AutoStart;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox Countdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CountdownValue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown CursorSize;
    }
}

