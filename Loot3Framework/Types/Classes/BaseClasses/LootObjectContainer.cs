using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.RarityTables;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    [CLSCompliant(true)]
    [Serializable]
    public class LootObjectContainer<T> : ILootable<T>, IComparable<LootObjectContainer<T>>
    {
        #region Attributes
        protected T innerItem;

        protected string[] containerAllowedAreas;
        protected bool containerIsQuestItem;
        protected string containerName = "[No Name]";
        protected int containerRarity = 1000;
        protected string containerType = "[No Type]";
        protected ILootRarityTable rarityTable = new DefaultRarityTable();

        #endregion

        #region Constructors

        public LootObjectContainer(T item)
        {
            innerItem = item;       
        }

        public LootObjectContainer(T item, ILootRarityTable _rarityTable)
        {
            innerItem = item;
            rarityTable = _rarityTable;
        }

        public LootObjectContainer(ILootable<T> item)
        {
            innerItem = item.Item;
            containerIsQuestItem = item.IsQuestItem;
            containerName = item.Name;
            containerRarity = item.Rarity;
            containerType = item.Type;
        }

        public LootObjectContainer(ILootable<T> item, ILootRarityTable _rarityTable)
        {
            innerItem = item.Item;
            containerIsQuestItem = item.IsQuestItem;
            containerName = item.Name;
            containerRarity = item.Rarity;
            containerType = item.Type;
            rarityTable = _rarityTable;
        }

        #endregion

        #region Methods

        public LootObjectContainer<T> SetProps(string[] areas, bool isQuest, string name, int rar, string type, ILootRarityTable table)
        {
            containerAllowedAreas = areas;
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;
            rarityTable = table;

            return this;
        }

        public LootObjectContainer<T> SetProps(string[] areas, bool isQuest, string name, int rar, string type)
        {
            containerAllowedAreas = areas;
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;

            return this;
        }

        #endregion

        #region Properties

        public string[] AllowedAreas
        {
            get
            {
                return containerAllowedAreas;
            }
            set
            {
                containerAllowedAreas = value;
            }
        }

        public bool IsQuestItem
        {
            get
            {
                return containerIsQuestItem;
            }
            set
            {
                containerIsQuestItem = value;
            }
        }

        public T Item
        {
            get
            {
                return innerItem;
            }
            set
            {
                innerItem = value;
            }
        }

        public string Name
        {
            get
            {
                return containerName;
            }
            set
            {
                containerName = value;
            }
        }

        public int Rarity
        {
            get
            {
                return containerRarity;
            }
            set
            {
                containerRarity = value;
            }
        }

        public string RarityName
        {
            get
            {
                return rarityTable.ToRarityName(containerRarity);
            }
        }

        public string Type
        {
            get
            {
                return containerType;
            }
            set
            {
                containerType = value;
            }
        }

        public ILootRarityTable rarTable
        {
            get
            {
                return rarTable;
            }
        }
        #endregion

        #region Other Interfaces

        public int CompareTo(LootObjectContainer<T> other)
        {
            return this.containerName.CompareTo(other.Name);
        }

        #endregion

        #region Operators

        public static explicit operator LootObjectContainer<T>(T a)
        {
            return new LootObjectContainer<T>(a);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return "Container [" + this.GetType().Name + "] containing [" + typeof(T).Name + "] (" + Name + ")";
        }

        #endregion
    }
}
