using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks
using System.Collections;

using Loot3Framework.Types.Classes.HelperClasses;

namespace Loot3Framework.ExtensionMethods.CollectionOperations
{
    /// <summary>
    /// Extension Methods für spezifische <see cref="ICollection"/>s, <see cref="IEnumerable"/>s und natürlich <see cref="Array"/>s
    /// </summary>
    public static class SpecificCollectionExtensions
    {
        #region FusionContainer[]
        /// <summary>
        /// Spaltet ein trennbares <see cref="FusionContainer{T1, T2}"/> Array in seine Bestandteile auf
        /// </summary>
        /// <typeparam name="T1">Typ 1</typeparam>
        /// <typeparam name="T2">Typ 2</typeparam>
        /// <param name="f">Das erweiterte Objekt</param>
        /// <param name="t1">Output des ersten Bestandteils</param>
        /// <param name="t2">Output des zweiten Bestandteils</param>
        public static void DeFuse<T1, T2>(this FusionTuple<T1, T2>[] f, out T1[] t1, out T2[] t2)
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
