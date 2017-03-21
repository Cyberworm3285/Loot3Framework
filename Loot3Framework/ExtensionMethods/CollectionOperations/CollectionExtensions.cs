using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using System.Collections;

using Loot3Framework.Types.Classes.HelperClasses;
using Loot3Framework.Types.Exceptions;

namespace Loot3Framework.ExtensionMethods.CollectionOperations
{
    /// <summary>
    /// Alle allgemeinen Extensions für <see cref="ICollection"/>s, <see cref="IEnumerable"/>s und natürlich <see cref="Array"/>s
    /// </summary>
    /// <seealso cref="SpecificCollectionExtensions"/>
    public static class CollectionExtensions
    {
        #region DoAction
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        public static void DoAction<T>(this T[] t, Action<T> action) => Array.ForEach(t, action);
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus
        /// </summary>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        public static void DoAction(this IEnumerable e, Action<object> action)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        public static void DoAction<T>(this IEnumerable<T> e, Action<T> action)
        {
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus, wenn die Bedingung erfüllt ist
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        /// <param name="condition">Die Bedingung zum ausführen</param>
        public static void DoConditionalAction<T>(this T[] t, Action<T> action, Func<T, bool> condition)
        {
            foreach (T tt in t)
                if (condition(tt))
                    action(tt);
        }
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus, wenn die Bedingung erfüllt ist
        /// </summary>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        /// <param name="condition">Die Bedingung zum ausführen</param>
        public static void DoConditionalAction(this IEnumerable e, Action<object> action, Func<object, bool> condition)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                    action(enumerator.Current);
            }
        }
        /// <summary>
        /// Führt mit allen Elementen die angegebene <see cref="Action"/> aus, wenn die Bedingung erfüllt ist
        /// </summary>
        /// <typeparam name="T">der erweiterte Typ</typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="action">Die auszführende Aktion</param>
        /// <param name="condition">Die Bedingung zum ausführen</param>
        public static void DoConditionalAction<T>(this IEnumerable<T> e, Action<T> action, Func<T, bool> condition)
        {
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                    action(enumerator.Current);
            }
        }

        #endregion

        #region DoWith
        /// <summary>
        /// Führt mit dem Objekt die angegebene Aktion durch und gibt dieses wieder zurück
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="action">Die auszuführende Aktion</param>
        /// <returns></returns>
        public static T DoWith<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }

        #endregion

        #region ChainUp
        /// <summary>
        /// Fügt alle Elemente der Auflistungen zu einer Auflistung zusammen
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <returns>Die Verkettung aller Elemente</returns>
        public static T[] ChainUp<T>(this T[][] t)
        {
            List<T> result = new List<T>();
            t.DoAction(tt => result.AddRange(tt));
            return result.ToArray();
        }
        /// <summary>
        /// Erstellt die angegebene <see cref="ICollection"/> und fügt alle Elemente der Auflistungen hinzu
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <typeparam name="TResult">Der Typ der <see cref="ICollection"/></typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <returns>Die Verkettung aller Elemente</returns>
        public static TResult ChainUpToCollection<T, TResult>(this T[][] t) where TResult : ICollection<T>, new()
        {
            TResult result = new TResult();
            t.DoAction(tt => tt.DoAction(ttt => result.Add(ttt)));
            return result;
        }
        ///// <summary>
        ///// Fügt alle Elemente der Auflistungen zur angegebenen <see cref="ICollection"/> hinzu
        ///// </summary>
        ///// <typeparam name="T">Der erweiterte Typ</typeparam>
        ///// <typeparam name="TResult">Der Typ der <see cref="ICollection"/></typeparam>
        ///// <param name="c">Das erweiterte Objekt</param>
        ///// <returns>Die Verkettung aller Elemente</returns>
        //public static TResult ChainUpToCollection<T, TResult>(this ICollection<ICollection<T>> c) where TResult : ICollection<T>, new()
        //{
        //    TResult result = new TResult();
        //
        //    foreach (ICollection<T> t in c)
        //    {
        //        foreach (T tt in t)
        //        {
        //            result.Add(tt);
        //        }
        //    }
        //
        //    return result;
        //}
        /// <summary>
        /// Fügt alle Elemente der Auflistungen zur angegebenen <see cref="ICollection"/> hinzu
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <typeparam name="TResult">Der Typ der <see cref="ICollection"/></typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <returns>Die Verkettung aller Elemente</returns>
        public static TResult ChainUpToCollection<T, TResult>(this IEnumerable<IEnumerable<T>> e) where TResult : ICollection<T>, new()
        {
            TResult result = new TResult();
            IEnumerator<IEnumerable<T>> enu1 = e.GetEnumerator();
            while (enu1.MoveNext())
            {
                IEnumerator<T> enu2 = enu1.Current.GetEnumerator();
                while (enu2.MoveNext())
                {
                    result.Add(enu2.Current);
                }
            }
            return result;
        }

        #endregion

        #region RemoveIf
        /// <summary>
        /// Gibt einen Array ohne die Objekte, die die Bedingung erfüllen, zurück
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="condition">Die Bedingung zum Entfernen</param>
        /// <returns>Den Array ohne die passenden Objekte</returns>
        public static T[] RemoveIf<T>(this T[] t, Func<T, bool> condition)
        {
            List<T> result = new List<T>();
            t.DoConditionalAction(tt => result.Add(tt), tt => !condition(tt));
            return result.ToArray();
        }
        /// <summary>
        /// Gibt eine <see cref="ICollection"/> ohne die Objekte, die die Bedingung erfüllen, zurück
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="c">Das erweiterte Objekt</param>
        /// <param name="condition">Die Bedingung zum Entfernen</param>
        /// <returns>Die <see cref="ICollection"/> ohne die passenden Objekte</returns>
        public static ICollection<T> RemoveIf<T>(this ICollection<T> c, Func<T, bool> condition)
        {
            List<T> temp = c.ToList();
            List<T> result = new List<T>();
            temp.ForEach(t => { if (!condition(t)) result.Add(t); });
            c.Clear();
            result.ForEach(r => c.Add(r));

            return c;
        }

        #endregion

        #region HasItemWhere
        /// <summary>
        /// Zeigt an, ob ein Element mit den angegebenen Paramtetern vorhanden ist
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="condition">Die Paramter</param>
        /// <returns>Ja oder Nein halt</returns>
        public static bool HasItemWhere<T>(this T[] t, Func<T, bool> condition) => !t.All(tt => condition(tt));
        /// <summary>
        /// Zeigt an, ob ein Element mit den angegebenen Paramtetern vorhanden ist
        /// </summary>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="condition">Die Paramter</param>
        /// <returns>Ja oder Nein halt</returns>
        public static bool HasItemWhere(this IEnumerable e, Func<object, bool> condition)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current)) return true;
            }
            return false;
        }
        /// <summary>
        /// Zeigt an, ob ein Element mit den angegebenen Paramtetern vorhanden ist
        /// </summary>
        /// <typeparam name="T">Der erweiterte Typ</typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="condition">Die Paramter</param>
        /// <returns>Ja oder Nein halt</returns>
        public static bool HasItemWhere<T>(this IEnumerable<T> e, Func<T, bool> condition)
        {
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current)) return true;
            }
            return false;
        }


        #endregion

        #region SumUp
        /// <summary>
        /// Fügt Alle Elemente anhand des Converters und des Adders zu einem Element zusammen
        /// </summary>
        /// <typeparam name="TIn">Der Ausgangs-Typ</typeparam>
        /// <typeparam name="TOut">Der resultierende Typ</typeparam>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <param name="converter">Converter von TIn zu TOut</param>
        /// <param name="adder">Fügt zwei TOut Elemente zu einem zusammen</param>
        /// <returns>Alle Elemente als eins zusammengefügt</returns>
        /// <example>
        /// <code>
        /// Console.WriteLine(new int[] { 1, 2, 3 }.SumUp((i) => i.ToString(), (i1, i2) => i1 + ", " + i2));
        /// //output: 1, 2, 3
        /// </code>
        /// </example>
        public static TOut SumUp<TIn, TOut>(this TIn[] t, Converter<TIn, TOut> converter, Func<TOut, TOut, TOut> adder)
        {
            TOut result = converter(t.First());
            for (int i = 1; i < t.Length; i++)
            {
                result = adder(result, converter(t[i]));
            }
            return result;
        }
        /// <summary>
        /// Fügt Alle Elemente anhand des Converters und des Adders zu einem Element zusammen
        /// </summary>
        /// <typeparam name="TOut">Der resultierende Typ</typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="converter">Converter von TIn zu TOut</param>
        /// <param name="adder">Fügt zwei TOut Elemente zu einem zusammen</param>
        /// <returns>Alle Elemente als eins zusammengefügt</returns>
        public static TOut SumUp<TOut>(this IEnumerable e, Converter<object, TOut> converter, Func<TOut, TOut, TOut> adder)
        {
            IEnumerator enumerator = e.GetEnumerator();
            enumerator.MoveNext();
            TOut result = converter(enumerator.Current);
            while (enumerator.MoveNext())
            {
                result = adder(result, converter(enumerator.Current));
            }

            return result; 
        }
        /// <summary>
        /// Fügt Alle Elemente anhand des Converters und des Adders zu einem Element zusammen
        /// </summary>
        /// <typeparam name="TIn">Der Ausgangs-Typ</typeparam>
        /// <typeparam name="TOut">Der resultierende Typ</typeparam>
        /// <param name="e">Das erweiterte Objekt</param>
        /// <param name="converter">Converter von TIn zu TOut</param>
        /// <param name="adder">Fügt zwei TOut Elemente zu einem zusammen</param>
        /// <returns>Alle Elemente als eins zusammengefügt</returns>
        public static TOut SumUp<TIn, TOut>(this IEnumerable<TIn> e, Converter<TIn, TOut> converter, Func<TOut,TOut,TOut> adder)
        {
            IEnumerator<TIn> enumerator = e.GetEnumerator();
            enumerator.MoveNext();
            TOut result = converter(enumerator.Current);
            while (enumerator.MoveNext())
            {
                result = adder(result, converter(enumerator.Current));
            }

            return result;
        }

        #endregion

        #region Fuse

        /// <summary>
        /// Fusioniert zwei Arrays zu einem teilbaren Container Array
        /// </summary>
        /// <typeparam name="T1">Typ1</typeparam>
        /// <typeparam name="T2">Typ2</typeparam>
        /// <param name="t1">Das erweiterte Objekt</param>
        /// <param name="t2">Der zweite Array</param>
        /// <returns>Einen teilbaren Container Array</returns>
        /// <exception cref="IndexOutOfRangeException">Wenn die Arrays unterschiedlich lang sind</exception>
        /// <example>
        /// <para>
        /// Mit der Bindung zweier Objekte kann man z.B. Änderungen von Positionen in Collections an beiden Objekten gleichzeitig durchführen,
        /// ohne einen eigenen Algorithmus zu schreiben. Hier wird ein <see cref="string"/>-<see cref="Array"/> von mit Zahl-Representationen anhand ihrer
        /// Zahl-Equivalente sortiert (der <see cref="int"/>-<see cref="Array"/>)
        /// </para>
        /// <code>
        /// string[]    aa = new string[]   { "eins", "drei", "zwei", "minus vier" };
        /// int[]       bb = new int[]      { 1,      3,      2,      -4           };
        /// 
        /// aa.Fuse(bb).OrderBy(i => i.Item2).DeFuse(out aa, out bb);
        /// //aa: { "minus vier", "eins", "zwei", "drei" }
        /// //bb: { -4, 1, 2, 3 }
        /// </code>
        /// </example>
        public static FusionTuple<T1, T2>[] Fuse<T1, T2>(this T1[] t1, T2[] t2)
        {
            if (t1.Length != t2.Length)
                throw new IndexOutOfRangeException("uneven array-lengths");
            FusionTuple<T1, T2>[] result = new FusionTuple<T1, T2>[t1.Length];
            for (int i = 0; i < t1.Length; i++)
            {
                result[i] = new FusionTuple<T1, T2>(t1[i], t2[i]);
            }
            return result;
        }
        /// <summary>
        /// Fusioniert zwei <see cref="IEnumerable"/>s zu einem teilbaren Container Array
        /// </summary>
        /// <typeparam name="T1">Typ1</typeparam>
        /// <typeparam name="T2">Typ2</typeparam>
        /// <param name="e1">Das erweiterte Objekt</param>
        /// <param name="e2">Das zweite <see cref="IEnumerable"/></param>
        /// <returns>Einen teilbaren Container Array</returns>
        ///<exception cref="IndexOutOfRangeException">Wenn die Enumerationen unterschiedlich lang sind</exception>
        ///        /// <example>
        /// <para>
        /// Mit der Bindung zweier Objekte kann man z.B. Änderungen von Positionen in Collections an beiden Objekten gleichzeitig durchführen,
        /// ohne einen eigenen Algorithmus zu schreiben. Hier wird ein <see cref="string"/>-<see cref="Array"/> von mit Zahl-Representationen anhand ihrer
        /// Zahl-Equivalente sortiert (der <see cref="int"/>-<see cref="Array"/>)
        /// </para>
        /// <code>
        /// string[]    aa = new string[]   { "eins", "drei", "zwei", "minus vier" };
        /// int[]       bb = new int[]      { 1,      3,      2,      -4           };
        /// 
        /// aa.Fuse(bb).OrderBy(i => i.Item2).DeFuse(out aa, out bb);
        /// //aa: { "minus vier", "eins", "zwei", "drei" }
        /// //bb: { -4, 1, 2, 3 }
        /// </code>
        /// </example>
        public static FusionTuple<T1, T2>[] Fuse<T1, T2>(this IEnumerable<T1> e1, IEnumerable<T2> e2)
        {
            int e1Count = e1.Count();
            if (e1Count != e2.Count())
                throw new IndexOutOfRangeException("uneven enumeration-counts");

            int counter = 0;
            FusionTuple<T1, T2>[] result = new FusionTuple<T1, T2>[e1Count];
            IEnumerator<T1> enu1 = e1.GetEnumerator();
            IEnumerator<T2> enu2 = e2.GetEnumerator();

            while (enu1.MoveNext() && enu2.MoveNext())
            {
                result[counter++] = new FusionTuple<T1, T2>(enu1.Current, enu2.Current);
            }

            return result;
        }
        /// <summary>
        /// Fusioniert zwei <see cref="IEnumerable"/>s zu einem teilbaren Container Array
        /// </summary>
        /// <typeparam name="T1">Typ1</typeparam>
        /// <typeparam name="T2">Typ2</typeparam>
        /// <param name="c1">Das erweiterte Objekt</param>
        /// <param name="c2">Die zweite <see cref="ICollection"/></param>
        /// <returns>Einen teilbaren Container Array</returns>
        ///<exception cref="IndexOutOfRangeException">Wenn die Enumerationen unterschiedlich lang sind</exception>
        ///        /// <example>
        /// <para>
        /// Mit der Bindung zweier Objekte kann man z.B. Änderungen von Positionen in Collections an beiden Objekten gleichzeitig durchführen,
        /// ohne einen eigenen Algorithmus zu schreiben. Hier wird ein <see cref="string"/>-<see cref="Array"/> von mit Zahl-Representationen anhand ihrer
        /// Zahl-Equivalente sortiert (der <see cref="int"/>-<see cref="Array"/>)
        /// </para>
        /// <code>
        /// string[]    aa = new string[]   { "eins", "drei", "zwei", "minus vier" };
        /// int[]       bb = new int[]      { 1,      3,      2,      -4           };
        /// 
        /// aa.Fuse(bb).OrderBy(i => i.Item2).DeFuse(out aa, out bb);
        /// //aa: { "minus vier", "eins", "zwei", "drei" }
        /// //bb: { -4, 1, 2, 3 }
        /// </code>
        /// </example>
        public static FusionTuple<T1, T2>[] Fuse<T1, T2>(this ICollection<T1> c1, ICollection<T2> c2)
        {
            if (c1.Count != c2.Count)
                throw new IndexOutOfRangeException("uneven collection-counts");

            int counter = 0;
            FusionTuple<T1, T2>[] result = new FusionTuple<T1, T2>[c1.Count];
            IEnumerator<T1> enu1 = c1.GetEnumerator();
            IEnumerator<T2> enu2 = c2.GetEnumerator();

            while (enu1.MoveNext() && enu2.MoveNext())
            {
                result[counter++] = new FusionTuple<T1, T2>(enu1.Current, enu2.Current);
            }

            return result;
        }

        #endregion

        #region FuseInto
        /// <summary>
        /// Fusioniert zwei Arrays zu einem ggf. untteilbaren Array eines (uu. neuen Typs)
        /// </summary>
        /// <typeparam name="T1">Typ 1</typeparam>
        /// <typeparam name="T2">Typ 2</typeparam>
        /// <typeparam name="TOut">Der resultierende Typ</typeparam>
        /// <param name="t1">Das erweiterte Objekt</param>
        /// <param name="t2">Der zweite Array</param>
        /// <param name="fusionFunction">Funtion, die angibt wie die beiden Typen fusioniert werden sollen</param>
        /// <returns>Einen ggf. unteilbaren Fusions-Array</returns>
        ///<exception cref="IndexOutOfRangeException">Wenn die Arrays unterschiedlich lang sind</exception>
        public static TOut[] FuseInto<T1, T2, TOut>(this T1[] t1, T2[] t2, Func<T1, T2, TOut> fusionFunction)
        {
            if (t1.Length != t2.Length)
                throw new IndexOutOfRangeException("uneven array lengths");
            TOut[] result = new TOut[t1.Length];

            for (int i = 0; i < t1.Length; i++)
            {
                result[i] = fusionFunction(t1[i], t2[i]);
            }

            return result;
        }
        /// <summary>
        /// Fusioniert zwei <see cref="IEnumerable"/>s zu einem ggf. untteilbaren Array eines (uu. neuen Typs)
        /// </summary>
        /// <typeparam name="T1">Typ 1</typeparam>
        /// <typeparam name="T2">Typ 2</typeparam>
        /// <typeparam name="TOut">Der resultierende Typ</typeparam>
        /// <param name="e1">Das erweiterte Objekt</param>
        /// <param name="e2">Das zweite <see cref="IEnumerable"/></param>
        /// <param name="fusionFunction">Funtion, die angibt wie die beiden Typen fusioniert werden sollen</param>
        /// <returns>Einen ggf. unteilbaren Fusions-Array</returns>
        ///<exception cref="IndexOutOfRangeException">Wenn die Enumerationen unterschiedlich lang sind</exception>
        public static TOut[] FuseInto<T1, T2, TOut>(this IEnumerable<T1> e1, IEnumerable<T2> e2, Func<object, object, TOut> fusionFunction)
        {
            int e1Count = e1.Count();
            if (e1Count != e2.Count())
                throw new IndexOutOfRangeException("uneven enumerator lengths");

            IEnumerator enu1 = e1.GetEnumerator();
            IEnumerator enu2 = e2.GetEnumerator();
            int counter = 0;
            TOut[] result = new TOut[e1Count];

            while (enu1.MoveNext() && enu2.MoveNext())
            {
                result[counter++] = fusionFunction(enu1.Current, enu2.Current);
            }

            return result;
        }

        #endregion
    }
}
