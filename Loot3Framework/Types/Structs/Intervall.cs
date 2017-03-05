using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Global;

namespace Loot3Framework.Types.Structs
{
    [CLSCompliant(true)]
    public struct Intervall
    {
        private int a;
        private int b;
        private int range;

        public Intervall(int x, int y)
        {
            a = x;
            b = y;
            range = y - x;
        }

        public int Rand()
        {
            return GlobalRandom.Next(a, b);
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
            set { a = value; }
        }

        public int Y
        {
            get { return b; }
            set { b = value; }
        }
    }
}
