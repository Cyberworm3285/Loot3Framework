using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    /// <summary>
    /// Eine auf <see cref="string"/>s basierende Item-Eigenschaft, die einen hardcecodeten Output besitzt
    /// </summary>
    /// <seealso cref="IItemProperty{T}"/>
    /// <seealso cref="MultiIntervallProp"/>
    /// <seealso cref="RandomMultiProp{T}"/>
    /// <seealso cref="SingleIntervallProp"/>
    public class NameOnlyProp : IItemProperty<string>
    {
        private string name;
        /// <summary>
        /// Konstruktor, der direkt den finalen Output setzt
        /// </summary>
        /// <param name="_name">Der finale Output</param>
        public NameOnlyProp(string _name)
        {
            name = _name;
        }
        /// <summary>
        /// Ruft die Generate() Funktion auf und gibt das Ergebnis aus
        /// </summary>
        /// <returns>Das generierte Ergebnis</returns>
        public override string ToString()
        {
            return Generate();
        }
        /// <summary>
        /// Gibt den Initialwert wieder aus
        /// </summary>
        /// <returns>Den hardgecodete Output</returns>
        public string Generate()
        {
            return name;
        }
        /// <summary>
        /// Ruft die Generate() Funktion auf und gibt das Ergebnis aus
        /// </summary>
        /// <returns>Das generierte Ergebnis</returns>
        public static implicit operator string(NameOnlyProp n)
        {
            return n.Generate();
        }
    }
}
