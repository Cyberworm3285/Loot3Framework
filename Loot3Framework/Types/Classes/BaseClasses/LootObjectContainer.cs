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
    /// Loot-Container, der das zu lootende Objekt bereits fix enthält
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="Types.Classes.Algorithms.ObjectFetching"/>
    /// <seealso cref="Types.Classes.BaseClasses.DefaultObjectFetcher{T}"/>
    /// <seealso cref="LootFunctionContainer{T}"/>
    /// <example>
    /// <para>
    /// Container können sowohl von einem <see cref="Loot3Framework.Interfaces.ILootObjectFetcher{T}"/> als kompletter Array zum Loot-Pool hinzugefügt werden (erfordert geringfügige 
    /// manuelle Implementation, siehe <see cref="DefaultObjectFetcher{T}"/>) oder durch Vererbung von der Basisklasse beim <see cref="ILootTypeFetcher{T}"/> berücksichtigt werden. 
    /// </para>
    /// <para>
    /// Bei der Vererbung ist es am einfachsten sämtliche Änderungen und Konfigurierungen im Konstruktor durchzuführen (selbst der ToString()-Output kann eingestellt werden):
    /// </para>
    /// <code>
    /// public class ObjectContainerExtension : LootObjectContainer&lt;string&gt;
    /// {
    ///     public ObjectContainerExtension() : base("Objekt", "ToString()-Output")
    ///     {
    ///         this.SetProps(false, "ObjektName", 123, "ObjektTyp");
    ///     }
    /// }
    /// </code>
    /// </example>
    [Serializable]
    public class LootObjectContainer<T> : ILootable<T>, IComparable<LootObjectContainer<T>>
    {
        #region Attributes
        /// <summary>
        /// Das Loot-Item
        /// </summary>
        protected T innerItem;

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
        /// Konstruktor, der das Loot-Item setzt
        /// </summary>
        /// <param name="item">Das Loot-Item</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootObjectContainer(T item, string representationString = null)
        {
            innerItem = item;
            rep = representationString;
        }
        /// <summary>
        /// Konstruktor, der das Loot.Item und die Seltenheits-Referenztabelle setzt
        /// </summary>
        /// <param name="item">Das Loot-Item</param>
        /// <param name="_rarityTable">Die Seltenheits-Referenztabelle</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootObjectContainer(T item, ILootRarityTable _rarityTable, string representationString = null)
        {
            innerItem = item;
            rarityTable = _rarityTable;
            rep = representationString;
        }
        /// <summary>
        /// Generiert aus dem uu. variablen normalen Loot-Objekt (<see cref="ILootable{T}"/>) einen Loot container, der die sonstigen Werte übernimmt
        /// </summary>
        /// <param name="item">Das normale Loot-Objekt</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootObjectContainer(ILootable<T> item, string representationString = null)
        {
            innerItem = item.Item;
            containerIsQuestItem = item.IsQuestItem;
            containerName = item.Name;
            containerRarity = item.Rarity;
            containerType = item.Type;
            rarityTable = item.rarTable;
            rep = representationString;
        }
        /// <summary>
        /// Generiert aus dem uu. variablen normalen Loot-Objekt (<see cref="ILootable{T}"/>) einen Loot container, der die sonstigen Werte übernimmt 
        /// (Seltenheits-Referenztabelle wird zusätzlich gesetzt)
        /// </summary>
        /// <param name="item">Das normale Loot-Objekt</param>
        /// <param name="_rarityTable">Die Seltenheits-Referenztbabelle</param>
        /// <param name="representationString">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public LootObjectContainer(ILootable<T> item, ILootRarityTable _rarityTable, string representationString = null)
        {
            innerItem = item.Item;
            containerIsQuestItem = item.IsQuestItem;
            containerName = item.Name;
            containerRarity = item.Rarity;
            containerType = item.Type;
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
        public LootObjectContainer<T> SetProps(bool isQuest, string name, int rar, string type, ILootRarityTable table)
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
        public LootObjectContainer<T> SetProps(bool isQuest, string name, int rar, string type)
        {
            containerIsQuestItem = isQuest;
            containerName = name;
            containerRarity = rar;
            containerType = type;

            return this;
        }
        /// <summary>
        /// Setzt das Loot-Item
        /// </summary>
        /// <param name="_object">Das neue Objekt</param>
        /// <returns>Sich selbst (verkettbar / also in einer Zeile erstellbar und initialisierbar)</returns>
        public LootObjectContainer<T> SetObject(T _object)
        {
            innerItem = _object;

            return this;
        }

        #endregion

        #region Properties
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
        /// Das gespeicherte Loot-Item
        /// </summary>
        public T Item
        {
            get
            {
                return innerItem;
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
        
        #endregion

        #region Other Interfaces
        /// <summary>
        /// <see cref="IComparable"/> Implementierung
        /// </summary>
        /// <param name="other">Das zu vergleichende Objekt</param>
        /// <returns>Standard-Vergleichs-Integer</returns>
        public int CompareTo(LootObjectContainer<T> other)
        {
            return this.containerName.CompareTo(other.Name);
        }

        #endregion

        #region Operators
        /// <summary>
        /// Erstellt einen Container um das zu castende Objekt herum
        /// </summary>
        /// <param name="a">Das zu castende Objekt</param>
        public static explicit operator LootObjectContainer<T>(T a)
        {
            return new LootObjectContainer<T>(a);
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Formatiert die Eigenschaften dieses Loot-Containers
        /// </summary>
        /// <returns>Die Eigenschaften dieses Containers in einem <see cref="string"/></returns>
        public override string ToString()
        {
            return rep ?? "Container [" + this.GetType().Name + "] containing [" + typeof(T).Name + "] (" + Name + ")";
        }

        #endregion
    }
}
