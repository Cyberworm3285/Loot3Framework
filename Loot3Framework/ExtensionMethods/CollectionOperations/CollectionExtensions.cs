﻿using System;
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

        public static void DoAction<T>(this T[] t, Action<T> action)
        {
            foreach (T tt in t) action(tt);
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
    }
}