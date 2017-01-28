using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    public class RandomLoot : ILootingAlgorithm
    {
        public ILootable Loot(ILootable[] allLoot)
        {
            return allLoot[GlobalRandom.Next(0, allLoot.Length)];
        }
    }
}
