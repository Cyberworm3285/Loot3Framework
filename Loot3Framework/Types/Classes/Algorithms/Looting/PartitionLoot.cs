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
    
    public class PartitionLoot<T> : ILootingAlgorithm<T>
    {
        private static PartitionLoot<T> instance;

        protected int lastRandomRoll;
        protected int lastEntireRange;
        protected IntervallChain lastInnerChain;
        protected Intervall lastUsedIntervall;
        protected string[] allLastItemNames;
        protected int[] allLastItemRarities;

        private PartitionLoot() { }

        ///<exception cref="NoMatchingLootException">at empty input</exception>
        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            int counter = 0;
            int j = 0;
            allLastItemNames = new string[allLoot.Length];
            allLastItemRarities = new int[allLoot.Length];
            lastInnerChain = new IntervallChain((allLoot.DoFunc(l => {
                allLastItemNames[j] = l.Name;
                allLastItemRarities[j++] = l.Rarity;
                return counter += l.Rarity;
            })).ToArray(), 0);
            lastEntireRange = counter;
            lastRandomRoll = GlobalRandom.Next(0, counter);
            int index = Array.FindIndex(lastInnerChain.Intervalls, i => i.X <= lastRandomRoll && i.Y >= lastRandomRoll);
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

        public string[] LastItemNames
        {
            get { return allLastItemNames; }
        }

        public int[] LastItemRarities
        {
            get { return allLastItemRarities; }
        }

        public static PartitionLoot<T> SharedInstance
        {
            get { return instance ?? (instance = new PartitionLoot<T>()); }
        }
    }
}
