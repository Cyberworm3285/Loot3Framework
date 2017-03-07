using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    public class BaseSplitItemHandler<T> : IItemHolder<T>
    {
        #region Attributes

        protected string currMode = "All";
        protected List<ILootable<T>> allInternalLoot;
        protected Dictionary<string, List<ILootable<T>>> lootHashMap;

        #endregion

        #region Constructors

        private BaseSplitItemHandler()
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };
        }

        private BaseSplitItemHandler(ILootTypeFetcher<T> fetcher, string startMode)
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };

            InitLootables(fetcher, startMode);
        }

        private BaseSplitItemHandler(ILootTypeFetcher<T>[] fetchers, string[] modes)
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };

            InitLootables(fetchers, modes);
        }

        #endregion

        #region Methods

        public void Add(ILootable<T> item)
        {
            if (currMode != "All")
                lootHashMap[currMode].Add(item);
            allInternalLoot.Add(item);
        }

        public void AddRange(ILootable<T>[] items)
        {
            if (currMode != "All")
                lootHashMap[currMode].AddRange(items);
            allInternalLoot.AddRange(items);
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo)
        {
            return algo.Loot(lootHashMap[currMode].ToArray());
        }

        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(lootHashMap[currMode].ToArray()));
        }

        public void InitLootables(ILootTypeFetcher<T> fetcher)
        {
            ILootable<T>[] newLoot = fetcher.GetAllLootableTypes().GetInstances().DoFunc(o => o as ILootable<T>);
            if (currMode != "All")
                lootHashMap[currMode].AddRange(newLoot);
            allInternalLoot.AddRange(newLoot);
        }

        public void InitLootables(ILootTypeFetcher<T> fetcher, string startMode)
        {
            currMode = startMode;
            if (!lootHashMap.Keys.Contains(startMode))
                lootHashMap.Add(startMode, new List<ILootable<T>>());
            InitLootables(fetcher);
        }

        /// <exception cref="IndexOutOfRangeException">At uneven Array lengths</exception>
        public void InitLootables(ILootTypeFetcher<T>[] fetchers, string[] modes)
        {
            if (fetchers.Length != modes.Length)
                throw new IndexOutOfRangeException("Uneven Array length. Both Arrays must have the same length");
            for (int i = 0; i < fetchers.Length; i++)
            {
                if (!lootHashMap.Keys.Contains(modes[i]))
                    lootHashMap.Add(modes[i], new List<ILootable<T>>());
                InitLootables(fetchers[i], modes[i]);
            }

            currMode = "string";
        }

        public bool TrySwitchMode(string newMode)
        {
            if (!lootHashMap.Keys.Contains(newMode))
                return false;
            else
            {
                currMode = newMode;
                return true;
            }
        }

        #endregion

        #region Properties

        public ILootable<T>[] AllLoot
        {
            get { return allInternalLoot.ToArray(); }
        }

        public string[] AllTypeNames
        {
            get
            {
                HashSet<string> result = new HashSet<string>();
                lootHashMap[currMode].ToArray().DoAction(
                        l => result.Add(l.Type)
                    );

                return result.ToArray();
            }
        }

        public string[] AllRarityNames
        {
            get
            {
                HashSet<string> result = new HashSet<string>();
                lootHashMap[currMode].ToArray().DoAction(
                        l => result.Add(l.RarityName)
                    );

                return result.ToArray();
            }
        }

        public string ItemMode
        {
            get { return currMode; }
        }

        #endregion
    }
}
