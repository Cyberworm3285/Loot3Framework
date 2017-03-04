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
    public class LootFunctionContainer<T> : ILootable<T>
    {
        #region Attributes
        protected Func<T> innerFunction;

        protected string[] containerAllowedAreas;
        protected bool containerIsQuestItem;
        protected string containerName = "[No Name]";
        protected int containerRarity = 1000;
        protected string containerType = "[No Type]";
        protected ILootRarityTable rarityTable = new DefaultRarityTable();

        #endregion

        #region Constructors

        public LootFunctionContainer(Func<T> func)
        {
            innerFunction = func;
        }

        public LootFunctionContainer(Func<T> func, ILootRarityTable _rarityTable)
        {
            innerFunction = func;
            rarityTable = _rarityTable;
        }

        #endregion

        #region Methods

        public LootFunctionContainer<T> SetProps(string[] areas, bool isQuest, string name, int rar, string type, ILootRarityTable table)
        {
            containerAllowedAreas = areas;
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;
            rarityTable = table;

            return this;
        }

        public LootFunctionContainer<T> SetProps(string[] areas, bool isQuest, string name, int rar, string type)
        {
            containerAllowedAreas = areas;
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;

            return this;
        }

        public LootFunctionContainer<T> SetFunc(Func<T> func)
        {
            innerFunction = func;

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
                return innerFunction();
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

        #region Overrides

        public override string ToString()
        {
            return "Container [" + this.GetType().Name + "] containing [Func<" + typeof(T).Name + ">] (" + Name + ")";
        }

        #endregion
    }
}
