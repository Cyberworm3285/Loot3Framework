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
    /// Eine auf <see cref="string"/>s basierende Item-Eigenschaft, die zufällig einen <see cref="string"/>
    /// auswählt und daraus einen Wert generiert 
    /// </summary>
    /// <seealso cref="IItemProperty{T}"/>
    /// <seealso cref="MultiIntervallProp"/>
    /// <seealso cref="NameOnlyProp"/>
    /// <seealso cref="RandomMultiProp{T}"/>
    public class SingleIntervallProp : IItemProperty<string>
    {
        private Intervall intervall;
        private string[] propNames;
        /// <summary>
        /// Konstruktor, der die <see cref="string"/> Werte und das mögliche <see cref="Intervall"/> setzt
        /// </summary>
        /// <param name="_propNames">Die <see cref="string"/>-Werte</param>
        /// <param name="_intervall">Der Wertebereich</param>
        public SingleIntervallProp(string[] _propNames, Intervall _intervall)
        {
            intervall = _intervall;
            propNames = _propNames;
        }
        /// <summary>
        /// Konstruktor, der den <see cref="string"/> Wert und das mögliche <see cref="Intervall"/> setzt
        /// </summary>
        /// <param name="_propName">Der <see cref="string"/>-Wert</param>
        /// <param name="_intervall">Der Wertebereich</param>
        public SingleIntervallProp(string _propName, Intervall _intervall)
        {
            intervall = _intervall;
            propNames = new string[] { _propName };
        }
        /// <summary>
        /// Sucht sich einen <see cref="string"/>-Wert und generiert mit dem Wertebereich einen Output
        /// </summary>
        /// <returns>Die generierte Eigenschaft</returns>
        public string Generate()
        {
            return propNames[GlobalRandom.Next(0, propNames.Length)] + "(" + intervall.Rand() + ")";
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
        /// Ruft die Generate() Funktion auf und gibt das Ergebnis aus
        /// </summary>
        /// <returns>Das generierte Ergebnis</returns>
        public static implicit operator string(SingleIntervallProp s)
        {
            return s.Generate();
        }
    }
}
