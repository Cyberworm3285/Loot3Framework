using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.ExtensionMethods.Other;

using Loot3Framework.Types.Classes.Algorithms.TypeFetching;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// Item-Handler, der die grundlegeneden Funktionalitäten des <see cref="IItemHolder{T}"/> implementiert und einen verteilten Loot-Pool hat
    /// </summary>
    /// <typeparam name="T">Der zu lootede Typ</typeparam>
    /// <seealso cref="IItemHolder{T}"/>
    /// <seealso cref="BaseLootHolder{T}"/>
    /// <example>
    /// <para>
    /// Da dies eine abtrakte Klasse ist, muss sie erweitert werden, um benutzt werden zu können. Dieses Beispiel setzt 3 Loot-Pools nach den <see cref="Types.Attributes.LootTagAttribute"/>s (A,B,C) mit dem Singleton Pattern.
    /// </para>
    /// <code>
    /// public class Example : BaseSplitItemHandler&lt;string&gt;
    /// {
    ///     private static Example instance;
    ///
    ///     public Example() 
    ///         : base(
    ///               new ILootTypeFetcher&lt;string&gt;[]
    ///               {
    ///                   new FetchByLootTags&lt;string&gt;("A"),
    ///                   new FetchByLootTags&lt;string&gt;("B"),
    ///                   new FetchByLootTags&lt;string&gt;("C"),
    ///               },
    ///               new string[]
    ///               {
    ///                   "A",
    ///                   "B",
    ///                   "C"
    ///               }
    ///         )
    ///     { }
    ///
    ///     public static Example Instance
    ///     {
    ///         get { return instance ?? (instance = new Example()); }
    ///     }
    /// }
    /// </code>
    /// </example>
    public class BaseSplitItemHandler<T> : IItemHolder<T>
    {
        #region Attributes

        /// <summary>
        /// Der momentan ausgewählte Typ
        /// </summary>
        protected string currMode = "All";
        /// <summary>
        /// Das gesammte interne Loot (alle Modi zusammene)
        /// </summary>
        protected List<ILootable<T>> allInternalLoot;
        /// <summary>
        /// Das <see cref="Dictionary{TKey, TValue}"/>, welches den Modus mit den loot-Pools verbindet
        /// </summary>
        protected Dictionary<string, List<ILootable<T>>> lootHashMap;

        #endregion

        #region Constructors

        /// <summary>
        /// Leerer Konstruktor, der die Standardwerte initialisiert
        /// </summary>
        public BaseSplitItemHandler()
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };
        }
        /// <summary>
        /// Konstruktor, der den Fetcher und den Anfangs-Loot-Pool setzt
        /// </summary>
        /// <param name="fetcher">Der Fetcher</param>
        /// <param name="startMode">Der Anfangs-Loot-Pool</param>
        public BaseSplitItemHandler(ILootTypeFetcher<T> fetcher, string startMode)
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };

            InitLootables(fetcher, startMode);
        }
        /// <summary>
        /// Konstruktor, der die Fetcher und die entsprechenden Loot-Pools setzt
        /// </summary>
        /// <param name="fetchers">Die Fetcher</param>
        /// <param name="modes">Die entsprechenden Loot-Pools</param>
        public BaseSplitItemHandler(ILootTypeFetcher<T>[] fetchers, string[] modes)
        {
            allInternalLoot = new List<ILootable<T>>();
            lootHashMap = new Dictionary<string, List<ILootable<T>>>() { { "All", allInternalLoot } };

            InitLootables(fetchers, modes);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Fügt ein neues Element zur momentanen Liste hinzu
        /// </summary>
        /// <param name="item">Das neue Element</param>
        public virtual void Add(ILootable<T> item)
        {
            if (currMode != "All")
                lootHashMap[currMode].Add(item);
            allInternalLoot.Add(item);
        }
        /// <summary>
        /// Fügt einen <see cref="Array"/> an Elementen zur momentanen Liste hinzu
        /// </summary>
        /// <param name="items">Die neuen Elemente</param>
        public virtual void AddRange(ILootable<T>[] items)
        {
            if (currMode != "All")
                lootHashMap[currMode].AddRange(items);
            allInternalLoot.AddRange(items);
        }
        /// <summary>
        /// Gibt mit dem angegebenen Algorithmus ein Loot-Objekt aus
        /// </summary>
        /// <param name="algo">Der Algorithmus</param>
        /// <returns>Das ausgewählte Loot-Objekt</returns>
        public virtual ILootable<T> GetLoot(ILootingAlgorithm<T> algo)
        {
            return algo.Loot(lootHashMap[currMode].ToArray());
        }
        /// <summary>
        /// Gibt mit dem angegebenen Algorithmus und dem Filter ein Loot-Objekt aus
        /// </summary>
        /// <param name="algo">Der Algorithmus</param>
        /// <param name="filter">Der Filter</param>
        /// <returns>Das ausgewählte Loot-Objekt</returns>
        public virtual ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(lootHashMap[currMode].ToArray()));
        }
        /// <summary>
        /// Sucht und initialisiert alle Loot-Typen
        /// </summary>
        /// <param name="fetcher">Der zu benutzende Fetcher</param>
        public virtual void InitLootables(ILootTypeFetcher<T> fetcher)
        {
            ILootable<T>[] newLoot = fetcher.GetAllLootableTypes().GetInstances().Select(o => o as ILootable<T>).ToArray();
            if (currMode != "All")
                lootHashMap[currMode].AddRange(newLoot);
            allInternalLoot.AddRange(newLoot);
        }
        /// <summary>
        /// Sucht und initialisiert alle Loot-Typen und fügt diese zum angegebenen Loot-Pool hinzu
        /// </summary>
        /// <param name="fetcher">Der zu benutzende Fetcher</param>
        /// <param name="startMode">Der Loot-Pool</param>
        public virtual void InitLootables(ILootTypeFetcher<T> fetcher, string startMode)
        {
            currMode = startMode;
            if (!lootHashMap.Keys.Contains(startMode))
                lootHashMap.Add(startMode, new List<ILootable<T>>());
            InitLootables(fetcher);
        }
        /// <summary>
        /// Sucht und initialisiert alle Loot-Typen und fügt diese zum entsprechenden Loot-Pool hinzu
        /// </summary>
        /// <param name="fetchers">Die zu benutzenden Fetcher</param>
        /// <param name="modes">Die entsprechenden Loot-Pools</param>
        /// <exception cref="IndexOutOfRangeException">Wenn fetchers und modes unterschiedlich lang sind</exception>
        public virtual void InitLootables(ILootTypeFetcher<T>[] fetchers, string[] modes)
        {
            if (fetchers.Length != modes.Length)
                throw new IndexOutOfRangeException("Uneven Array length. Both Arrays must have the same length");
            for (int i = 0; i < fetchers.Length; i++)
            {
                if (!lootHashMap.Keys.Contains(modes[i]))
                    lootHashMap.Add(modes[i], new List<ILootable<T>>());
                InitLootables(fetchers[i], modes[i]);
            }

            currMode = "string";
        }
        /// <summary>
        /// Versucht den Loot-Pool zum neuen Wert zu wechseln (Try-Pattern)
        /// </summary>
        /// <param name="newMode">Der neue Loot-Pool</param>
        /// <returns>True bei Gültigkeit</returns>
        public virtual bool TrySwitchMode(string newMode)
        {
            if (!lootHashMap.Keys.Contains(newMode))
                return false;
            else
            {
                currMode = newMode;
                return true;
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Das gesamte gespeicherte Loot
        /// </summary>
        public virtual ILootable<T>[] AllLoot
        {
            get { return allInternalLoot.ToArray(); }
        }
        /// <summary>
        /// Alle Namen der Typen von den Objekten in der Liste
        /// </summary>
        public virtual string[] AllTypeNames
        {
            get
            {
                HashSet<string> result = new HashSet<string>();
                lootHashMap[currMode].ToArray().DoAction(
                        l => result.Add(l.Type)
                    );

                return result.ToArray();
            }
        }
        /// <summary>
        /// Alle Seltenheiten der Typen von den Objekten in der Liste
        /// </summary>
        public virtual string[] AllRarityNames
        {
            get
            {
                HashSet<string> result = new HashSet<string>();
                lootHashMap[currMode].ToArray().DoAction(
                        l => result.Add(l.RarityName)
                    );

                return result.ToArray();
            }
        }
        /// <summary>
        /// Der momentan ausgewählte Loot-Pool
        /// </summary>
        public virtual string ItemMode
        {
            get { return currMode; }
        }

        #endregion
    }

    
}
