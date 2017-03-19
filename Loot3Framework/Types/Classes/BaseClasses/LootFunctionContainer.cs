using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.RarityTables;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// Loot-Container, der eine Funktion zum generieren von Loot enthält (<see cref="Func{TResult}"/>)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    public class LootFunctionContainer<T> : ILootable<T>
    {
        #region Attributes
        /// <summary>
        /// Die Generierungsfunktion
        /// </summary>
        protected Func<T> innerFunction;

        /// <summary>
        /// Flag die anzeigt, ob das generierte Item ein Quest-Item ist
        /// </summary>
        protected bool containerIsQuestItem;
        /// <summary>
        /// Der Name des generierten Items
        /// </summary>
        protected string containerName = "[No Name]";
        /// <summary>
        /// Die Seltenheit des generierten Items
        /// </summary>
        protected int containerRarity = 1000;
        /// <summary>
        /// Der Typ des generierten Items
        /// </summary>
        protected string containerType = "[No Type]";
        /// <summary>
        /// Die Seltenheits-Referenztabelle des generierten Items
        /// </summary>
        protected ILootRarityTable rarityTable = DefaultRarityTable.SharedInstance;



        #endregion

        #region Constructors
        /// <summary>
        /// Konstruktor, der die Loot-Funktion setzt
        /// </summary>
        /// <param name="func">Die Loot-Funktion</param>
        public LootFunctionContainer(Func<T> func)
        {
            innerFunction = func;
        }
        /// <summary>
        /// Konstruktor, der die Loot-Funktion und die Seltenheits-Refernztabelle setzt
        /// </summary>
        /// <param name="func">Die Loot-Funktion</param>
        /// <param name="_rarityTable">Die Seltenheits-Referenztabelle</param>
        public LootFunctionContainer(Func<T> func, ILootRarityTable _rarityTable)
        {
            innerFunction = func;
            rarityTable = _rarityTable;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Setzt alle Lootingrelevanten Eigenschaften
        /// </summary>
        /// <param name="isQuest">Quest Flag</param>
        /// <param name="name">Name</param>
        /// <param name="rar">Seltenheit</param>
        /// <param name="type">Typ</param>
        /// <param name="table">Seltenheits-Referenztabelle</param>
        /// <returns>Sich selbst (also in einer Zeile erstellbar und initialisierbar)</returns>
        public LootFunctionContainer<T> SetProps(bool isQuest, string name, int rar, string type, ILootRarityTable table)
        {
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;
            rarityTable = table;

            return this;
        }
        /// <summary>
        /// Setzt alle Lootingrelevanten Eigenschaften
        /// </summary>
        /// <param name="isQuest">Quest Flag</param>
        /// <param name="name">Name</param>
        /// <param name="rar">Seltenheit</param>
        /// <param name="type">Typ</param>
        /// <returns>Sich selbst (verkettbar / also in einer Zeile erstellbar und initialisierbar)</returns>
        public LootFunctionContainer<T> SetProps(bool isQuest, string name, int rar, string type)
        {
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;

            return this;
        }
        /// <summary>
        /// Setzt die Loot-Funktion
        /// </summary>
        /// <param name="func">Die neue Funktion</param>
        /// <returns>Sich selbst (verkettbar / also in einer Zeile erstellbar und initialisierbar)</returns>
        public LootFunctionContainer<T> SetFunc(Func<T> func)
        {
            innerFunction = func;

            return this;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Die Generierungsfunktion wird aufgerufen und gibt das Item aus
        /// </summary>
        public T Item
        {
            get
            {
                return innerFunction();
            }
        }

        /// <summary>
        /// Flag die anzeigt, ob das generierte Item ein Quest-Item ist
        /// </summary>
        public bool IsQuestItem
        {
            get
            {
                return containerIsQuestItem;
            }
        }
        /// <summary>
        /// Der Name des generierten Items
        /// </summary>
        public string Name
        {
            get
            {
                return containerName;
            }
        }
        /// <summary>
        /// Die Seltenheit des generierten Items
        /// </summary>
        public int Rarity
        {
            get
            {
                return containerRarity;
            }
        }
        /// <summary>
        /// Der Typ des generierten Items
        /// </summary>
        public string Type
        {
            get
            {
                return containerType;
            }
        }
        /// <summary>
        /// Die Seltenheits-Referenztabelle des generierten Items
        /// </summary>
        public ILootRarityTable rarTable
        {
            get
            {
                return rarTable;
            }
        }
        /// <summary>
        /// Der Name der Seltenheit anhand der eigenen Seltenheits-Referenztabelle
        /// </summary>
        public string RarityName
        {
            get
            {
                return rarityTable.ToRarityName(containerRarity);
            }
        }
        /// <summary>
        /// Die momentane Loot-Funktion
        /// </summary>
        public Func<T> LootFunction
        {
            get
            {
                return innerFunction;
            }
        }




        #endregion

        #region Overrides

        /// <summary>
        /// Formatiert die Eigenschaften dieses Loot-Containers
        /// </summary>
        /// <returns>Die Eigenschaften dieses Containers in einem <see cref="string"/></returns>
        public override string ToString()
        {
            return "Container [" + this.GetType().Name + "] containing [Func<" + typeof(T).Name + ">] (" + Name + ")";
        }

        #endregion
    }
}
