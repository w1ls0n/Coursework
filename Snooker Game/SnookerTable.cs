using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snooker_Game
{
    class SnookerTable
    {
        const int numOfBalls = 3;
        public Ball[] balls = new Ball[numOfBalls];
        private double friction;
        private int topLeftX;
        private int topLeftY;
        private int width;
        private int height;
        private int rightBorder;
        private int bottomBorder;


        public double Friction
        {
            get
            {
                return friction;
            }

            set
            {
                friction = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int RightBorder
        {
            get
            {
                return rightBorder;
            }

            set
            {
                rightBorder = value;
            }
        }

        public int BottomBorder
        {
            get
            {
                return bottomBorder;
            }

            set
            {
                bottomBorder = value;
            }
        }

        public int TopLeftX
        {
            get
            {
                return topLeftX;
            }

            set
            {
                topLeftX = value;
            }
        }

        public int TopLeftY
        {
            get
            {
                return topLeftY;
            }

            set
            {
                topLeftY = value;
            }
        }
        public SnookerTable(int topLeftX1, int topLeftY1, int height1, int width1, int rightBorder1, int bottomBorder1, double friction1)
        {
            topLeftX = topLeftX1;
            topLeftY = topLeftY1;
            height = height1;
            width = width1;
            rightBorder = rightBorder1;
            bottomBorder = bottomBorder1;
            friction = friction1;
        }

        public void addBall(int ballNum, int centerX, int centerY, int velocityX, int velocityY, Color colour, int diameter, double speed, bool moveBall)
        {
            Vector center = new Vector(centerX, centerY);
            Vector velocity = new Vector(velocityX, velocityY);
            balls[ballNum] = new Ball(center, velocity, colour, diameter, speed, moveBall);
        }

        public void DrawBall(Graphics g, Ball b)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            float positionX = (float)b.Center.X - b.Diameter / 2;
            float positionY = (float)b.Center.Y - b.Diameter / 2;
            RectangleF outerRectangle = new RectangleF(positionX, positionY, b.Diameter, b.Diameter);
            g.DrawEllipse(blackPen, outerRectangle);
            SolidBrush brush = new SolidBrush(b.Colour);
            g.FillEllipse(brush, outerRectangle);
        }

        public void MoveBall(Ball b)
        {
            if (b.MoveBall == true)
            {
                b.Center.X += b.Velocity.X * b.Speed;
                b.Center.Y += b.Velocity.Y * b.Speed;

                b.Velocity.X *= friction;
                b.Velocity.Y *= friction;

                if ((b.Velocity.X < 0.01 && b.Velocity.X > -0.01) && (b.Velocity.Y < 0.01 && b.Velocity.Y > -0.01))
                {
                    b.Velocity.X = 0;
                    b.Velocity.Y = 0;
                }

                if (b.Center.X <= topLeftX + b.Diameter / 2)
                {
                    b.Velocity.X = -b.Velocity.X;
                    b.Center.X = topLeftX + b.Diameter / 2;
                }
                if (b.Center.X >= topLeftX + width - rightBorder - b.Diameter / 2)
                {
                    b.Velocity.X = -b.Velocity.X;
                    b.Center.X = topLeftX + width - rightBorder - b.Diameter / 2;
                }
                if (b.Center.Y <= topLeftY + b.Diameter / 2)
                {
                    b.Velocity.Y = -b.Velocity.Y;
                    b.Center.Y = topLeftY + b.Diameter / 2;
                }
                if (b.Center.Y >= topLeftY + height - bottomBorder - b.Diameter / 2)
                {
                    b.Velocity.Y = -b.Velocity.Y;
                    b.Center.Y = topLeftY + height - bottomBorder - b.Diameter / 2;
                }
            }
        }

        public bool detectElasticCollision(Ball b1, Ball b2)
        {
            Vector distanceBallOneBallTwo = b2.Center - b1.Center;
            float distance = (float)distanceBallOneBallTwo.Length();
            if (distance < b1.Diameter + 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void resolveElasticCollisions()
        {
            Vector tempVelocity = new Vector();

            for (int i = 0; i < balls.Length; i++)
            {
                for (int j = 0; j < balls.Length; j++)
                {
                    if (detectElasticCollision(balls[i], balls[j]))
                    {
                        tempVelocity = ChangeVelocities(balls[i], balls[j]);
                        balls[j].Velocity = ChangeVelocities(balls[j], balls[i]);
                        balls[i].Velocity = tempVelocity;
                        balls[j].Speed = balls[i].Speed;
                    }
                }
            }

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

        public Vector ChangeVelocities(Ball b1, Ball b2)
        {
            Vector centersVector = b2.Center - b1.Center;
            Vector ballOnePerpendicular = centersVector.PerpendicularComponent(b1.Velocity);
            Vector ballTwoPerpendicular = centersVector.PerpendicularComponent(b2.Velocity);
            Vector ballTwoPara = centersVector.ParralelComponent(b2.Velocity);
            Vector ballOneNewVelocity = ballTwoPara + ballOnePerpendicular;
            return ballOneNewVelocity;
        }
    }
}
