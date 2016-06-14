using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snooker_Game
{
    class Ball
    {
        private Vector center;
        private Vector velocity;
        private Color colour;
        private double speed;
        private int diameter;
        private bool moveBall;

        public Vector Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        public Vector Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public Color Colour
        {
            get
            {
                return colour;
            }

            set
            {
                colour = value;
            }
        }

        public int Diameter
        {
            get
            {
                return diameter;
            }

            set
            {
                diameter = value;
            }
        }

        public double Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public bool MoveBall
        {
            get
            {
                return moveBall;
            }

            set
            {
                moveBall = value;
            }
        }

        public Ball()
        {
            center.X = 0.0;
            center.Y = 0.0;
            velocity.X = 0.0;
            velocity.Y = 0.0;
            colour = Color.White;
            diameter = 0;
            speed = 0;
            moveBall = false;
        }
        
        public Ball(Vector center1, Vector velocity1, Color colour1, int diameter1, double speed1, bool moveBall1)
        {
            center = center1;
            velocity = velocity1;
            colour = colour1;
            diameter = diameter1;
            speed = speed1;
            moveBall = moveBall1;
        }

        public Ball(int centerX, int centerY, int velocityX, int velocityY, Color colour1, int diameter1, double speed1, bool moveBall1)
        {
            center.X = centerX;
            center.Y = centerY;
            velocity.X = velocityX;
            velocity.Y = velocityY;
            colour = colour1;
            diameter = diameter1;
            speed = speed1;
            moveBall = moveBall1;
        }

        //public void Move_Ball(SnookerTable snookerTable)
        //{
        //    if (moveBall == true)
        //    {
        //        center.X += velocity.X * speed;
        //        center.Y += velocity.Y * speed;

        //        velocity.X *= snookerTable.Friction;
        //        velocity.Y *= snookerTable.Friction;

        //        if ((velocity.X < 0.01 && velocity.X > -0.01) && (velocity.Y < 0.01 && velocity.Y > -0.01))
        //        {
        //            velocity.X = 0;
        //            velocity.Y = 0;
        //        }

        //        if (center.X <= snookerTable.TopLeftX + diameter / 2)
        //        {
        //            velocity.X = -velocity.X;
        //            center.X = snookerTable.TopLeftX + diameter / 2;
        //        }
        //        if (center.X >= snookerTable.TopLeftX + snookerTable.Width - snookerTable.RightBorder - diameter / 2)
        //        {
        //            velocity.X = -velocity.X;
        //            center.X = snookerTable.TopLeftX + snookerTable.Width - snookerTable.RightBorder - diameter / 2;
        //        }
        //        if (center.Y <= snookerTable.TopLeftY + diameter / 2)
        //        {
        //            velocity.Y = -velocity.Y;
        //            center.Y = snookerTable.TopLeftY + diameter / 2;
        //        }
        //        if (center.Y >= snookerTable.TopLeftY + snookerTable.Height - snookerTable.BottomBorder - diameter / 2)
        //        {
        //            velocity.Y = -velocity.Y;
        //            center.Y = snookerTable.TopLeftY + snookerTable.Height - snookerTable.BottomBorder - diameter / 2;
        //        }
        //    }
        //}
    }
}
