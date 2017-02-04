using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    [CLSCompliant(false)]
    public abstract class BaseLootHolder : IItemHolder
    {
        private ILootable[] allLoot;

        public BaseLootHolder(ILootTypeFetcher fetcher)
        {
            InitLootables(fetcher);
        }

        public void InitLootables(ILootTypeFetcher fetcher)
        {
            Type[] types = fetcher.GetAllLootableTypes();
            allLoot = new ILootable[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                allLoot[i] = types[i].GetInstance() as ILootable;
            }
        }

        public ILootable GetLoot(ILootingAlgorithm algo)
        {
            return algo.Loot(allLoot);
        }

        public ILootable GetLoot(ILootingAlgorithm algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(allLoot));
        }



        #region Properties

        public ILootable[] AllLoot
        {
            get
            {
                return allLoot;
            }
        }

        public string[] AllTypeNames
        {
            get
            {
                List<string> typeNames = new List<string>();
                foreach (ILootable l in allLoot) 
                {
                    if (!typeNames.Contains(l.Type)) typeNames.Add(l.Type);
                }
                return typeNames.ToArray();
            }
        }

        public string[] AllRarityNames
        {
            get
            {
                List<string> rarityNames = new List<string>();
                foreach (ILootable l in allLoot)
                {
                    if (!rarityNames.Contains(l.RarityName)) rarityNames.Add(l.RarityName);
                }
                return rarityNames.ToArray();
            }
        }

        #endregion
    }
}
