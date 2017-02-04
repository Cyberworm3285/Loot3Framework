using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Global
{
    [CLSCompliant(true)]
    public static class GlobalRandom
    {
        private static Random random = new Random();

        #region Methods

        public static int Next(int a, int b)
        {
            return random.Next(a, b);
        }

        #endregion
    }
}
