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
        private bool potted;

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

        public bool Potted
        {
            get
            {
                return potted;
            }

            set
            {
                potted = value;
            }
        }

        public Ball()
        {
            center = new Vector();
            velocity = new Vector();
            center.X = 0.0;
            center.Y = 0.0;
            velocity.X = 0.0;
            velocity.Y = 0.0;
            colour = Color.White;
            diameter = 0;
            speed = 0;
            moveBall = false;
            potted = false;
        }
        
        public Ball(Vector center1, Vector velocity1, Color colour1, int diameter1, double speed1, bool moveBall1, bool potted1)
        {
            center = center1;
            velocity = velocity1;
            colour = colour1;
            diameter = diameter1;
            speed = speed1;
            moveBall = moveBall1;
            potted = potted1;
        }

        public Ball(int centerX, int centerY, int velocityX, int velocityY, Color colour1, int diameter1, double speed1, bool moveBall1, bool potted1)
        {
            center.X = centerX;
            center.Y = centerY;
            velocity.X = velocityX;
            velocity.Y = velocityY;
            colour = colour1;
            diameter = diameter1;
            speed = speed1;
            moveBall = moveBall1;
            potted = potted1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ball center X: " + center.X.ToString("g4"));
            sb.AppendLine("Ball center Y: " + center.Y.ToString("g4"));
            sb.AppendLine("Ball X velocity: " + velocity.X.ToString("g4"));
            sb.AppendLine("Ball Y velocity: " + velocity.Y.ToString("g4"));
            sb.AppendLine("Ball velocity: " + velocity.Length().ToString("g4"));
            sb.AppendLine("Ball angle: " + (-center.AngleBetween(center + velocity)).ToString("g4"));
            sb.AppendLine("Ball Colour: " + colour.ToString());
            sb.AppendLine("Ball diameter: " + diameter.ToString());
            sb.AppendLine("Ball speed: " + speed.ToString());
            sb.AppendLine("Move ball: " + moveBall.ToString());
            sb.AppendLine("Potted: " + potted.ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        public string saveString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(center.X.ToString("g4") + ",");
            sb.Append(center.Y.ToString("g4") + ",");
            sb.Append(potted.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
