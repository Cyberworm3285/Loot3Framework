using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.RarityTables
{
    [CLSCompliant(true)]
    public class DefaultRarityTable : ILootRarityTable
    {
        protected IntervallChain chain = new IntervallChain(new int[] { 0, 100, 300, 600, 1000 });
        protected string[] rarNames = new string[] { "Legendär", "Epic", "Selten", "Normal" };

        public string ToRarityName(int rarity)
        {
            int index = Array.FindIndex(Chain.Intervalls, i => i.X < rarity && i.Y >= rarity);
            return Values[index];
        }

        #region Properties

        public IntervallChain Chain
        {
            get
            {
                return chain;
            }
        }

        public string[] Values
        {
            get
            {
                return rarNames;
            }
        }

        #endregion
    }
}
