using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.ExtensionMethods.TypeConversion
{
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
    }
}
