using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Global;

namespace Loot3Framework.Types.Structs
{
    public struct Intervall
    {
        private int a;
        private int b;

        public Intervall(int x, int y)
        {
            a = x;
            b = y;
        }

        public int Rand()
        {
            return GlobalRandom.Next(a, b);
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
