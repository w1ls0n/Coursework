using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker_Game
{
    class Cue
    {
        private int angle, power;

        public int Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        public int Power
        {
            get
            {
                return power;
            }

            set
            {
                power = value;
            }
        }
    }
}
