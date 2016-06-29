using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snooker_Game.Properties;
using System.IO;

namespace Snooker_Game
{
    public partial class Form1 : Form
    {
        //SnookerTable snookerTable = new SnookerTable(50, 50, 720, 1440, 50, 50, 0.97);
        SnookerTable snookerTable = new SnookerTable();
        Vector mouseLocation = new Vector();
        

        enum Balls
        {
            cueBall, blackBall, pinkBall, blueBall, redBall
        }
        
        public Form1()
        {
            InitializeComponent();
            setUpBalls();
            setUpPockets();
            setUpTable();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void setUpTable()
        {
            const int TOP_LEFT_X = 50;
            const int TOP_LEFT_Y = 50;
            const int TABLE_HEIGHT = 720;
            const int TABLE_WIDTH = 1440;
            const int RIGHT_BOARDER = 50;
            const int BOTTOM_BOARDER = 50;
            const double FRICTION = 0.97;

            snookerTable.TopLeftX = TOP_LEFT_X;
            snookerTable.TopLeftY = TOP_LEFT_Y;
            snookerTable.Height = TABLE_HEIGHT;
            snookerTable.Width = TABLE_WIDTH;
            snookerTable.RightBorder = RIGHT_BOARDER;
            snookerTable.BottomBorder = BOTTOM_BOARDER;
            snookerTable.Friction = FRICTION;
        }

        private void setUpBalls()
        {
            const int MID_Y = 385;
            const int B_LINE = 360;
            const int BLACK_X = 1292;
            const int PINK_X = 1080;
            const int BLUE_X = 745;
            const int GREEN_Y = 500;
            const int YELLOW_Y = 270;
            const int DIAMETER = 30;

            snookerTable.addBall(0, 300, 330,  Color.White, DIAMETER);
            snookerTable.addBall(6, BLACK_X, MID_Y, Color.Black, DIAMETER);
            snookerTable.addBall(5, PINK_X, MID_Y, Color.Pink, DIAMETER);
            snookerTable.addBall(4, BLUE_X, MID_Y, Color.Blue, DIAMETER);
            snookerTable.addBall(3, B_LINE, MID_Y, Color.Brown, DIAMETER);
            snookerTable.addBall(2, B_LINE, GREEN_Y, Color.Green, DIAMETER);
            snookerTable.addBall(1, B_LINE, YELLOW_Y, Color.Yellow, DIAMETER);
            
            int radius = 20;
            int redBallNum = 1;
            for (int row = 0; row < 4; row++)
            {
                int startY = MID_Y - row * radius;
                int x = PINK_X + 40 + (int)(row * (Math.Sqrt(3) * radius));
                for (int ball = 0; ball < row + 1; ball++)
                {
                    snookerTable.addBall(redBallNum + 6, x, startY + ball * (2 * radius), Color.Red, DIAMETER);
                    redBallNum++;
                }
                
            }

            cbBallList1.SelectedIndex = 0;
            cbBallList2.SelectedIndex = 1;

            //Bitmap newCur = new Bitmap(Resources.SnookerCue);
            //this.Cursor = CustomCursor.CreateCursor(newCur, newCur.Height + 545, newCur.Width - 549);
        }

        private void setUpPockets()
        {
            const int POCKET_HEIGHT = 35;
            const int POCKET_WIDTH = 35;
            const int LEFT_X = 36;
            const int MIDDLE_X = 727;
            const int RIGHT_X = 1418;
            const int TOP = 36;
            const int BOTTOM = 699;
            
            snookerTable.pockets[0] = new Rectangle(LEFT_X, TOP, POCKET_WIDTH, POCKET_HEIGHT);
            snookerTable.pockets[1] = new Rectangle(MIDDLE_X, TOP - 4, POCKET_WIDTH, POCKET_HEIGHT);
            snookerTable.pockets[2] = new Rectangle(RIGHT_X, TOP, POCKET_WIDTH, POCKET_HEIGHT);
            snookerTable.pockets[3] = new Rectangle(LEFT_X, BOTTOM, POCKET_WIDTH, POCKET_HEIGHT);
            snookerTable.pockets[4] = new Rectangle(MIDDLE_X, BOTTOM + 4, POCKET_WIDTH, POCKET_HEIGHT);
            snookerTable.pockets[5] = new Rectangle(RIGHT_X, BOTTOM, POCKET_WIDTH, POCKET_HEIGHT);
        }

        private void paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 4f);
            Pen bluePen = new Pen(Color.Blue, 1f);
                     
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                if (snookerTable.balls[i].Potted == false || i == 0)
                {
                    snookerTable.DrawBall(e.Graphics, snookerTable.balls[i]);
                }
            }
            
