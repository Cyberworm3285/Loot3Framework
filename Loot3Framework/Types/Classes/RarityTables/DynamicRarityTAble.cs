using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.RarityTables
{
    public class DynamicRarityTable : ILootRarityTable
    {
        protected string[] rarNames;
        protected IntervallChain innerChain;

        public DynamicRarityTable(string[] _rarNames, IntervallChain _chain)
        {
            SetValues(_rarNames, _chain);
        }

        public void SetValues(string[] _rarNames, IntervallChain _chain)
        {
            rarNames = _rarNames;
            innerChain = _chain;
        }

        public string ToRarityName(int rarity)
        {
            int index = Array.FindIndex(Chain.Intervalls, i => i.X <= rarity && i.Y >= rarity);
            return Values[index];
        }

        public IntervallChain Chain
        {
            get { return innerChain; }
        }

        public string[] Values
        {
            get { return rarNames; }
        }
    }
}
