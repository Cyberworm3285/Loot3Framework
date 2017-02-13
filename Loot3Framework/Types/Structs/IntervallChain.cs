using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.ExtensionMethods.CollectionOperations;

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

        public IntervallChain(int[] values, int startValue)
        {
            intervalls = new Intervall[values.Length];
            intervalls[0] = new Intervall(startValue, values.First());
            for (int i = 0; i < values.Length - 1; i++)
            {
                intervalls[i+1] = new Intervall(values[i], values[i + 1]);
            }
        }

        public override string ToString()
        {
            return "{" + string.Join("," , intervalls.DoFunc(i => i.ToString())) + "}";
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
