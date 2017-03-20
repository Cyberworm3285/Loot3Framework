using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Global;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    /// <summary>
    /// Eine auf <see cref="string"/>s basierende Item-Eigenschaft, die zufällig einen <see cref="string"/> und das entsprechende <see cref="Intervall"/> 
    /// auswählt und daraus einen Wert generiert 
    /// </summary>
    /// <seealso cref="IItemProperty{T}"/>
    /// <seealso cref="NameOnlyProp"/>
    /// <seealso cref="RandomMultiProp{T}"/>
    /// <seealso cref="SingleIntervallProp"/>
    public class MultiIntervallProp : IItemProperty<string>
    {
        private string[] names;
        private Intervall[] intervalls;

        /// <summary>
        /// Konstruktor, der <see cref="string"/> Werte und deren <see cref="Intervall"/>e 
        /// </summary>
        /// <param name="_names">Die <see cref="string"/> Werte</param>
        /// <param name="_intervalls">Die entsprechenden <see cref="Intervall"/>e</param>
        /// <exception cref="IndexOutOfRangeException">at uneven array lengths</exception>
        public MultiIntervallProp(string[] _names, Intervall[] _intervalls)
        {
            if (_names.Length != _intervalls.Length)
                throw new IndexOutOfRangeException("uneven array lengths");
            names = _names;
            intervalls = _intervalls;
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
        /// Sucht zufällig einen <see cref="string"/> Wert, dessen <see cref="Intervall"/> und generiert einen Output  
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            int rdm = GlobalRandom.Next(0, names.Length);
            return names[rdm] + "(" + intervalls[rdm].Rand() + ")";
        }
        /// <summary>
        /// Ruft die Generate() Funktion auf und gibt das Ergebnis aus
        /// </summary>
        public static explicit operator string(MultiIntervallProp m)
        {
            return m.Generate();
        }
    }
}
