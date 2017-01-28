using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.Filter
{
    public class StandardNCSFilter : ILootFilter
    {
        private string nameContains;
        private string typeContains;
        private string rarityName;
        private int rarityLowerBound;
        private int rarityUpperBound;

        public StandardNCSFilter(string _nameContains, string _typeContains, string _rarityName, int _rarityLowerBound, int _rarityUpperBound)
        {
            nameContains = _nameContains;
            typeContains = _typeContains;
            rarityName = _rarityName;
            rarityLowerBound = _rarityLowerBound;
            rarityUpperBound = _rarityUpperBound;
        }

        public ILootable[] Filter(ILootable[] allLoot)
        {
            return allLoot.Where(l => 

                (l.Name.ToUpper().Contains(nameContains.ToUpper()) || (nameContains == "")) &&
                (l.Type.ToUpper().Contains(typeContains.ToUpper()) || (typeContains == "")) &&
                ((l.RarityName.ToUpper() == rarityName) || (rarityName == "")) &&
                ((l.Rarity >= rarityLowerBound && l.Rarity <= rarityUpperBound) || (rarityLowerBound == 0 && rarityUpperBound == 0))
                
                ).ToArray();
        }
    }
}
