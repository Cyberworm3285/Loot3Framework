using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Types.Attributes
{
    /// <summary>
    /// Attribut zum Kennzeichnen und Kategorisierung von Loot
    /// </summary>
    /// <seealso cref="Types.Classes.Algorithms.TypeFetching.FetchByLootTags{T}"/>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class LootTagAttribute : Attribute
    {
        /// <summary>
        /// Der gesetzte Tag
        /// </summary>
        readonly string lootTag;
        /// <summary>
        /// Konstruktor, der den Tag setzt
        /// </summary>
        /// <param name="tag"></param>
        public LootTagAttribute(string tag)
        {
            this.lootTag = tag;
        }
        /// <summary>
        /// Gibt den LootTag aus (get-only)
        /// </summary>
        public string LootTag
        {
            get { return lootTag; }
        }
    }
}
