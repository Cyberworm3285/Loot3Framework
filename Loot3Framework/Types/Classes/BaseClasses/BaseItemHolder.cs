using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    [CLSCompliant(false)]
    public abstract class BaseLootHolder<T> : IItemHolder<T>
    {
        protected ILootable<T>[] allLoot;

        public BaseLootHolder(ILootTypeFetcher<T> fetcher)
        {
            InitLootables(fetcher);
        }

        public void InitLootables(ILootTypeFetcher<T> fetcher)
        {
            Type[] types = fetcher.GetAllLootableTypes();
            allLoot = types.DoFunc(t => t.GetInstance() as ILootable<T>);
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo)
        {
            return algo.Loot(allLoot);
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(allLoot));
        }



        #region Properties

        public ILootable<T>[] AllLoot
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
                foreach (ILootable<T> l in allLoot) 
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
                foreach (ILootable<T> l in allLoot)
                {
                    if (!rarityNames.Contains(l.RarityName)) rarityNames.Add(l.RarityName);
                }
                return rarityNames.ToArray();
            }
        }

        #endregion
    }
}
