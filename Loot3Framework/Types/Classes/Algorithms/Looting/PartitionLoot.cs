using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;
using Loot3Framework.Global;
using Loot3Framework.Types.Exceptions;
using Loot3Framework.ExtensionMethods.ArrayOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    [CLSCompliant(true)]
    public class PartitionLoot : ILootingAlgorithm
    {
        public ILootable Loot(ILootable[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            int counter = 0;
            IntervallChain chain = new IntervallChain((allLoot.DoFunc(l => counter += l.Rarity)).ToArray(), 0);
            int rdm = GlobalRandom.Next(0, counter);
            return allLoot[Array.FindIndex(chain.Intervalls, i => i.X <= rdm && i.Y > rdm)];
        }
    }
}
