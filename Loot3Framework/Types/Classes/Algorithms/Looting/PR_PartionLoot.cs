using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    public class PR_PartionLoot<T> : ILootingAlgorithm<T>
    {
        protected ILootRarityTable rarTable;
        protected double lastProp;

        public PR_PartionLoot(ILootRarityTable table)
        {
            rarTable = table;
        }

        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            int lowest = rarTable.Chain.Intervalls.First().X;
            int highest = rarTable.Chain.Intervalls.Last().Y;
            int rdm = GlobalRandom.Next(lowest, highest + 1);
            lastProp = rdm;
            string rarName = rarTable.Values[Array.FindIndex(rarTable.Chain.Intervalls, i => i.X < rdm && i.Y >= rdm)];
            Console.WriteLine("->" + rarName);
            return new PartitionLoot<T>().Loot(allLoot.Where(i => i.RarityName == rarName).ToArray());
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
    }
}
