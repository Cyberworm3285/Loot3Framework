using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Grundlegende Funktionalitäten der Lootobjekte (hauptsächlich Properties)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="Types.Classes.BaseClasses.BasePP_StringItem"/>
    /// <seealso cref="Types.Classes.BaseClasses.LootObjectContainer{T}"/>
    /// <seealso cref="Types.Classes.BaseClasses.LootFunctionContainer{T}"/>
    public interface ILootable<T>
    {
        #region Properties
        /// <summary>
        /// Gibt das gelootete Objekt aus
        /// </summary>
        T Item { get; }

        /// <summary>
        /// Gibt die Seltenheit des Objektes aus
        /// </summary>
        int Rarity { get; }
        /// <summary>
        /// Gibt den Seltenheitswert als <see cref="string"/> aus
        /// </summary>
        string RarityName { get; }
        /// <summary>
        /// Gibt den Typ des Objekts aus
        /// </summary>
        string Type { get; }
        /// <summary>
        /// Gibt den Namen des Objekts aus
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gibt die Seltenheits-Referenztabelle des Objekts aus (wird normalerweis für RarityName verwendet)
        /// </summary>
        ILootRarityTable rarTable { get; }

        #endregion
    }
}
