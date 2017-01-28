using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Enums;

namespace Loot3Framework.ExtensionMethods.Other
{
    public static class Comparision
    {
        public static bool CompareToString(this string a, string b, StringComparing mode)
        {
            switch (mode)
            {
                case StringComparing.CaseSensitiveEqual:
                    return (a == b);
                case StringComparing.CaseSensitiveInclude:
                    return a.Contains(b);
                case StringComparing.NonCaseSensitiveEqual:
                    return (a.ToUpper() == b.ToUpper());
                case StringComparing.NonCaseSensitiveInclude:
                    return a.ToUpper().Contains(b.ToUpper());
                default:
                    throw new Exception();
            }
        }
    }
}
