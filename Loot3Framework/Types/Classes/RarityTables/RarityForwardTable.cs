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
    /// Dummy Seltenheits-Referenztabelle, die einen fix-Wert ausgibt
    /// </summary>
    /// <seealso cref="ILootRarityTable"/>
    /// <seealso cref="DefaultRarityTable"/>
    /// <seealso cref="DynamicRarityTable"/>
    public class RarityForwardTable : ILootRarityTable
    {
        private string fixRarity;
        /// <summary>
        /// Konstruktor, der beretis den finalen Output setzt
        /// </summary>
        /// <param name="_fixRarity">Der finale Output</param>
        public RarityForwardTable(string _fixRarity)
        {
            fixRarity = _fixRarity;
        }
        /// <summary>
        /// Gibt den entsprechenden <see cref="string"/> zur Seltenheit aus
        /// </summary>
        /// <param name="rarity">Die zu konvertierende Seltenheitswert</param>
        /// <returns>Der entsprechende Name</returns>
        public string ToRarityName(int rarity)
        {
            return fixRarity;
        }

        #region Properties
        /// <summary>
        /// Seltenheits-Wertebereiche (nur ein <see cref="Intervall"/> vom Minimalwert bis zum Maximalwert von <see cref="int"/>)
        /// </summary>
        public IntervallChain Chain
        {
            get
            {
                return new IntervallChain(new int[] { int.MinValue, int.MaxValue });
            }
        }
        /// <summary>
        /// Seltenheits-Namen (der fix-Wert)
        /// </summary>
        public string[] Values
        {
            get
            {
                return new string[] { fixRarity };
            }
        }

        #endregion

    }
}
