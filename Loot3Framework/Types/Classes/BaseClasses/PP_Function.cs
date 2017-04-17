using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Loot3Framework.Interfaces; 

namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// Überschreibt den standard Output von <see cref="LootFunctionContainer{T}"/> mit PP-String Formattierungen
    /// <para>Formatierung: --Name + "|" + Type + "|" + $Die Funtkion$ + "|[" + RarityName + "]"--</para>
    /// </summary>
    /// <seealso cref="LootFunctionContainer{T}"/>
    /// <see cref="LootObjectContainer{T}"/>
    public class PP_Function : LootFunctionContainer<string> 
    {
        /// <summary>
        /// Konstruktor, der die Loot-Funktion setzt
        /// </summary>
        /// <param name="function">Die Loot-Funktion</param>
        /// <param name="representation">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public PP_Function(Func<string> function, string representation = null) 
            : base(function, representation) { }
        /// <summary>
        /// Konstruktor, der die Loot-Funktion und die Seltenheits-Refernztabelle setzt
        /// </summary>
        /// <param name="function">Die Loot-Funktion</param>
        /// <param name="table">Die Seltenheits-Referenztabelle</param>
        /// <param name="representation">Optionaler <see cref="string"/> für benutzerdefinierte Repräsentation in ToString()</param>
        public PP_Function(Func<string> function, ILootRarityTable table, string representation = null) 
            : base(function, table, representation) { }
        /// <summary>
        /// Überschreibt die Ursprungsfunktion mit PP Formattierung
        /// <para>Formatierung: --Name + "|" + Type + "|" + $Die Funtkion$ + "|[" + RarityName + "]"--</para>
        /// </summary>
        public override string Item => Name + "|" + Type + "|" + innerFunction() + "|[" + RarityName + "]";
    }
}
