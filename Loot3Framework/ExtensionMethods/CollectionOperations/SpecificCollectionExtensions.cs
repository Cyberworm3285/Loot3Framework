using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Classes.HelperClasses;

namespace Loot3Framework.ExtensionMethods.CollectionOperations
{
    public static class SpecificCollectionExtensions
    {
        #region FusionContainer[]

        public static void DeFuse<T1, T2>(this FusionContainer<T1, T2>[] f, out T1[] t1, out T2[] t2)
        {
            t1 = new T1[f.Length];
            t2 = new T2[f.Length];
            for (int i = 0; i < f.Length; i++)
            {
                t1[i] = f[i].Item1;
                t2[i] = f[i].Item2;
            }
        }

        #endregion
    }
}
