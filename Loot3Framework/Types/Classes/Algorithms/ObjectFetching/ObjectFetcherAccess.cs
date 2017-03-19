using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.ObjectFetching
{
    /// <summary>
    /// Sucht alle Assemblies in der momentanen App-Domain nach Object-Fetchern und gibt alle Objekte aus
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="Types.Classes.BaseClasses.LootObjectContainer{T}"/>
    public static class ObjectFetcherAccess<T> 
    {
        /// <summary>
        /// Gibt alle gefundenen Objekte aus
        /// </summary>
        /// <returns>Alle gefundenen Objekte</returns>
        public static ILootable<T>[] GetObjects()
        {
            List<Type> types = new List<Type>();
            AppDomain.CurrentDomain.GetAssemblies().DoAction(a => a.GetTypes().DoConditionalAction(t => types.Add(t), t => t.GetInterfaces().Contains(typeof(ILootObjectFetcher<T>))));
            List<ILootable<T>> objects = types.ToArray().GetInstances().Select(
                i => i as ILootObjectFetcher<T>).Select(
                    f => f.GetLootObjects<List<ILootable<T>>>()).ToArray().ChainUpToCollection<ILootable<T>, List<ILootable<T>>>();
            return objects.ToArray();
        }
    }
}