            if (mouseLocation.Y <= 770)
            {
                e.Graphics.DrawLine(blackPen, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y, (float)snookerTable.balls[0].Center.X + (float)(snookerTable.balls[0].Center.X - mouseLocation.X), (float)snookerTable.balls[0].Center.Y + (float)(snookerTable.balls[0].Center.Y - mouseLocation.Y));
            }
            //e.Graphics.DrawLine(blackPen, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y, (float)snookerTable.balls[0].Center.X + (float)(snookerTable.balls[0].Center.X - (float)shotPoint.X), (float)snookerTable.balls[0].Center.Y + (float)(snookerTable.balls[0].Center.Y - (float)shotPoint.Y));
            //e.Graphics.DrawLine(blackPen, (float)shotPoint.X, (float)shotPoint.Y, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y);
            e.Graphics.DrawLine(blackPen, (float)snookerTable.balls[cbBallList1.SelectedIndex].Center.X, (float)snookerTable.balls[cbBallList1.SelectedIndex].Center.Y, (float)snookerTable.balls[cbBallList2.SelectedIndex].Center.X, (float)snookerTable.balls[cbBallList2.SelectedIndex].Center.Y);
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (mouseLocation.Y <= 770)
            {
                snookerTable.balls[0].Velocity.X = snookerTable.balls[0].Center.X - mouseLocation.X;
                snookerTable.balls[0].Velocity.Y = snookerTable.balls[0].Center.Y - mouseLocation.Y;
                float length = (float)snookerTable.balls[0].Velocity.Length();

                if (length > 40)
                {
                    length = 40;
                    snookerTable.balls[0].Speed = length / 10;
                }


                if (length != 0)
                {
                    snookerTable.balls[0].Velocity.X /= length;
                    snookerTable.balls[0].Velocity.Y /= length;
                }

                for (int i = 0; i < snookerTable.balls.Length; i++)
                {
                    snookerTable.balls[i].MoveBall = true;
                }
            }
        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.MoveBall(snookerTable.balls[i]);
                for (int j = 0; j < snookerTable.pockets.Length; j++)
                {
                    snookerTable.checkPockets(snookerTable.balls[i], snookerTable.pockets[j]);
                }
            }
            snookerTable.resolveElasticCollisions();
            displayBallInfo(cbBallList1.SelectedIndex,cbBallList2.SelectedIndex);
            this.Refresh();
        }
        
        private void placeWhiteBall(object sender, MouseEventArgs e)
        {
            //mouseLocation.X = e.X;
            //mouseLocation.Y = e.Y;
            //snookerTable.addBall(0, (int)mouseLocation.X, (int)mouseLocation.Y, 0, 0, Color.White, 21, 0, false);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }
        
        private void CheckSelectedBall(object sender, EventArgs e)
        {
            
        }
        
        private void displayBallInfo(int ballNum1, int ballNum2)
        {
            lbFirstBallInfo.Text = snookerTable.balls[ballNum1].ToString();
            lbSecondBallInfo.Text = snookerTable.balls[ballNum2].ToString();
            lbAngle.Text = "Angle: " + snookerTable.balls[ballNum1].Center.AngleBetween(snookerTable.balls[ballNum2].Center).ToString("g3");
        }
        
        Vector shotPoint = new Vector();
        private void btnTakeShot_Click(object sender, EventArgs e)
        {
            snookerTable.balls[cbBallList1.SelectedIndex].Velocity.X = snookerTable.balls[cbBallList2.SelectedIndex].Center.X - snookerTable.balls[cbBallList1.SelectedIndex].Center.X  ;
            snookerTable.balls[cbBallList1.SelectedIndex].Velocity.Y = snookerTable.balls[cbBallList2.SelectedIndex].Center.Y - snookerTable.balls[cbBallList1.SelectedIndex].Center.Y  ;
            float length = (float)snookerTable.balls[0].Velocity.Length();

            if (length > 40)
            {
                length = 40;
                snookerTable.balls[cbBallList1.SelectedIndex].Speed = length / 10;
            }
            
            if (length != 0)
            {
                snookerTable.balls[cbBallList1.SelectedIndex].Velocity.X /= length;
                snookerTable.balls[cbBallList1.SelectedIndex].Velocity.Y /= length;
            }

            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.balls[i].MoveBall = true;
            }

        }

        
        private void btnShowDirection_Click_1(object sender, EventArgs e)
        {
            //drawShotPoint();
        }
        
        private void drawShotPoint()
        {
            //int angle = (int)snookerTable.balls[cbBallList1.SelectedIndex].Center.AngleBetween(snookerTable.balls[cbBallList2.SelectedIndex].Center);
            //Int32.TryParse(label2.Text, out angle);
            //txtAngle.Text = snookerTable.balls[cbBallList1.SelectedIndex].Center.AngleBetween(snookerTable.balls[cbBallList2.SelectedIndex].Center).ToString("g3");

            //int power;
            //Int32.TryParse(txtPower.Text, out power);

            //shotPoint.X = snookerTable.balls[0].Center.X + (power * Math.Sin(angle * Math.PI / 180));
            //shotPoint.Y = snookerTable.balls[0].Center.Y + (power * Math.Cos(angle * Math.PI / 180));
        }

        private void btnStartNewDefaultGame_Click(object sender, EventArgs e)
        {
            setUpBalls();
            setUpPockets();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

        }

        private void pressSave(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog.FileName;
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                File.AppendAllText(name, snookerTable.balls[i].saveString());
            }
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    string[] gameData = File.ReadAllLines(file);
                    
                    for (int i = 0; i < snookerTable.balls.Length; i++)
                    {
                        string[] ballData = gameData[i].Split(',');

                        snookerTable.balls[i].Center.X = double.Parse(ballData[0]);
                        snookerTable.balls[i].Center.Y = double.Parse(ballData[1]);
                        snookerTable.balls[i].Potted = bool.Parse(ballData[2]);
                    }

                }
                catch (IOException)
                {
                }
            }
        }
    }
}
