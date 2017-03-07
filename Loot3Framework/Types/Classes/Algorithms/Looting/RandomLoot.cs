using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Global;
using Loot3Framework.Types.Exceptions;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    
    public class RandomLoot<T> : ILootingAlgorithm<T>
    {
        ///<exception cref="NoMatchingLootException">at empty input</exception>
        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            return allLoot[GlobalRandom.Next(0, allLoot.Length)];
        }
    }
}
