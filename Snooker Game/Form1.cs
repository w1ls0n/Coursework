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
            cueBall, blueBall, redBall
        }
        //Vector radius = new Vector();
        //Vector whiteBallCenter = new Vector();
        //Vector whiteBallVelocity = new Vector();
        //Vector redBallCenter = new Vector();
        //Vector redBallVelocity = new Vector();
        //Vector yellowBallCenter = new Vector();
        //Vector yellowBallVelocity = new Vector();
        //Vector greenBallCenter = new Vector();
        //Vector greenBallVelocity = new Vector();
        //float width = 1440;
        //float height = 720;
        //float topLeftX = 50;
        //float topLeftY = 50;
        //int rightBorder = 50, bottomBorder = 50;
        //double friction = 0.98;
        //float diameter = 21;
        //bool moveWhiteBall;
        //bool moveRedBall;
        //bool moveYellowBall;
        //bool moveGreenBall;
        //float whiteBallSpeed;
        //float redBallSpeed;
        //float yellowBallSpeed;
        //float greenBallSpeed;



        //const int numOfBalls = 4;


        //Rectangle[] pockets = new Rectangle[6];
        //Vector[] ballCenters = new Vector[numOfBalls];
        //Vector[] ballVelocities = new Vector[numOfBalls];
        //bool[] moveBalls = new bool[numOfBalls];
        //float[] ballSpeeds = new float[numOfBalls];
        
        //Rectangle topRightPocket = new Rectangle(36, 36, 35, 35);

        public Form1()
        {
            InitializeComponent();
            setUpGame();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            //radius.X = diameter / 2;
            //radius.Y = diameter / 2;
            //whiteBallCenter.X = 320;
            //whiteBallCenter.Y = 310;
            //redBallCenter.X = 745;
            //redBallCenter.Y = 385;
            //yellowBallCenter.X = 360;
            //yellowBallCenter.Y = 270;
            //greenBallCenter.X = 360;
            //greenBallCenter.Y = 500;
            //moveWhiteBall = false;
            //moveRedBall = true;
            //moveYellowBall = true;
            //moveGreenBall = true;
        }

        private void setUpGame()
        {
            //pockets[0] = new Rectangle(36, 36, 35, 35);
            //ballCenters[0] = new Vector(320,310);
            snookerTable.addBall((int)Balls.cueBall, 645, 385, 0, 0, Color.White, 50, 0, false);
            snookerTable.addBall((int)Balls.blueBall, 745, 385, 1, 1, Color.Blue, 50, 1, false);
            snookerTable.addBall((int)Balls.redBall, 845, 385, 2, 2, Color.Red, 50, 2, false);
            Bitmap newCur = new Bitmap(Resources.SnookerCue);
            this.Cursor = CustomCursor.CreateCursor(newCur, newCur.Height + 545, newCur.Width - 549);
        }

        private void paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 4f);
            Pen bluePen = new Pen(Color.Blue, 1f);
            e.Graphics.DrawLine(blackPen, (int)mouseLocation.X, (int)mouseLocation.Y, (int)snookerTable.balls[0].Center.X, (int)snookerTable.balls[0].Center.Y);
            //e.Graphics.DrawRectangle(bluePen, topRightPocket);

            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.DrawBall(e.Graphics, snookerTable.balls[i]);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;

            //moveWhiteBall = false;
            //moveRedBall = false;
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

            //snookerTable.balls[0].MoveBall = true;
            //snookerTable.balls[1].MoveBall = true;

            //moveWhiteBall = true;
            //moveRedBall = true;
            //moveYellowBall = true;
            //moveGreenBall = true;
        }

        //private bool DetectCollision(Vector ballOneCentre, Vector ballTwoCentre)
        //{
        //    Vector distanceBallOneBallTwo = ballTwoCentre - ballOneCentre;
        //    float distance = (float)distanceBallOneBallTwo.Length();
        //    if (distance < diameter + 2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //MoveBall(whiteBallVelocity, whiteBallCenter, whiteBallSpeed, moveWhiteBall);
            //MoveBall(redBallVelocity, redBallCenter, redBallSpeed, moveRedBall);
            //MoveBall(yellowBallVelocity, yellowBallCenter, yellowBallSpeed, moveYellowBall);
            //MoveBall(greenBallVelocity, greenBallCenter, greenBallSpeed, moveGreenBall);

            //for (int i = 0; i < numOfBalls; i++)
            //{
            //    MoveBall(ballVelocities[i], ballCenters[i], ballSpeeds[i], moveBalls[i]);
            //}


            //CheckCollisions();
            //checkPockets();
            //label1.Text = "White Ball Center: " + whiteBallCenter.ToString() + "White Ball Velocity: " + redBallVelocity.ToString() + "Red Ball Center: " + redBallCenter.ToString() + "Red Ball Velocity: " + redBallVelocity.ToString();





            for (int i = 0; i < snookerTable.balls.Length; i++)
            {
                snookerTable.MoveBall(snookerTable.balls[i]);
            }
            snookerTable.resolveElasticCollisions();

            this.Refresh();
        }

        private void CheckCollisions()
        {
            //Vector tempVelocity = new Vector();
            //int numOfCollisions = 6;
            //bool[] collisions = new bool[numOfCollisions];

            //for (int i = 0; i < numOfCollisions; i++)
            //{
            //    for (int j = 0; j < numOfCollisions; j++)
            //    {
            //        collisions[i] = DetectCollision(ballCenters[i], ballCenters[j]);
            //    }
            //}



            //bool collisionWhiteRed = DetectCollision(whiteBallCenter, redBallCenter);
            //bool collisionWhiteYellow = DetectCollision(whiteBallCenter, yellowBallCenter);
            //bool collisionWhiteGreen = DetectCollision(whiteBallCenter, greenBallCenter);
            //bool collisionRedYellow = DetectCollision(redBallCenter, yellowBallCenter);
            //bool collisionRedGreen = DetectCollision(redBallCenter, greenBallCenter);
            //bool collisionGreenYellow = DetectCollision(greenBallCenter, yellowBallCenter);

            //if (collisionWhiteRed)
            //{
            //    tempVelocity = ChangeVelocities(whiteBallVelocity, whiteBallCenter, redBallVelocity, redBallCenter);
            //    redBallVelocity = ChangeVelocities(redBallVelocity, redBallCenter, whiteBallVelocity, whiteBallCenter);
            //    whiteBallVelocity = tempVelocity;
            //    redBallSpeed = whiteBallSpeed;
            //}
            //if (collisionWhiteYellow)
            //{
            //    tempVelocity = ChangeVelocities(whiteBallVelocity, whiteBallCenter, yellowBallVelocity, yellowBallCenter);
            //    yellowBallVelocity = ChangeVelocities(yellowBallVelocity, yellowBallCenter, whiteBallVelocity, whiteBallCenter);
            //    whiteBallVelocity = tempVelocity;
            //    yellowBallSpeed = whiteBallSpeed;
            //}
            //if (collisionWhiteGreen)
            //{
            //    tempVelocity = ChangeVelocities(whiteBallVelocity, whiteBallCenter, greenBallVelocity, greenBallCenter);
            //    greenBallVelocity = ChangeVelocities(greenBallVelocity, greenBallCenter, whiteBallVelocity, whiteBallCenter);
            //    whiteBallVelocity = tempVelocity;
            //    greenBallSpeed = whiteBallSpeed;
            //}
            //if (collisionRedYellow)
            //{
            //    tempVelocity = ChangeVelocities(redBallVelocity, redBallCenter, yellowBallVelocity, yellowBallCenter);
            //    yellowBallVelocity = ChangeVelocities(yellowBallVelocity, yellowBallCenter, redBallVelocity, redBallCenter);
            //    redBallVelocity = tempVelocity;
            //    float tempSpeed = redBallSpeed;
            //    redBallSpeed = yellowBallSpeed;
            //    yellowBallSpeed = tempSpeed;
            //}
            //if (collisionRedGreen)
            //{
            //    tempVelocity = ChangeVelocities(redBallVelocity, redBallCenter, greenBallVelocity, greenBallCenter);
            //    yellowBallVelocity = ChangeVelocities(greenBallVelocity, greenBallCenter, redBallVelocity, redBallCenter);
            //    redBallVelocity = tempVelocity;
            //    float tempSpeed = redBallSpeed;
            //    redBallSpeed = greenBallSpeed;
            //    greenBallSpeed = tempSpeed;
            //}
            //if (collisionGreenYellow)
            //{
            //    tempVelocity = ChangeVelocities(greenBallVelocity, greenBallCenter, yellowBallVelocity, yellowBallCenter);
            //    yellowBallVelocity = ChangeVelocities(yellowBallVelocity, yellowBallCenter, greenBallVelocity, greenBallCenter);
            //    greenBallVelocity = tempVelocity;
            //    float tempSpeed = greenBallSpeed;
            //    greenBallSpeed = yellowBallSpeed;
            //    yellowBallSpeed = tempSpeed;
            //}

        }

        private Vector ChangeVelocities(Vector velocityOne, Vector ballCenterOne, Vector velocityTwo, Vector ballCenterTwo)
        {
            Vector centersVector = ballCenterTwo - ballCenterOne;
            Vector ballOnePerpendicular = centersVector.PerpendicularComponent(velocityOne);
            Vector ballTwoPerpendicular = centersVector.PerpendicularComponent(velocityTwo);
            Vector ballTwoPara = centersVector.ParralelComponent(velocityTwo);
            Vector ballOneNewVelocity = ballTwoPara + ballOnePerpendicular;
            return ballOneNewVelocity;
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

    }
}
