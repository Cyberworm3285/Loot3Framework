using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Loot3Framework.ExtensionMethods.CollectionOperations
{
    [CLSCompliant(true)]
    public static class CollectionExtensions
    {
        #region DoFunc
        /// <summary>
        /// Wndet auf den gesamten Array die angegebene Funktion an
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="t"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult[] DoFunc<T, TResult>(this T[] t, Func<T, TResult> func)
        {
            TResult[] result = new TResult[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                result[i] = func(t[i]);
            }
            return result;
        }

        public static TResult[] DoFunc<TResult>(this IEnumerable e, Func<object, TResult> func) where TResult : class
        {
            List<TResult> result = new List<TResult>();
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                result.Add(func(enumerator.Current));
            }
            return result.ToArray();
        }

        public static TResult[] DoFunc<T, TResult>(this IEnumerable<T> e, Func<T, TResult> func) where TResult : class
        {
            List<TResult> result = new List<TResult>();
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(func(enumerator.Current));
            }
            return result.ToArray();
        }

        public static List<TResult> DoConditionalFunc<T, TResult>(this T[] t, Func<T, TResult> func, Func<T, bool> condition)
        {
            List<TResult> result = new List<TResult>();
            for (int i = 0; i < t.Length; i++)
            {
                if (condition(t[i]))
                    result.Add(func(t[i]));
            }
            return result;
        }

        public static List<TResult> DoConditionalFunc<TResult>(this IEnumerable e, Func<object, TResult> func, Func<object, bool> condition) where TResult : class
        {
            List<TResult> result = new List<TResult>();
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                    result.Add(func(enumerator.Current));
            }
            return result;
        }

        public static List<TResult> DoConditionalFunc<T, TResult>(this IEnumerable<T> e, Func<T, TResult> func, Func<T, bool> condition) where TResult : class
        {
            List<TResult> result = new List<TResult>();
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                    result.Add(func(enumerator.Current));
            }
            return result;
        }

        #endregion

        #region DoAction

        public static void DoAction<T>(this T[] t, Action<T> action)
        {
            Array.ForEach(t, action);
        }

        public static void DoAction(this IEnumerable e, Action<object> action)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }

        public static void DoAction<T>(this IEnumerable<T> e, Action<T> action)
        {
            IEnumerator<T> enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }

        public static void DoConditionalAction<T>(this T[] t, Action<T> action, Func<T, bool> condition)
        {
            foreach (T tt in t)
                if (condition(tt))
                    action(tt);
        }

        public static void DoConditionalAction(this IEnumerable e, Action<object> action, Func<object, bool> condition)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                    action(enumerator.Current);
            }
        }

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

        #region Do

        public static T Do<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }

        #endregion

        #region ChainUp

        public static T[] ChainUp<T>(this T[][] t)
        {
            List<T> result = new List<T>();
            t.DoAction(tt => result.AddRange(tt));
            return result.ToArray();
        }

        public static TResult ChainUpToCollection<T, TResult>(this T[][] t) where TResult : ICollection<T>, new()
        {
            TResult result = new TResult();
            t.DoAction(tt => tt.DoAction(ttt => result.Add(ttt)));
            return result;
        }

        public static TResult ChainUpToCollection<T, TResult>(this ICollection<ICollection<T>> c) where TResult : ICollection<T>, new()
        {
            TResult result = new TResult();
            IEnumerator<ICollection<T>> enumerator = c.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IEnumerator<T> enumerator2 = enumerator.Current.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    result.Add(enumerator2.Current);
                }
            }
            return result;
        }

        #endregion

        #region RemoveIf

        public static T[] RemoveIf<T>(this T[] t, Func<T, bool> condition)
        {
            List<T> result = new List<T>();
            t.DoConditionalAction(tt => result.Add(tt), tt => condition(tt));
            return result.ToArray();
        }

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

        public static bool HasItemWhere<T>(this T[] t, Func<T, bool> condition)
        {
            return !t.All(tt => condition(tt));
        }

        public static bool HasItemWhere(this IEnumerable e, Func<object, bool> condition)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current)) return true;
            }
            return false;
        }

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
    }
}
