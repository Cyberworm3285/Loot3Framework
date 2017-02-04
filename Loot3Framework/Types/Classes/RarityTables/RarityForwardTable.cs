using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.RarityTables
{
    public class RarityForwardTable : ILootRarityTable
    {
        string fixRarity;

        public RarityForwardTable(string _fixRarity)
        {
            fixRarity = _fixRarity;
        }

        public string ToRarityName(int rarity)
        {
            return fixRarity;
        }

        #region Properties

        public IntervallChain Chain
        {
            get
            {
                return new IntervallChain(new int[] { int.MinValue, int.MaxValue });
            }
        }

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
