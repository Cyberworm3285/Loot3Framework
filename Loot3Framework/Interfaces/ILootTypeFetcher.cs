using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funktionalitäten des Typ-Fetchers vor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILootTypeFetcher<T>
    {
        /// <summary>
        /// Sammelt alle lootbaren Typen und gubt diese aus
        /// </summary>
        /// <returns>Die gefundenen Typen</returns>
        Type[] GetAllLootableTypes(); 
    }
}
