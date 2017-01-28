using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Enums;
using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.Filter
{
    public class ConfigurableFilter : ILootFilter
    {
        private string nameContains;
        private string typeContains;
        private string rarityName;
        private int rarityLowerBound;
        private int rarityUpperBound;
        private StringComparing[] modes;

        public ConfigurableFilter(
            StringComparing _modeName = StringComparing.NonCaseSensitiveInclude, 
            StringComparing _modeType = StringComparing.NonCaseSensitiveInclude, 
            StringComparing _modeRarity = StringComparing.NonCaseSensitiveInclude, 
            string _nameContains = "", string _typeContains = "", string _rarityName= "", 
            int _rarityLowerBound = 0, int _rarityUpperBound = 1000)
        {
            modes = new StringComparing[] { _modeName, _modeType, _modeRarity };
            nameContains = _nameContains;
            typeContains = _typeContains;
            rarityName = _rarityName;
            rarityLowerBound = _rarityLowerBound;
            rarityUpperBound = _rarityUpperBound;
        }

        public ILootable[] Filter(ILootable[] allLoot)
        {
            return allLoot.Where(l =>

            ((l.Name.CompareToString(nameContains,      modes[0]))  || (nameContains == ""))    &&
            ((l.Type.CompareToString(typeContains,      modes[1]))  || (typeContains == ""))    &&
            ((l.RarityName.CompareToString(rarityName,  modes[2]))  || (rarityName == ""))      &&
            ((l.Rarity >= rarityLowerBound && l.Rarity <= rarityUpperBound) || (rarityLowerBound == 0 && rarityUpperBound == 0))

            ).ToArray();
        }
    }
}
