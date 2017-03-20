using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.ExtensionMethods.Other
{
    /// <summary>
    /// Verschiedene Arten und Weisen, zwei <see cref="string"/>s zu vergleichen
    /// </summary>
    public enum StringComparing
    {
        /// <summary>
        /// <see cref="string"/>1 muss <see cref="string"/>2 beinhalten, Groß- und Kleinschreibung wird beachtet
        /// </summary>
        CaseSensitiveInclude,
        /// <summary>
        /// <see cref="string"/>1 muss <see cref="string"/>2 beinhalten, Groß- und Kleinschreibung wird nicht beachtet
        /// </summary>
        NonCaseSensitiveInclude,
        /// <summary>
        /// <see cref="string"/>1 muss gleich <see cref="string"/>2 sein, Groß- und Kleinschreibung wird beachtet
        /// </summary>
        CaseSensitiveEqual,
        /// <summary>
        /// <see cref="string"/>1 muss gleich <see cref="string"/>2 sein, Groß- und Kleinschreibung wird nicht beachtet
        /// </summary>
        NonCaseSensitiveEqual
    }
    /// <summary>
    /// Extension Methods zum vergleichen von Objekten
    /// </summary>
    public static class Comparision
    {
        /// <summary>
        /// Vergleicht zwei <see cref="string"/>s abhängig vom weiteren Input
        /// </summary>
        /// <param name="a">Das erweiterte Objekt</param>
        /// <param name="b">Der zweite <see cref="string"/></param>
        /// <param name="mode">Die Vergleichsparameter</param>
        /// <returns>Ja wenn alle Anforderungen erfüllt sind</returns>
        public static bool CompareToString(this string a, string b, StringComparing mode)
        {
            a = a ?? "";
            b = b ?? "";
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
