using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.ObjectFetching
{
    public static class ObjectFetcherAccess<T> 
    {
        public static ILootable<T>[] GetObjects()
        {
            List<Type> types = new List<Type>();
            AppDomain.CurrentDomain.GetAssemblies().DoAction(a => a.GetTypes().DoConditionalAction(t => types.Add(t), t => t.GetInterfaces().Contains(typeof(ILootObjectFetcher<T>))));
            List<ILootable<T>> objects = types.ToArray().GetInstances().DoFunc(
                i => i as ILootObjectFetcher<T>).DoFunc(
                    f => f.GetLootObjects<List<ILootable<T>>>()).ChainUpToCollection<ILootable<T>, List<ILootable<T>>>();
            return objects.ToArray();
        }
    }
}
