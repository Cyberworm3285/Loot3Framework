using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Global;

namespace Loot3Framework.Types.Structs
{
    [Serializable]
    public struct Intervall
    {
        private int a { get; set; }
        private int b { get; set; }
        private int range;

        public Intervall(int x, int y)
        {
            a = x;
            b = y;
            range = y - x;
        }

        public int Rand()
        {
            return GlobalRandom.Next(a, b + 1);
        }

        public override string ToString()
        {
            return "[" + a + ";" + b + "]";
        }

        public int Range
        {
            get { return range; }
        } 

        public int X
        {
            get { return a; }
            set
            {
                a = value;
                range = b - a;
            }
        }

        public int Y
        {
            get { return b; }
            set
            {
                b = value;
                range = b - a;
            }
        }
    }
}
