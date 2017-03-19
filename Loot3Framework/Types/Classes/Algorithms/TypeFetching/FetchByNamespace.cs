using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks
using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    /// <summary>
    /// Sucht Typen anhand ihrer Namespace-Zugehörigkeit heraus
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootTypeFetcher{T}"/>
    /// <seealso cref="FetchByInheritance{T}"/>
    /// <seealso cref="FetchByLootTags{T}"/>
    /// <seealso cref="Multifetching{T}"/>
    /// <seealso cref="TypeForwardFetching{T}"/>
    public class FetchByNamespace<T> : ILootTypeFetcher<T>
    {
        private string[] spaceNames;
        private Assembly[] currAssemblies;

        /// <summary>
        /// Konstruktor der die Namespace-Namen und die zu durchsuchenden Assemblies setzt
        /// </summary>
        /// <param name="_spaceNames">Die Namespace-Namen</param>
        /// <param name="_currAssemblies">Die zu durchsuchenden Assemblies</param>
        public FetchByNamespace(string[] _spaceNames, Assembly[] _currAssemblies)
        {
            spaceNames = _spaceNames;
            currAssemblies = _currAssemblies;
        }
        /// <summary>
        /// Konstruktor der den Namespace-Namen setzt
        /// </summary>
        /// <param name="_spaceName">Der Namespace-Name</param>
        public FetchByNamespace(string _spaceName)
        {
            spaceNames = new string[] { _spaceName };
            currAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        }
        /// <summary>
        /// Sucht alle gültigen Typen in den angegebenen Namespaces (ggf in den angegebenen Assemblies)
        /// </summary>
        /// <returns></returns>
        public Type[] GetAllLootableTypes()
        {
            List<Type> types = new List<Type>();
            currAssemblies.ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => spaceNames.Contains(t.Namespace) && t.GetInterfaces().Contains(typeof(ILootable<T>)) && t.HasNonParameterConstructor()).ToArray()));
            return types.ToArray();
        }
    }
}
