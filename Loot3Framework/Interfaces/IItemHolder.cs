using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Interface welches die grundlegenden Funktionen eines Itemholders vorgibt
    /// </summary>
    /// <typeparam name="T">Der Lootbare Typ</typeparam>
    public interface IItemHolder<T>
    {
        /// <summary>
        /// Das bereitstellen von Loot anhand eines <see cref="ILootingAlgorithm{T}"/>
        /// </summary>
        /// <param name="algo">Der zu verwendende Algorithmus</param>
        /// <returns>Das resultierende Loot Objekt</returns>
        ILootable<T> GetLoot(ILootingAlgorithm<T> algo);
        /// <summary>
        /// Das bereitstellen von Loot anhand eines <see cref="ILootingAlgorithm{T}"/> und eines <see cref="ILootFilter"/>
        /// </summary>
        /// <param name="algo">Der zu verwendende Algorithmus</param>
        /// <param name="filter">Der zu verwendende Filter</param>
        /// <returns>Das resultierende Loot Objekt</returns>
        ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter);
        /// <summary>
        /// Initialisierung der internen Loot-Typen (Bereitstellen/Instanziieren der Lootobjekte)
        /// </summary>
        /// <param name="fetcher">Fetcher zum sammeln aller Lootbaren Typen</param>
        void InitLootables(ILootTypeFetcher<T> fetcher);

        #region Methods
        /// <summary>
        /// Fügt ein Element der internen Lootsammlung hinzu
        /// </summary>
        /// <param name="item">Das neue Element</param>
        void Add(ILootable<T> item);
        /// <summary>
        /// Fügt einen <see cref="Array"/> an Elementen der Lootsammlung hinzu 
        /// </summary>
        /// <param name="items"></param>
        void AddRange(ILootable<T>[] items);

        #endregion

        #region Properties
        /// <summary>
        /// Gibt sämtliches Loot aus der Sammlung aus (get-only)
        /// </summary>
        ILootable<T>[] AllLoot
        {
            get;
        }
        /// <summary>
        /// Gibt Sämtliche verwendeten Typ-Attribute der Lootsammlung aus (get-only)
        /// </summary>
        string[] AllTypeNames
        {
            get;
        }
        /// <summary>
        /// Gibt Sämtliche verwendeten Seltenheits-Attribute der Lootsammlung aus (get-only)
        /// </summary>
        string[] AllRarityNames
        {
            get;
        }

        #endregion
    }
}
