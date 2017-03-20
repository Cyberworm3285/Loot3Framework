using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funktionen eines Loot-Algorithmusses vor
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="Types.Classes.Algorithms.Looting"/>
    public interface ILootingAlgorithm<T>
    {
        /// <summary>
        /// Gibt aus einem <see cref="Array"/> von Loot ein Element (zb anhand seiner Seltenheit,..) aus
        /// </summary>
        /// <param name="allLoot">Das gesamte zum Looten zugelassene Material</param>
        /// <returns>Das schlussendlich gelootete Objekt</returns>
        ILootable<T> Loot(ILootable<T>[] allLoot);
    }
}
