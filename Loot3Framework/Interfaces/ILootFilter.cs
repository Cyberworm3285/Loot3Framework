using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funtkionen eines Loot-Filters vor
    /// </summary>
    public interface ILootFilter
    {
        /// <summary>
        /// Filtert einen <see cref="Array"/> von Loot ud gibt das Ergebnis aus
        /// </summary>
        /// <typeparam name="T">Der lootbare Typ</typeparam>
        /// <param name="allLoot">Das gesamte urprüngliche Loot</param>
        /// <returns>Das gefilterte Loot</returns>
        ILootable<T>[] Filter<T>(ILootable<T>[] allLoot);
    }
}
