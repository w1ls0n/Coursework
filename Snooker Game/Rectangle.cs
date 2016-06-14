using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Game
{
    class Rectangle1
    {
        private int x, y, height, width;

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

        public int X
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

        public int Y
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

        public Rectangle1()
        {
            X = 0;
            Y = 0;
            Height = 0;
            Width = 0;
        }

        public Rectangle1(int rX, int rY, int rHeight, int rWidth)
        {
            X = rX;
            Y = rY;
            Height = rHeight;
            Width = rWidth;
        }
    }
}
