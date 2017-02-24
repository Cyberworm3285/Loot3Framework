using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.ObjectFetching;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    [CLSCompliant(false)]
    public abstract class BaseLootHolder<T> : IItemHolder<T>
    {
        protected List<ILootable<T>> allLoot;

        public BaseLootHolder(ILootTypeFetcher<T> fetcher)
        {
            InitLootables(fetcher);
        }

        #region Methods

        public void InitLootables(ILootTypeFetcher<T> fetcher)
        {
            Type[] types = fetcher.GetAllLootableTypes();
            allLoot = types.DoFunc(t => t.GetInstance() as ILootable<T>).ToList();
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo)
        {
            return algo.Loot(allLoot.ToArray());
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(allLoot.ToArray()));
        }

        public void Add(ILootable<T> item)
        {
            allLoot.Add(item);
        }

        public void AddRange(ILootable<T>[] items)
        {
            allLoot.AddRange(items);
        }

        public void AddAllLootObjects()
        {
            AddRange(ObjectFetcherAccess<T>.GetObjects());
        }

        #endregion

        #region Properties

        public ILootable<T>[] AllLoot
        {
            get
            {
                return allLoot.ToArray();
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
