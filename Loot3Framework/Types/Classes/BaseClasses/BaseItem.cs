using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.TypeConversion;

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

        #endregion

        public string Generate()
        {
            return string.Join("|", new string[] { name, type, string.Join("|", attributes.ToStrings()) });
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
                return "Normal";
            }
        }

        #endregion
    }
}
