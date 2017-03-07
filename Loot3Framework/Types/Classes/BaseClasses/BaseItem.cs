using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    [CLSCompliant(false)]
    public abstract class BasePP_StringItem : ILootable<string>
    {
        #region Attribute

        protected IItemProperty[] attributes = new IItemProperty[0];
        protected bool isQuestItem;
        protected string name = "[No Name]";
        protected int rarity = 1000;
        protected string type = "[No Type]";
        protected ILootRarityTable rarityTable = DefaultRarityTable.SharedInstance;

        #endregion

        public BasePP_StringItem() { }
        public BasePP_StringItem(string _name) { name = _name; }
        public BasePP_StringItem(ILootRarityTable table) { rarityTable = table; }
        public BasePP_StringItem(string _name, ILootRarityTable _table)
        {
            name = _name;
            rarityTable = _table;
        }

        #region Properties

        public string Item
        {
            get
            {
                return string.Join("|", new string[] { name, type, string.Join("|", attributes.DoFunc(a => a.Generate())), "[" + RarityName + "]" });
            }
        }

        public bool IsQuestItem
        {
            get
            {
                return isQuestItem;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Rarity
        {
            get
            {
                return rarity;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string RarityName
        {
            get
            {
                return rarityTable.ToRarityName(rarity);
            }
        }

        public ILootRarityTable rarTable
        {
            get { return rarTable; }
        }

        #endregion
    }
}
