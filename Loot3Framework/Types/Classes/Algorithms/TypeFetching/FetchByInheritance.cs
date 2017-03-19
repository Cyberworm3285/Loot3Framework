using System;
using System.Collections.Generic;
using System.Linq;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    /// <summary>
    /// Sucht Loot-Typen anhand ihre Abstammung von dem angebenen Typ (Klassen/ Interfaces)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootTypeFetcher{T}"/>
    /// <seealso cref="FetchByLootTags{T}"/>
    /// <seealso cref="FetchByNamespace{T}"/>
    /// <seealso cref="Multifetching{T}"/>
    /// <seealso cref="TypeForwardFetching{T}"/>
    public class FetchByInheritance<T> : ILootTypeFetcher<T>
    {
        private List<Type> types;
        private Type baseType;

        /// <summary>
        /// Konstruktor der den Basis-Typ setzt
        /// </summary>
        /// <param name="_baseType"></param>
        public FetchByInheritance(Type _baseType)
        {
            types = new List<Type>();
            baseType = _baseType;
            
        }
        /// <summary>
        /// Sucht alle Typen anhand ihrer Abstammung zum Basis-Typ 
        /// </summary>
        /// <returns>Alle gültigen Typen</returns>
        public Type[] GetAllLootableTypes()
        {
            Type typooo = typeof(Loot3Framework.Types.Classes.BaseClasses.BasePP_StringItem);
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && t.HasNonParameterConstructor() && !t.IsGenericType)));
            return types.ToArray();;
        }
    }
}
