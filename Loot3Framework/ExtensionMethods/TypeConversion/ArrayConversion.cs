using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.ExtensionMethods.TypeConversion
{
    [CLSCompliant(true)]
    public static class ArrayConversion
    {
        public static string[] ToStrings(this IItemProperty[] i)
        {
            string[] result = new string[i.Length];
            for (int j = 0; j < i.Length; j++)
            {
                result[j] = i[j].Generate();
            }
            return result;
        }

        public static string[] ToStrings<T>(this T[] t) where T : struct
        {
            string[] result = new string[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                result[i] = t.ToString();
            }
            return result;
        }
    }
}
