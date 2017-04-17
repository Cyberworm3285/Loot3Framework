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
    /// <seealso cref="Types.Classes.Algorithms.ObjectFetching"/>
    /// <seealso cref="Types.Classes.BaseClasses.DefaultObjectFetcher{T}"/>
    /// <seealso cref="LootObjectContainer{T}"/>
    /// <example>
    /// <para>
    /// Container können sowohl von einem <see cref="Loot3Framework.Interfaces.ILootObjectFetcher{T}"/> als kompletter Array zum Loot-Pool hinzugefügt werden (erfordert geringfügige 
    /// manuelle Implementation, siehe <see cref="DefaultObjectFetcher{T}"/>) oder durch Vererbung von der Basisklasse beim <see cref="ILootTypeFetcher{T}"/> berücksichtigt werden. 
    /// </para>
    /// <para>
    /// Bei der Vererbung ist es am einfachsten sämtliche Änderungen und Konfigurierungen im Konstruktor durchzuführen (selbst der ToString()-Output kann eingestellt werden):
    /// </para>
    /// <code>
    /// public class FunctionContainerExtension : LootFunctionContainer&lt;string&gt;
    /// {
    ///     public FunctionContainerExtension() : base(() =&gt; "Funktion", "ToString()-Output")
    ///     {
    ///         this.SetProps(false, "FunktionsName", 123, "FunktionsTyp");
    ///     }
    /// }
    /// </code>
    /// </example>
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
        /// <summary>
        /// Standard-Ausgabewert für die ToString() Methode
        /// </summary>
        protected string rep;



        #endregion

        #region Constructors
        /// <summary>
        /// Konstruktor, der die Loot-Funktion setzt
        /// </summary>
        /// <param name="func">Die Loot-Funktion</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootFunctionContainer(Func<T> func, string representationString = null)
        {
            innerFunction = func;
            rep = representationString;
        }
        /// <summary>
        /// Konstruktor, der die Loot-Funktion und die Seltenheits-Refernztabelle setzt
        /// </summary>
        /// <param name="func">Die Loot-Funktion</param>
        /// <param name="_rarityTable">Die Seltenheits-Referenztabelle</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootFunctionContainer(Func<T> func, ILootRarityTable _rarityTable, string representationString = null)
        {
            innerFunction = func;
            rarityTable = _rarityTable;
            rep = representationString;
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
        public virtual T Item
        {
            get
            {
                return innerFunction();
            }
        }

        /// <summary>
        /// Flag die anzeigt, ob das generierte Item ein Quest-Item ist
        /// </summary>
        public virtual bool IsQuestItem
        {
            get
            {
                return containerIsQuestItem;
            }
        }
        /// <summary>
        /// Der Name des generierten Items
        /// </summary>
        public virtual string Name
        {
            get
            {
                return containerName;
            }
        }
        /// <summary>
        /// Die Seltenheit des generierten Items
        /// </summary>
        public virtual int Rarity
        {
            get
            {
                return containerRarity;
            }
        }
        /// <summary>
        /// Der Typ des generierten Items
        /// </summary>
        public virtual string Type
        {
            get
            {
                return containerType;
            }
        }
        /// <summary>
        /// Die Seltenheits-Referenztabelle des generierten Items
        /// </summary>
        public virtual ILootRarityTable rarTable
        {
            get
            {
                return rarTable;
            }
        }
        /// <summary>
        /// Der Name der Seltenheit anhand der eigenen Seltenheits-Referenztabelle
        /// </summary>
        public virtual string RarityName
        {
            get
            {
                return rarityTable.ToRarityName(containerRarity);
            }
        }
        /// <summary>
        /// Die momentane Loot-Funktion
        /// </summary>
        public virtual Func<T> LootFunction
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
            return rep ?? "Container [" + this.GetType().Name + "] containing [Func<" + typeof(T).Name + ">] (" + Name + ")";
        }

        #endregion
    }
}
