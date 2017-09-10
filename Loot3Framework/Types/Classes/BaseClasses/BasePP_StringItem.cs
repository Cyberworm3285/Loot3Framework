using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.ExtensionMethods.CollectionOperations;


namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// BasisKlasse für Loot vom Typ <see cref="string"/> (zum Beispiel für Pen and Papers)
    /// </summary>
    /// <example>
    /// <para>
    /// Da dies eine abstrakte Klasse ist, muss diese zur Verwendung erweitert werden, am einfachsten ist es dazu
    /// alle Änderungen im Konstruktor vorzunehmen (ggf. mit Hilfe der Basis-Konstruktoren/ : base(..))
    /// </para>
    /// <code>
    /// public class Example : BasePP_StringItem
    /// {
    ///     public Example() : base("ExampleItem")
    ///     {
    ///         rarity = 666;
    ///         type = "Example";
    ///     }
    /// }
    /// </code>
    /// </example>
    [CLSCompliant(false)]
    public abstract class BasePP_StringItem : ILootable<string>
    {
        #region Attributes
        /// <summary>
        /// Variable Attribute die erst bei Laufzeit einen <see cref="string"/>-Wert generieren
        /// </summary>
        protected IItemProperty<string>[] attributes = new IItemProperty<string>[0];
        /// <summary>
        /// Der Name des Items (für Algorthmen und ggf. auch Darstellung relevant)
        /// </summary>
        protected string name = "[No Name]";
        /// <summary>
        /// Die Seltenheit des Items (für Algorithmen relevant)
        /// </summary>
        protected int rarity = 1000;
        /// <summary>
        /// Der Typ des Items (für Algorithmen relevant)
        /// </summary>
        protected string type = "[No Type]";
        /// <summary>
        /// Seltenheits-Referenz, die aus dem Seltenheitswert einen Benutzerfreundlichen <see cref="string"/> generieren kann
        /// </summary>
        protected ILootRarityTable rarityTable = DefaultRarityTable.SharedInstance;

        #endregion

        #region Constructors

        /// <summary>
        /// leerer Konstruktor, der die Standardpresets beibehält
        /// </summary>
        public BasePP_StringItem() { }
        /// <summary>
        /// Konstruktor, der den Name des Items setzt
        /// </summary>
        /// <param name="_name">Der Name</param>
        public BasePP_StringItem(string _name) { name = _name; }
        /// <summary>
        /// Konstruktor der die Seltenheits-Referenztabelle setzt
        /// </summary>
        /// <param name="table">Die Refernztabelle</param>
        public BasePP_StringItem(ILootRarityTable table) { rarityTable = table; }
        /// <summary>
        /// Konstruktor, der den Namen des Items und die Seltenheits-Referenztabelle setzt
        /// </summary>
        /// <param name="_name">Der Name</param>
        /// <param name="_table">Die Seltenheit</param>
        public BasePP_StringItem(string _name, ILootRarityTable _table)
        {
            name = _name;
            rarityTable = _table;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Formatiert das Item in einem <see cref="string"/> ( {name}[{typ}] )
        /// </summary>
        /// <returns>Eine Zusammenfassung der wichtigsten Eigenschaften als <see cref="string"/></returns>
        public override string ToString()
        {
            return name + "[" + type + "]";
        }

        #endregion

        #region Properties
        /// <summary>
        /// Generiert aus den Attributen einen <see cref="string"/>
        /// </summary>
        public virtual string Item
        {
            get
            {
                return string.Join("|", new string[] { name, type, string.Join("|", attributes.Select(a => a.Generate()).ToArray()), "[" + RarityName + "]" });
            }
        }
        /// <summary>
        /// Der Name des Items (für Algorthmen und ggf. auch Darstellung relevant)
        /// </summary>
        public virtual string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// Die Seltenheit des Items (für Algorithmen relevant)
        /// </summary>
        public virtual int Rarity
        {
            get
            {
                return rarity;
            }
        }
        /// <summary>
        /// Der Typ des Items (für Algorithmen relevant)
        /// </summary>
        public virtual string Type
        {
            get
            {
                return type;
            }
        }
        /// <summary>
        /// Gibt aus der Seltenheits-Referenztabelle einen von der Seltenheit abhängigen Wert aus
        /// </summary>
        public virtual string RarityName
        {
            get
            {
                return rarityTable.ToRarityName(rarity);
            }
        }
        /// <summary>
        /// Seltenheits-Referenz, die aus dem Seltenheitswert einen Benutzerfreundlichen <see cref="string"/> generieren kann
        /// </summary>
        public virtual ILootRarityTable rarTable
        {
            get { return rarTable; }
        }

        #endregion
    }
}
