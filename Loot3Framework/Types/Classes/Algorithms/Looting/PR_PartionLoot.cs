using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Global;
using Loot3Framework.Types.Structs;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.Types.Classes.Comperators;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    public class PR_PartionLoot<T, TLooter> : ILootingAlgorithm<T> where TLooter : ILootingAlgorithm<T>
    {
        protected ILootRarityTable rarTable;
        protected double lastProp;
        protected int lastRandomRoll;
        protected Intervall lastEntireRarRange;
        protected Intervall lastRarRange;
        protected string lastRarName;
        protected TLooter lastLootingAlgorithm;

        public PR_PartionLoot(ILootRarityTable table, TLooter innerLooting, string[] allowedRarityNames)
        {
            lastLootingAlgorithm = innerLooting;
            allowedRarityNames = allowedRarityNames.DoWith(s => Array.Sort(s, new RarTableOrderComperator(table)));
            List<string> allowedNames = new List<string>();
            List<int> allowedRanges = new List<int>();
            int counter = 0;

            for (int i = 0; i < table.Values.Length; i++)
            {
                if (allowedRarityNames.Contains(table.Values[i]))
                {
                    counter += table.Chain.Intervalls[i].Range;
                    allowedRanges.Add(counter);
                    allowedNames.Add(table.Values[i]);
                }
            }
            rarTable = new DynamicRarityTable(allowedNames.ToArray(), new IntervallChain(allowedRanges.ToArray(), startValue: 0));
        }

        public PR_PartionLoot(ILootRarityTable table, TLooter innerLooting)
        {
            lastLootingAlgorithm = innerLooting;
            rarTable = table;
        }

        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            int lowest = rarTable.Chain.Intervalls.First().X;
            int highest = rarTable.Chain.Intervalls.Last().Y;
            lastEntireRarRange = new Intervall(lowest, highest);
            lastRandomRoll = GlobalRandom.Next(lowest + 1, highest + 1);
            int intervallIndex = Array.FindIndex(rarTable.Chain.Intervalls, i => i.X <= lastRandomRoll && i.Y >= lastRandomRoll);
            lastRarRange = rarTable.Chain.Intervalls[intervallIndex];
            lastProp = 100 / (double)(highest - lowest) * (double)lastRarRange.Range;
            lastRarName = rarTable.Values[intervallIndex];
            return lastLootingAlgorithm.Loot(allLoot.Where(i => i.Rarity > lastRarRange.X && i.Rarity <= lastRarRange.Y).ToArray());
        }

        public ILootRarityTable Table
        {
            get { return rarTable; }
            set { rarTable = value; }
        }

        public double LastProbability
        {
            get { return lastProp; }
        }

        public int LastRoll
        {
            get { return lastRandomRoll; }
        }

        public Intervall LastRarityRange
        {
            get { return lastRarRange; }
        }

        public string LastRarity
        {
            get { return lastRarName; }
        }

        public TLooter InnerAlgorithm
        {
            get { return lastLootingAlgorithm; }
        }
    }
}
