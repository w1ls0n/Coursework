using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snooker_Game
{
    class SnookerTable
    {
        const int numOfBalls = 17;
        public Ball[] balls = new Ball[numOfBalls];
        public Ball ghostBall = new Ball();
        public Rectangle[] pockets = new Rectangle[6];
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
        
        public SnookerTable()
        {
            topLeftX = 0;
            topLeftY = 0;
            height = 0;
            width = 0;
            rightBorder = 0;
            bottomBorder = 0;
            friction = 0;
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

        public void addBall(int ballNum)
        {
            balls[ballNum] = new Ball();
        }

        public void addBall(int ballNum, int centerX, int centerY, Color colour, int diameter)
        {
            addBall(ballNum, centerX, centerY, 0, 0, colour, diameter, 0, false, false);
        }

        public void addBall(int ballNum, int centerX, int centerY, int velocityX, int velocityY, Color colour, int diameter, double speed, bool moveBall, bool potted)
        {
            Vector center = new Vector(centerX, centerY);
            Vector velocity = new Vector(velocityX, velocityY);
            balls[ballNum] = new Ball(center, velocity, colour, diameter, speed, moveBall, potted);
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

        public void DrawGhostBall(Graphics g, Ball b)
        {
            Pen whitePen = new Pen(Color.White, 3);

            float positionX = (float)b.Center.X - b.Diameter / 2;
            float positionY = (float)b.Center.Y - b.Diameter / 2;

            RectangleF outerRectangle = new RectangleF(positionX, positionY, b.Diameter, b.Diameter);
            g.DrawEllipse(whitePen, outerRectangle);
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
            float overLap = b1.Diameter - distance;
            if (distance < b1.Diameter + 3)
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
            for (int i = 0; i < balls.Length; i++)
            {
                for (int j = 0; j < balls.Length; j++)
                {
                    if (j > i)
                    {
                        if (detectElasticCollision(balls[i], balls[j]))
                        {
                            Vector tempVelocity = new Vector();
                            tempVelocity = ChangeVelocities(balls[i], balls[j]);
                            balls[j].Velocity = ChangeVelocities(balls[j], balls[i]);
                            balls[i].Velocity = tempVelocity;
                            balls[j].Speed = balls[i].Speed;
                        }
                    }
                }
            }
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

        public void checkPockets(Ball b1, Rectangle p1)
        {
            double x = b1.Center.X;
            double y = b1.Center.Y;

            Point ballCenter = new Point((int)x, (int)y);
            if (p1.Contains(ballCenter) && b1.Colour != Color.White)
            {
                b1.Potted = true;
                b1.Center.X = 1480;
                b1.Speed = 0;
            }
        }

        public void drawPath(Graphics g, Ball b1)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            double x = b1.Center.X + b1.Velocity.X * b1.Speed;
            double y = b1.Center.Y + b1.Velocity.Y * b1.Speed;
            Point prediction = new Point((int)x, (int)y);

            Point ballCenter = new Point((int)b1.Center.X, (int)b1.Center.Y);

            g.DrawLine(blackPen, ballCenter, prediction);
        }
    }
}
