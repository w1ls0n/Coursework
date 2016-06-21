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

namespace Snooker_Game
{
    public partial class Form1 : Form
    {
        SnookerTable snookerTable = new SnookerTable(50, 50, 720, 1440, 50, 50, 0.97);
        Vector mouseLocation = new Vector();
        int tick;

        enum Balls
        {
            cueBall, blackBall, pinkBall, blueBall, redBall
        }
        
        public Form1()
        {
            InitializeComponent();
            setUpGame();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void setUpGame()
        {
            snookerTable.addBall(0, 300, 330, 0, 0, Color.White, 30, 0, false, false);
            snookerTable.addBall(6, 1292, 385, 0, 0, Color.Black, 30, 0, false, false);
            snookerTable.addBall(5, 1080, 385, 0, 0, Color.Pink, 30, 0, false, false);
            snookerTable.addBall(4, 745, 385, 0, 0, Color.Blue, 30, 0, false, false);
            snookerTable.addBall(3, 360, 385, 0, 0, Color.Brown, 30, 0, false, false);
            snookerTable.addBall(2, 360, 500, 0, 0, Color.Green, 30, 0, false, false);
            snookerTable.addBall(1, 360, 270, 0, 0, Color.Yellow, 30, 0, false, false);

            int radius = 20;
            int redBallNum = 1;
            for (int row = 0; row < 4; row++)
            {
                int startY = 385 - row * radius;
                int x = 1120 + (int)(row * (Math.Sqrt(3) * radius));
                for (int ball = 0; ball < row + 1; ball++)
                {
                    snookerTable.addBall(redBallNum + 6, x, startY + ball * (2 * radius), 0, 0, Color.Red, 30, 0, false, false);
                    redBallNum++;
                }
                
            }

            snookerTable.pockets[0] = new Rectangle(36, 36, 35, 35);
            snookerTable.pockets[1] = new Rectangle(727, 32, 35, 35);
            snookerTable.pockets[2] = new Rectangle(1418, 36, 35, 35);
            snookerTable.pockets[3] = new Rectangle(36, 699, 35, 35);
            snookerTable.pockets[4] = new Rectangle(727, 703, 35, 35);
            snookerTable.pockets[5] = new Rectangle(1418, 699, 35, 35);

            cbBallList1.SelectedIndex = 0;
            cbBallList2.SelectedIndex = 1;

            //Bitmap newCur = new Bitmap(Resources.SnookerCue);
            //this.Cursor = CustomCursor.CreateCursor(newCur, newCur.Height + 545, newCur.Width - 549);
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
            e.Graphics.DrawLine(blackPen, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y, (float)snookerTable.balls[0].Center.X + (float)(snookerTable.balls[0].Center.X - (float)shotPoint.X), (float)snookerTable.balls[0].Center.Y + (float)(snookerTable.balls[0].Center.Y - (float)shotPoint.Y));
            //e.Graphics.DrawLine(blackPen, (float)shotPoint.X, (float)shotPoint.Y, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y);
        
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
            tick++;
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

        private void save(SnookerTable snookerTable)
        {
            GameData CurrentGameData = new GameData();
            CurrentGameData.cueBall = snookerTable.balls[0];
            CurrentGameData.yellowBall = snookerTable.balls[1];

            string fileName = tick.ToString();


        }


        Vector shotPoint = new Vector();
        private void btnTakeShot_Click(object sender, EventArgs e)
        {
            snookerTable.balls[0].Velocity.X = snookerTable.balls[0].Center.X - shotPoint.X;
            snookerTable.balls[0].Velocity.Y = snookerTable.balls[0].Center.Y - shotPoint.Y;
            float length = (float)snookerTable.balls[0].Velocity.Length();

            if (length > 100)
            {
                length = 100;
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

        
        private void btnShowDirection_Click_1(object sender, EventArgs e)
        {
            drawShotPoint();
        }
        
        private void drawShotPoint()
        {
            int angle;
            Int32.TryParse(txtAngle.Text, out angle);

            int power;
            Int32.TryParse(txtPower.Text, out power);

            shotPoint.X = snookerTable.balls[0].Center.X + (power * Math.Sin(angle * Math.PI / 180));
            shotPoint.Y = snookerTable.balls[0].Center.Y + (power * Math.Cos(angle * Math.PI / 180));
            
        }
    }
}
