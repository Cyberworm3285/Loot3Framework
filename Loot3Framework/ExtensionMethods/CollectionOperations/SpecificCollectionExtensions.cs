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
    /// <seealso cref="CollectionExtensions"/>
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
        /// <seealso cref="CollectionExtensions.Fuse{T1, T2}(T1[], T2[])"/>
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
        /// <summary>
        /// Spaltet ein trennbares <see cref="FusionContainer{T1, T2}"/> <see cref="IEnumerable"/> in seine Bestandteile auf
        /// </summary>
        /// <typeparam name="T1">Typ 1</typeparam>
        /// <typeparam name="T2">Typ 2</typeparam>
        /// <param name="f">Das erweiterte Objekt</param>
        /// <param name="t1">Output des ersten Bestandteils</param>
        /// <param name="t2">Output des zweiten Bestandteils</param>
        /// <seealso cref="CollectionExtensions.Fuse{T1, T2}(T1[], T2[])"/>
        public static void DeFuse<T1, T2>(this IEnumerable<FusionTuple<T1, T2>> f, out T1[] t1, out T2[] t2)
        {
            int temp = f.Count();
            t1 = new T1[temp];
            t2 = new T2[temp];
            IEnumerator<FusionTuple<T1, T2>> enu = f.GetEnumerator();
            temp = 0;
            while (enu.MoveNext())
            {
                t1[temp] = enu.Current.Item1;
                t2[temp++] = enu.Current.Item2;
            }
        }

        #endregion
    }
}
