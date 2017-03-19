using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Structs
{
    [Serializable]
    public struct IntervallChain
    {
        private Intervall[] intervalls { get; set; }

        public IntervallChain(int[] values, int? startValue = null, int? endValue = null)
        {
            List<int> temp = new List<int>();

            if (startValue != null)
                temp.Add(startValue.GetValueOrDefault());

            temp.AddRange(values);

            if (endValue != null)
                temp.Add(endValue.GetValueOrDefault());

            intervalls = new Intervall[temp.Count- 1];
            for (int i = 0; i < temp.Count - 1; i++)
            {
                intervalls[i] = new Intervall(temp[i], temp[i + 1]);
            }
        }

        public override string ToString()
        {
            return "{" + string.Join("," , intervalls.Select(i => i.ToString()).ToArray()) + "}";
        }

        #region Properties

        public Intervall[] Intervalls
        {
            get
            {
                return intervalls;
            }
            set
            {
                intervalls = value;
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
