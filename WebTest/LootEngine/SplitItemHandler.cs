using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.ExtensionMethods.Other;

namespace WebTest.LootEngine
{
    public enum ItemLibraryMode
    {
        All,
        Pirates,
        Space,
        ZombieApokalypse,
        ModernWar,
        Medieval,
        Fantasy,
        Crap
    }

    public class SplitItemHandler : IItemHolder<string>
    {
        #region Attributes

        protected ItemLibraryMode currMode = ItemLibraryMode.All;
        protected List<ILootable<string>> allLoot;
        protected Dictionary<ItemLibraryMode, List<ILootable<string>>> lootHashMap;

        private static SplitItemHandler instance;

        #endregion

        #region Constructors

        private SplitItemHandler()
        {
            allLoot = new List<ILootable<string>>();
            lootHashMap = new Dictionary<ItemLibraryMode, List<ILootable<string>>>() { { ItemLibraryMode.All, allLoot } };
        }

        private SplitItemHandler(ILootTypeFetcher<string> fetcher, ItemLibraryMode startMode)
        {
            allLoot = new List<ILootable<string>>();
            lootHashMap = new Dictionary<ItemLibraryMode, List<ILootable<string>>>() { { ItemLibraryMode.All, allLoot } };

            InitLootables(fetcher, startMode);
        }

        private SplitItemHandler(ILootTypeFetcher<string>[] fetchers, ItemLibraryMode[] modes)
        {
            allLoot = new List<ILootable<string>>();
            lootHashMap = new Dictionary<ItemLibraryMode, List<ILootable<string>>>() { { ItemLibraryMode.All, allLoot } };

            InitLootables(fetchers, modes);
        }

        #endregion

        #region Methods

        public void Add(ILootable<string> item)
        {
            if (currMode != ItemLibraryMode.All)
                lootHashMap[currMode].Add(item);
            allLoot.Add(item);
        }

        public void AddRange(ILootable<string>[] items)
        {
            if (currMode != ItemLibraryMode.All)
                lootHashMap[currMode].AddRange(items);
            allLoot.AddRange(items);
        }

        public ILootable<string> GetLoot(ILootingAlgorithm<string> algo)
        {
            return algo.Loot(lootHashMap[currMode].ToArray());
        }

        public ILootable<string> GetLoot(ILootingAlgorithm<string> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(lootHashMap[currMode].ToArray()));
        }

        public void InitLootables(ILootTypeFetcher<string> fetcher)
        {
            ILootable<string>[] newLoot = fetcher.GetAllLootableTypes().GetInstances().DoFunc(o => o as ILootable<string>);
            if (currMode != ItemLibraryMode.All)
                lootHashMap[currMode].AddRange(newLoot);
            allLoot.AddRange(newLoot);
        }

        public void InitLootables(ILootTypeFetcher<string> fetcher, ItemLibraryMode startMode)
        {
            currMode = startMode;
            if (!lootHashMap.Keys.Contains(startMode))
                lootHashMap.Add(startMode, new List<ILootable<string>>());
            InitLootables(fetcher);
        }

        /// <exception cref="IndexOutOfRangeException">At uneven Array lengths</exception>
        public void InitLootables(ILootTypeFetcher<string>[] fetchers, ItemLibraryMode[] modes)
        {
            if (fetchers.Length != modes.Length)
                throw new IndexOutOfRangeException("Uneven Array length. Both Arrays must have the same length");
            for (int i = 0; i < fetchers.Length; i++)
            {
                if (!lootHashMap.Keys.Contains(modes[i]))
                    lootHashMap.Add(modes[i], new List<ILootable<string>>());
                InitLootables(fetchers[i], modes[i]);
            }

            currMode = ItemLibraryMode.All;
        }

        public bool TrySwitchMode(string newMode)
        {
            return Enum.TryParse(newMode, out currMode);
        }

        #endregion

        #region Properties

        public ILootable<string>[] AllLoot
        {
            get { return allLoot.ToArray(); }
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

        public ItemLibraryMode ItemMode
        {
            get { return currMode; }
            set { currMode = value; }
        }

        public static SplitItemHandler Instance
        {
            get { return instance ?? (instance = new SplitItemHandler()); }
        }

        #endregion
    }
}
