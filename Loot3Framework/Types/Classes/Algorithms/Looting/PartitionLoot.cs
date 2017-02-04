using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    [CLSCompliant(true)]
    public class PartitionLoot : ILootingAlgorithm
    {
        public ILootable Loot(ILootable[] allLoot)
        {
            Intervall[] intervalls = new Intervall[allLoot.Length];
            int prev;
            int curr = 0;
            for (int i = 0; i < allLoot.Length; i++)
            {
                prev = curr;
                curr += allLoot[i].Rarity;
                intervalls[i] = new Intervall(prev, curr);
            }
            int rdm = GlobalRandom.Next(0, curr);
            int index = Array.FindIndex(intervalls, i => i.X <= rdm && i.Y > rdm);

            if (index.Equals(-1))
                throw new Exception();

            return allLoot[index];
        }
    }
}
