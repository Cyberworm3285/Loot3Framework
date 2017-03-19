using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.ExtensionMethods.Other;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    /// <summary>
    /// Reicht die angegebenen Typen einfach weiter (Benutzer kümmert sich um Richtigkeit)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootTypeFetcher{T}"/>
    /// <seealso cref="FetchByInheritance{T}"/>
    /// <seealso cref="FetchByLootTags{T}"/>
    /// <seealso cref="FetchByNamespace{T}"/>
    /// <seealso cref="Multifetching{T}"/>
    public class TypeForwardFetching<T> : ILootTypeFetcher<T>
    {
        private Type[] types;

        /// <summary>
        /// Konstruktor, der bereits die finalen Werte setzt (Gültigkeit ist unsicher)
        /// </summary>
        /// <param name="_types"></param>
        public TypeForwardFetching(params Type[] _types)
        {
            types = _types;
        }
        /// <summary>
        /// Konstruktor, der bereits die finalen Werte setzt (Gültigkeit ist sicher)
        /// </summary>
        /// <param name="_types"></param>
        public TypeForwardFetching(ILootable<T>[] _types)
        {
            types = Type.GetTypeArray(_types);
        }
        /// <summary>
        /// Gibt die gespeicherten Typen aus
        /// </summary>
        /// <returns>Die gespeicherten Typen</returns>
        public Type[] GetAllLootableTypes()
        {
            return types;
        }
    }
}
