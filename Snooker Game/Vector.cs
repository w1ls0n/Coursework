using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Game
{
    class Vector
    {
        private double x, y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Vector()
        {
            x = 0.0;
            y = 0.0;
        }

        public Vector(double x1, double y1)
        {
            x = x1;
            y = y1;
        }

        public Vector(Vector v)
        {
            x = v.x;
            y = v.y;
        }

        public override string ToString()
        {
            return "(" + x.ToString("g4") + "," + y.ToString("g4") + ")";
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double DotProduct(Vector v2)
        {
            return (x * v2.X + y * v2.Y);
        }

        public Vector Scale(double scale)
        {
            return new Vector(scale * x, scale * y);
        }

        public Vector ParralelComponent(Vector v2)
        {
            double lengthSquared, dotProduct, scale;
            lengthSquared = Length() * Length();
            dotProduct = DotProduct(v2);
            if (lengthSquared != 0)
                scale = dotProduct / lengthSquared;
            else
                return new Vector();
            return new Vector(this.Scale(scale));
        }

        public Vector PerpendicularComponent(Vector v2)
        {
            return new Vector(v2 - this.ParralelComponent(v2));
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1)
        {
            return new Vector(-v1.x, -v1.y);
        }

        public double AngleBetween(Vector v2)
        {
            double xDiff = v2.X - x;
            double yDiff = v2.y - y;
            double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;

            //if (angle < 0)
            //{
            //    angle = -angle; 
            //}

            return angle;
        }
    }
}
