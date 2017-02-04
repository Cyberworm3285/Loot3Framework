using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Types.Structs
{
    [CLSCompliant(true)]
    public struct IntervallChain
    {
        private Intervall[] intervalls;

        public IntervallChain(int[] values)
        {
            intervalls = new Intervall[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                intervalls[i] = new Intervall(values[i], values[i + 1]); 
            }
        }

        #region Properties

        public Intervall[] Intervalls
        {
            get
            {
                return intervalls;
            }
        }

        #endregion

        #region Operators

        public static implicit operator Intervall[](IntervallChain chain)
        {
            return chain.Intervalls;
        }

        #endregion
    }
}
