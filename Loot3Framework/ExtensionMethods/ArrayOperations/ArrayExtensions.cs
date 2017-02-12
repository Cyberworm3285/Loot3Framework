using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.ExtensionMethods.ArrayOperations
{
    [CLSCompliant(true)]
    public static class ArrayExtensions
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

        public static void DoAction<T>(this T[] t, Action<T> action)
        {
            foreach (T tt in t) action(tt);
        }
    }
}
