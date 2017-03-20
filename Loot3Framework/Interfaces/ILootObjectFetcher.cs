using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funtkionalitäten des ObjektFetcher für <see cref="Types.Classes.BaseClasses.LootFunctionContainer{T}"/> und <see cref="Types.Classes.BaseClasses.LootObjectContainer{T}"/> vor
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="Types.Classes.Algorithms.ObjectFetching"/>
    /// <seealso cref="Types.Classes.BaseClasses.DefaultObjectFetcher{T}"/>
    public interface ILootObjectFetcher<T>
    {
        /// <summary>
        /// Stellt alle gefundenen Objekte (!keine Typen!) zur Verfügung
        /// </summary>
        /// <typeparam name="TCollection">Das gewünschte Ausgabeformat</typeparam>
        /// <returns>Alle gefundenen lootbaren Objekte</returns>
        TCollection GetLootObjects<TCollection>() where TCollection : ICollection<ILootable<T>>, new();
    }
}
