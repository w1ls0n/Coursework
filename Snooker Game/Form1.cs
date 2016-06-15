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
        SnookerTable snookerTable = new SnookerTable(50, 50, 720, 1440, 50, 50, 0.98);
        Vector mouseLocation = new Vector();

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
            snookerTable.addBall(0, 300, 330, 0, 0, Color.White, 21, 0, false, false);
            snookerTable.addBall(1, 1292, 385, 0, 0, Color.Black, 21, 0, false, false);
            snookerTable.addBall(2, 1080, 385, 0, 0, Color.Pink, 21, 0, false, false);
            snookerTable.addBall(3, 745, 385, 0, 0, Color.Blue, 21, 0, false, false);
            snookerTable.addBall(4, 360, 385, 0, 0, Color.Brown, 21, 0, false, false);
            snookerTable.addBall(5, 360, 500, 0, 0, Color.Green, 21, 0, false, false);
            snookerTable.addBall(6, 360, 270, 0, 0, Color.Yellow, 21, 0, false, false);

            int radius = 20;
            int redBallNum = 1;
            for (int row = 0; row < 4; row++)
            {
                int startY = 385 - row * radius;
                int x = 1115 + (int)(row * (Math.Sqrt(3) * radius));
                for (int ball = 0; ball < row + 1; ball++)
                {
                    snookerTable.addBall(redBallNum + 6, x, startY + ball * (2 * radius), 0, 0, Color.Red, 21, 0, false, false);
                    redBallNum++;
                }
                
            }

            snookerTable.pockets[0] = new Rectangle(36, 36, 35, 35);
            snookerTable.pockets[1] = new Rectangle(727, 32, 35, 35);
            snookerTable.pockets[2] = new Rectangle(1418, 36, 35, 35);
            snookerTable.pockets[3] = new Rectangle(36, 699, 35, 35);
            snookerTable.pockets[4] = new Rectangle(727, 703, 35, 35);
            snookerTable.pockets[5] = new Rectangle(1418, 699, 35, 35);

            Bitmap newCur = new Bitmap(Resources.SnookerCue);
            this.Cursor = CustomCursor.CreateCursor(newCur, newCur.Height + 545, newCur.Width - 549);
        }

        private void paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 4f);
            Pen bluePen = new Pen(Color.Blue, 1f);
            e.Graphics.DrawLine(blackPen, (int)mouseLocation.X, (int)mouseLocation.Y, (int)snookerTable.balls[0].Center.X, (int)snookerTable.balls[0].Center.Y);
            
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.DrawBall(e.Graphics, snookerTable.balls[i]);
                //if (snookerTable.balls[i].Potted == false || i == 0)
                //{
                //    snookerTable.DrawBall(e.Graphics, snookerTable.balls[i]);
                //}
            }

            for (int i = 0; i < snookerTable.pockets.Length; i++)
            {
                e.Graphics.DrawRectangle(bluePen, snookerTable.pockets[i]);
            }
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
            snookerTable.balls[0].Velocity.X = snookerTable.balls[0].Center.X - mouseLocation.X;
            snookerTable.balls[0].Velocity.Y = snookerTable.balls[0].Center.Y - mouseLocation.Y;    
            float length = (float)snookerTable.balls[0].Velocity.Length();

            if (length > 20)
            {
                length = 20;
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



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //label1.Text = "White Ball Center: " + whiteBallCenter.ToString() + "White Ball Velocity: " + redBallVelocity.ToString() + "Red Ball Center: " + redBallCenter.ToString() + "Red Ball Velocity: " + redBallVelocity.ToString();
            
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.MoveBall(snookerTable.balls[i]);
                for (int j = 0; j < snookerTable.pockets.Length; j++)
                {
                    snookerTable.checkPockets(snookerTable.balls[i], snookerTable.pockets[j]);
                }
            }
            snookerTable.resolveElasticCollisions();


            

            this.Refresh();
        }
        
        private void checkPockets()
        {
            //Point ballCenterRed = new Point((int)redBallCenter.X, (int)redBallCenter.Y);
            //Point ballCenterWhite = new Point((int)whiteBallCenter.X, (int)whiteBallCenter.Y);
            //if (topRightPocket.Contains(ballCenterRed))
            //{
            //    redBallSpeed = 0;
            //    redBallCenter.X = 745;
            //    redBallCenter.Y = 385;
            //}
            //if (topRightPocket.Contains(ballCenterWhite))
            //{
            //    whiteBallSpeed = 0;
            //    whiteBallCenter.X = 320;
            //    whiteBallCenter.Y = 310;
            //}



            //Point[] balls = new Point[4];

            //for (int i = 0; i < pockets.Length; i++)
            //{
            //    for (int j = 0; j < balls.Length; j++)
            //    {
            //        if (pockets[i].Contains(balls[j]))
            //        {

            //        }
            //    }
            //}


        }

        private void placeWhiteBall(object sender, MouseEventArgs e)
        {
            //mouseLocation.X = e.X;
            //mouseLocation.Y = e.Y;
            //snookerTable.addBall(0, (int)mouseLocation.X, (int)mouseLocation.Y, 0, 0, Color.White, 21, 0, false);
        }
    }
}
