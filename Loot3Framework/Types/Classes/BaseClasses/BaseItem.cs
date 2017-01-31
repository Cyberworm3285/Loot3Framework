using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.TypeConversion;
using Loot3Framework.Types.Classes.RarityTables;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    public abstract class BaseItem : ILootable
    {
        #region Attribute

        protected string[] allowedAreas;
        protected IItemProperty[] attributes;
        protected bool isQuestItem;
        protected string name = "[No Name]";
        protected int rarity = 1000;
        protected string type = "[No Type]";
        protected ILootRarityTable rarityTable = new DefaultRarityTable();

        #endregion

        public BaseItem() { }
        public BaseItem(string _name) { name = _name; }
        public BaseItem(ILootRarityTable table) { rarityTable = table; }

        public string Generate()
        {
            return string.Join("|", new string[] { name, type, string.Join("|", attributes.ToStrings()), "[" + RarityName + "]" });
        }

        public string ToRarityName(ILootRarityTable table)
        {
            int index = Array.FindIndex(table.Chain.Intervalls, i => i.X < rarity && i.Y >= rarity);
            return table.Values[index];
        }

        #region Properties

        public string[] AllowedAreas
        {
            get
            {
                return allowedAreas;
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
                return ToRarityName(rarityTable);
            }
        }

        #endregion
    }
}
