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
    /// Satndard Seltenheits-Referenztabelle mit vorinititalisierten Werten (fix)
    /// </summary>
    /// <seealso cref="ILootRarityTable"/>
    /// <seealso cref="DynamicRarityTable"/>
    /// <seealso cref="RarityForwardTable"/>
    public class DefaultRarityTable : ILootRarityTable
    {
        private IntervallChain innerChain = new IntervallChain(new int[] { 0, 10, 100, 400, 1000 });
        private string[] rarNames = new string[] { "Legendär", "Epic", "Selten", "Normal" };
        private static DefaultRarityTable instance;

        private DefaultRarityTable() { }

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

        #region Properties
        /// <summary>
        /// Seltenheits-Wertebereiche
        /// </summary>
        public IntervallChain Chain
        {
            get
            {
                return innerChain;
            }
        }
        /// <summary>
        /// Seltenheits-Namen
        /// </summary>
        public string[] Values
        {
            get
            {
                return rarNames;
            }
        }
        /// <summary>
        /// Satndard-Instanz
        /// </summary>
        public static DefaultRarityTable SharedInstance
        {
            get
            {
                return instance ?? (instance = new DefaultRarityTable());
            }
        }

        #endregion
    }
}
