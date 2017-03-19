using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Global;
using Loot3Framework.Types.Exceptions;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    /// <summary>
    /// Lootig ALgorithmus der einfach zufällig ein Objekt ausgibt (alle Eigenschaften werden ignoriert)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootingAlgorithm{T}"/>
    /// <seealso cref="PartitionLoot{T}"/>
    /// <seealso cref="PR_PartionLoot{T, TLooter}"/>
    public class RandomLoot<T> : ILootingAlgorithm<T>
    {   
        /// <summary>
        /// Gibt ein zufälliges Loot-Objekt aus
        /// </summary>
        /// <param name="allLoot"></param>
        /// <returns>Ein zufälliges Loot-Objekt</returns>
        ///<exception cref="NoMatchingLootException">Bei leerem Inpu</exception>
        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            return allLoot[GlobalRandom.Next(0, allLoot.Length)];
        }
    }
}
