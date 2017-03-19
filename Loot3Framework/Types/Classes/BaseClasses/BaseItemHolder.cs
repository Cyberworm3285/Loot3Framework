using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.ObjectFetching;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// Basisklasse für Item-Handler, die grundlegende Funktionalitäten vorimplementiert
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="IItemHolder{T}"/>
    /// <seealso cref="BaseSplitItemHandler{T}"/>
    /// <example>
    /// <para>
    /// Da dies eine abstrakte Klasse ist muss sie erweitert werden um benutzt zu werden. Dieses Beispiel implemtiert den Item-Handler von <see cref="string"/> als Singleton Pattern mit allen Typen die <see cref="ILootable{T}"/> implementieren
    /// </para>
    /// <code>
    /// public class Example : BaseLootHolder&lt;string&gt;
    /// {
    ///     private static Example instance = null;
    ///
    ///     private Example() : base( 
    ///         new FetchByInheritance&lt;string&gt;(typeof(ILootable&lt;string&gt;))
    ///     ) { }
    ///
    ///     public static GlobalItems Instance
    ///     {
    ///         get
    ///         {
    ///             return instance ?? (instance = new GlobalItems());
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    [CLSCompliant(false)]
    public abstract class BaseLootHolder<T> : IItemHolder<T>
    {
        /// <summary>
        /// Das gesamte gespeicherte Loot
        /// </summary>
        protected List<ILootable<T>> allLoot;
        /// <summary>
        /// Konstruktor, der den Typ-Fetcher setzt
        /// </summary>
        /// <param name="fetcher">Der Typ-Fetcher</param>
        public BaseLootHolder(ILootTypeFetcher<T> fetcher)
        {
            InitLootables(fetcher);
        }

        #region Methods
        /// <summary>
        /// Sucht und initialisiert alle Loot-Typen
        /// </summary>
        /// <param name="fetcher">Der zu benutzende Fetcher</param>
        public void InitLootables(ILootTypeFetcher<T> fetcher)
        {
            Type[] types = fetcher.GetAllLootableTypes();
            allLoot = types.Select(t => t.GetInstance() as ILootable<T>).ToList();
        }
        /// <summary>
        /// Gibt mit dem angegebenen Algorithmus ein Loot-Objekt aus
        /// </summary>
        /// <param name="algo">Der Algorithmus</param>
        /// <returns>Das ausgewählte Loot-Objekt</returns>
        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo)
        {
            return algo.Loot(allLoot.ToArray());
        }
        /// <summary>
        /// Gibt mit dem angegebenen Algorithmus und dem Filter ein Loot-Objekt aus
        /// </summary>
        /// <param name="algo">Der Algorithmus</param>
        /// <param name="filter">Der Filter</param>
        /// <returns>Das ausgewählte Loot-Objekt</returns>
        public ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(allLoot.ToArray()));
        }
        /// <summary>
        /// Fügt ein Objekt zur Liste hinzu
        /// </summary>
        /// <param name="item">Das neue Element</param>
        public void Add(ILootable<T> item)
        {
            allLoot.Add(item);
        }
        /// <summary>
        /// Fügt einen <see cref="Array"/> von Objekten zur Liste hinzu
        /// </summary>
        /// <param name="items">Die neuen Elemente</param>
        public void AddRange(ILootable<T>[] items)
        {
            allLoot.AddRange(items);
        }
        /// <summary>
        /// Fügt Container-Objekte zur Liste hinzu
        /// </summary>
        public void AddAllLootObjects()
        {
            AddRange(ObjectFetcherAccess<T>.GetObjects());
        }

        #endregion

        #region Properties
        /// <summary>
        /// Das gesamte gespeicherte Loot
        /// </summary>
        public ILootable<T>[] AllLoot
        {
            get
            {
                return allLoot.ToArray();
            }
        }
        /// <summary>
        /// Alle Namen der Typen von den Objekten in der Liste
        /// </summary>
        public string[] AllTypeNames
        {
            get
            {
                List<string> typeNames = new List<string>();
                foreach (ILootable<T> l in allLoot) 
                {
                    if (!typeNames.Contains(l.Type)) typeNames.Add(l.Type);
                }
                return typeNames.ToArray();
            }
        }
        /// <summary>
        /// Alle Seltenheiten der Typen von den Objekten in der Liste
        /// </summary>
        public string[] AllRarityNames
        {
            get
            {
                List<string> rarityNames = new List<string>();
                foreach (ILootable<T> l in allLoot)
                {
                    if (!rarityNames.Contains(l.RarityName)) rarityNames.Add(l.RarityName);
                }
                return rarityNames.ToArray();
            }
        }

        #endregion
    }
}
