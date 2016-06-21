namespace Snooker_Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbBallList = new System.Windows.Forms.GroupBox();
            this.cbBallList2 = new System.Windows.Forms.ComboBox();
            this.cbBallList1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbAngle = new System.Windows.Forms.Label();
            this.lbSecondBallInfo = new System.Windows.Forms.Label();
            this.lbFirstBallInfo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnShowDirection = new System.Windows.Forms.Button();
            this.btnTakeShot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.gbBallList.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1247, 776);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New game";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 776);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Options";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 55);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbBallList
            // 
            this.gbBallList.Controls.Add(this.cbBallList2);
            this.gbBallList.Controls.Add(this.cbBallList1);
            this.gbBallList.Controls.Add(this.label1);
            this.gbBallList.Location = new System.Drawing.Point(135, 776);
            this.gbBallList.Name = "gbBallList";
            this.gbBallList.Size = new System.Drawing.Size(205, 95);
            this.gbBallList.TabIndex = 2;
            this.gbBallList.TabStop = false;
            this.gbBallList.Text = "Display Options";
            // 
            // cbBallList2
            // 
            this.cbBallList2.FormattingEnabled = true;
            this.cbBallList2.Items.AddRange(new object[] {
            "White",
            "Yellow",
            "Green",
            "Brown",
            "Blue",
            "Pink",
            "Black"});
            this.cbBallList2.Location = new System.Drawing.Point(74, 61);
            this.cbBallList2.Name = "cbBallList2";
            this.cbBallList2.Size = new System.Drawing.Size(121, 21);
            this.cbBallList2.TabIndex = 2;
            // 
            // cbBallList1
            // 
            this.cbBallList1.FormattingEnabled = true;
            this.cbBallList1.Items.AddRange(new object[] {
            "White",
            "Yellow",
            "Green",
            "Brown",
            "Blue",
            "Pink",
            "Black"});
            this.cbBallList1.Location = new System.Drawing.Point(74, 25);
            this.cbBallList1.Name = "cbBallList1";
            this.cbBallList1.Size = new System.Drawing.Size(121, 21);
            this.cbBallList1.TabIndex = 1;
            this.cbBallList1.SelectedValueChanged += new System.EventHandler(this.CheckSelectedBall);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chose balls: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbAngle);
            this.groupBox3.Controls.Add(this.lbSecondBallInfo);
            this.groupBox3.Controls.Add(this.lbFirstBallInfo);
            this.groupBox3.Location = new System.Drawing.Point(12, 877);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 84);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ball information";
            // 
            // lbAngle
            // 
            this.lbAngle.AutoSize = true;
            this.lbAngle.Location = new System.Drawing.Point(256, 25);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(35, 13);
            this.lbAngle.TabIndex = 4;
            this.lbAngle.Text = "label2";
            // 
            // lbSecondBallInfo
            // 
            this.lbSecondBallInfo.AutoSize = true;
            this.lbSecondBallInfo.Location = new System.Drawing.Point(129, 25);
            this.lbSecondBallInfo.Name = "lbSecondBallInfo";
            this.lbSecondBallInfo.Size = new System.Drawing.Size(35, 13);
            this.lbSecondBallInfo.TabIndex = 1;
            this.lbSecondBallInfo.Text = "label3";
            // 
            // lbFirstBallInfo
            // 
            this.lbFirstBallInfo.AutoSize = true;
            this.lbFirstBallInfo.Location = new System.Drawing.Point(6, 25);
            this.lbFirstBallInfo.Name = "lbFirstBallInfo";
            this.lbFirstBallInfo.Size = new System.Drawing.Size(35, 13);
            this.lbFirstBallInfo.TabIndex = 0;
            this.lbFirstBallInfo.Text = "label2";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnShowDirection);
            this.groupBox4.Controls.Add(this.btnTakeShot);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtPower);
            this.groupBox4.Controls.Add(this.txtAngle);
            this.groupBox4.Location = new System.Drawing.Point(346, 776);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 185);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shot options";
            // 
            // btnShowDirection
            // 
            this.btnShowDirection.Location = new System.Drawing.Point(6, 101);
            this.btnShowDirection.Name = "btnShowDirection";
            this.btnShowDirection.Size = new System.Drawing.Size(148, 30);
            this.btnShowDirection.TabIndex = 5;
            this.btnShowDirection.Text = "Show Direction";
            this.btnShowDirection.UseVisualStyleBackColor = true;
            this.btnShowDirection.Click += new System.EventHandler(this.btnShowDirection_Click_1);
            // 
            // btnTakeShot
            // 
            this.btnTakeShot.Location = new System.Drawing.Point(6, 149);
            this.btnTakeShot.Name = "btnTakeShot";
            this.btnTakeShot.Size = new System.Drawing.Size(148, 30);
            this.btnTakeShot.TabIndex = 4;
            this.btnTakeShot.Text = "Take Shot";
            this.btnTakeShot.UseVisualStyleBackColor = true;
            this.btnTakeShot.Click += new System.EventHandler(this.btnTakeShot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Power:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Angle:";
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(54, 61);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(100, 20);
            this.txtPower.TabIndex = 1;
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(54, 25);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 20);
            this.txtAngle.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::Snooker_Game.Properties.Resources.Snooker_Table_v2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1490, 970);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbBallList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snooker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.placeWhiteBall);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            this.groupBox2.ResumeLayout(false);
            this.gbBallList.ResumeLayout(false);
            this.gbBallList.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbBallList;
        private System.Windows.Forms.ComboBox cbBallList2;
        private System.Windows.Forms.ComboBox cbBallList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbSecondBallInfo;
        private System.Windows.Forms.Label lbFirstBallInfo;
        private System.Windows.Forms.Label lbAngle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTakeShot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Button btnShowDirection;
    }
}

