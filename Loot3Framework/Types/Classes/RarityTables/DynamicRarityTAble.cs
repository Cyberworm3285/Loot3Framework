using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.RarityTables
{
    /// <summary>
    /// Seltenheits-Referenztabelle, die während der Laufzeit initialisiert wird (nicht-fix / unsicher)
    /// </summary>
    /// <seealso cref="ILootRarityTable"/>
    /// <seealso cref="DefaultRarityTable"/>
    /// <seealso cref="RarityForwardTable"/>
    public class DynamicRarityTable : ILootRarityTable
    {
        private string[] rarNames;
        private IntervallChain innerChain;
        /// <summary>
        /// Konstruktor, der die Namen und deren Wertebereiche initialisiert
        /// </summary>
        /// <param name="_rarNames">Die Namen</param>
        /// <param name="_chain">Die Wertebereiche</param>
        public DynamicRarityTable(string[] _rarNames, IntervallChain _chain)
        {
            SetValues(_rarNames, _chain);
        }
        /// <summary>
        /// Methode, die die Namen und deren Wertebereiche initialisiert
        /// </summary>
        /// <param name="_rarNames">Die Namen</param>
        /// <param name="_chain">Die Wertebereiche</param>
        public void SetValues(string[] _rarNames, IntervallChain _chain)
        {
            rarNames = _rarNames;
            innerChain = _chain;
        }
        /// <summary>
        /// Gibt den entsprechenden <see cref="string"/> zur Seltenheit aus
        /// </summary>
        /// <param name="rarity">Die zu konvertierende Seltenheitswert</param>
        /// <returns>Der entsprechende Name</returns>
        public string ToRarityName(int rarity)
        {
            int index = Array.FindIndex(Chain.Intervalls, i => i.X <= rarity && i.Y >= rarity);
            return Values[index];
        }
        /// <summary>
        /// Seltenheits-Wertebereiche
        /// </summary>
        public IntervallChain Chain
        {
            get { return innerChain; }
        }
        /// <summary>
        /// Seltenheits-Namen
        /// </summary>
        public string[] Values
        {
            get { return rarNames; }
        }
    }
}
