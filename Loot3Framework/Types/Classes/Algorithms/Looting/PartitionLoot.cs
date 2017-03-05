using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;
using Loot3Framework.Global;
using Loot3Framework.Types.Exceptions;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    [CLSCompliant(true)]
    public class PartitionLoot<T> : ILootingAlgorithm<T>
    {
        protected int lastRandomRoll;
        protected int lastEntireRange;
        protected IntervallChain lastInnerChain;
        protected Intervall lastUsedIntervall;

        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            int counter = 0;
            lastInnerChain = new IntervallChain((allLoot.DoFunc(l => counter += l.Rarity)).ToArray(), 0);
            lastEntireRange = counter;
            lastRandomRoll = GlobalRandom.Next(0, counter);
            int index = Array.FindIndex(lastInnerChain.Intervalls, i => i.X <= lastRandomRoll && i.Y > lastRandomRoll);
            lastUsedIntervall = lastInnerChain.Intervalls[index];
            return allLoot[index];
        }

        public int LastRoll
        {
            get { return lastRandomRoll; }
        }

        public int LastOverallRange
        {
            get { return lastEntireRange; }
        }

        public IntervallChain LastChain
        {
            get { return lastInnerChain; }
        }

        public Intervall LastIntervall
        {
            get { return lastUsedIntervall; }
        }
    }
}
