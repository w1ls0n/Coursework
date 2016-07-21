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
        SnookerTable snookerTable = new SnookerTable();
        Vector mouseLocation = new Vector();
        
        public Form1()
        {
            // sets up a defualt game when the program is opened
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
            // sets up the table with all the default properties 
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
            // places the balls in thier default locations
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
            
            // a loop to set up the red balls in the triangle formation

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
            // sets the location of the pockets

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

            //draw all of the balls to the screen

            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                if (snookerTable.balls[i].Potted == false || i == 0)
                {
                    snookerTable.DrawBall(e.Graphics, snookerTable.balls[i]);
                }
            }
            
            // draws the direction of the shot to the screen is the mouse is within the boundaries of the snooker table and if the option is checked

            if (mouseLocation.Y <= 770 && cbShowDirection.Checked == true)
            {
                e.Graphics.DrawLine(blackPen, (float)snookerTable.balls[0].Center.X, (float)snookerTable.balls[0].Center.Y, (float)snookerTable.balls[0].Center.X + (float)(snookerTable.balls[0].Center.X - mouseLocation.X), (float)snookerTable.balls[0].Center.Y + (float)(snookerTable.balls[0].Center.Y - mouseLocation.Y));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void mouseDown(object sender, MouseEventArgs e)
        {
            // gets the location of the mouse when it is clicked
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            //updates the location of the mouse when it moves
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            // when the mouse button is lifted a shot is taken if the mouse is on the snooker table
            if (mouseLocation.Y <= 770)
            {

                // sets the velocites of the balls depending on the mouse location and the location of center of the ball
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
                // allows all balls to move
                snookerTable.MoveBall(snookerTable.balls[i]);
                for (int j = 0; j < snookerTable.pockets.Length; j++)
                {
                    //checks if balls have been potted
                    snookerTable.checkPockets(snookerTable.balls[i], snookerTable.pockets[j]);
                }
            }
            //resolves collisions
            snookerTable.resolveElasticCollisions();

            //displays the information to the user about the balls that they chosose
            displayBallInfo(cbBallList1.SelectedIndex,cbBallList2.SelectedIndex);

            // shows the direction of the ball is the user presses the button
            if (showDirection == true)
            {
                drawShot();
            }

            this.Refresh();
        }
       

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }
        
        private void displayBallInfo(int ballNum1, int ballNum2)
        {
            // displays ball information to the user
            lbFirstBallInfo.Text = snookerTable.balls[ballNum1].ToString();
            lbSecondBallInfo.Text = snookerTable.balls[ballNum2].ToString();
            lbAngle.Text = snookerTable.balls[ballNum1].Center.AngleBetween(snookerTable.balls[ballNum2].Center).ToString("g3") + " degrees";
        }
        
      
        private void btnTakeShot_Click(object sender, EventArgs e)
        {
            // when the take shot button is pressed
            int power;

            Int32.TryParse(txtPower.Text, out power);
                
            double ballCenterX = snookerTable.balls[0].Center.X;
            double ballCenterY = snookerTable.balls[0].Center.Y;

            int angle = -(int)numAngle.Value;

            // creates a new point to similar to when using the mouse location 
            Vector shotPoint = new Vector();
            shotPoint.X = (power * 10) * Math.Cos(angle * (Math.PI / 180));
            shotPoint.Y = (power * 10) * Math.Sin(angle * (Math.PI / 180));


            // sets the velocity of the ball
            snookerTable.balls[0].Velocity.X = ballCenterX - (ballCenterX - shotPoint.X);
            snookerTable.balls[0].Velocity.Y = ballCenterY - (ballCenterY - shotPoint.Y);

            float length = (float)snookerTable.balls[0].Velocity.Length();

            // checks to stop the ball going to fast
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

        bool showDirection = false;
        private void btnShowDirection_Click_1(object sender, EventArgs e)
        {
            // makes the show direction button toggle between on and off
            if (showDirection == false)
            {
                showDirection = true;
            }
            else if(showDirection == true)
            {
                showDirection = false;
            }
        }

        private void drawShot()
        {
            // draws the shot direction

            Graphics graphics = this.CreateGraphics();
            int power;

            Int32.TryParse(txtPower.Text, out power);

            double ballCenterX = snookerTable.balls[0].Center.X;
            double ballCenterY = snookerTable.balls[0].Center.Y;

            int angle = -(int)numAngle.Value;

            Vector shotPoint = new Vector();
            shotPoint.X = (power * 10) * Math.Cos(angle * (Math.PI / 180));
            shotPoint.Y = (power * 10) * Math.Sin(angle * (Math.PI / 180));

            Pen blackPen = new Pen(Color.Black, 3f);
            graphics.DrawLine(blackPen, (float)ballCenterX, (float)ballCenterY, (float)(shotPoint.X + ballCenterX), (float)(shotPoint.Y + ballCenterY));
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
            //loops through all balls and save their information to a file

            string name = saveFileDialog.FileName;
            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                File.AppendAllText(name, snookerTable.balls[i].saveString());
            }
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            // the user chooses the file they want to open

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    string[] gameData = File.ReadAllLines(file);
                    
                    for (int i = 0; i < snookerTable.balls.Length; i++)
                    {
                        // gets infomation from string array by using commas to separate information

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
