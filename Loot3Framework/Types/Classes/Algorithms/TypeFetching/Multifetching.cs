using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    /// <summary>
    /// Sammelt Ergebnisse von verschiedenen Fetchern und schließt ggf. Typen aus, die als Ergebnis von angegebenen Fetchern ausgegeben werden
    /// </summary>
    /// <typeparam name="T">Der zu Lootende Typ</typeparam>
    /// <seealso cref="ILootTypeFetcher{T}"/>
    /// <seealso cref="FetchByInheritance{T}"/>
    /// <seealso cref="FetchByLootTags{T}"/>
    /// <seealso cref="FetchByNamespace{T}"/>
    /// <seealso cref="TypeForwardFetching{T}"/>
    public class Multifetching<T> : ILootTypeFetcher<T>
    {
        private ILootTypeFetcher<T>[] fetchers;
        private ILootTypeFetcher<T>[] excludeFetchers = null;
        /// <summary>
        /// Konstruktor, der die Fetcher und die ausschließenden Fetcher setzt
        /// </summary>
        /// <param name="_fetchers">Die Ausgangsfetcher</param>
        /// <param name="_excludeFetchers">Die ausschließenden Fetcher</param>
        public Multifetching(ILootTypeFetcher<T>[] _fetchers, ILootTypeFetcher<T>[] _excludeFetchers)
        {
            fetchers = _fetchers;
            excludeFetchers = _excludeFetchers;
        }
        /// <summary>
        /// Konstruktor, der die Fetcher setzt
        /// </summary>
        /// <param name="_fetchers">Die Fetcher</param>
        public Multifetching(ILootTypeFetcher<T>[] _fetchers)
        {
            fetchers = _fetchers;
        }
        /// <summary>
        /// Sucht Typen mit angegebenen Fetchern und schlißt ggf Typen der ausschließenden Fetcher aus
        /// </summary>
        /// <returns></returns>
        public Type[] GetAllLootableTypes()
        {
            HashSet<Type> set;
            HashSet<Type> excludeSet;
            set = fetchers.Select(f => f.GetAllLootableTypes()).ToArray().ChainUpToCollection<Type, HashSet<Type>>();
            if (!(excludeFetchers == null))
            {
                excludeSet = excludeFetchers.Select(f => f.GetAllLootableTypes()).ToArray().ChainUpToCollection<Type, HashSet<Type>>();
                set.RemoveIf(s => excludeSet.HasItemWhere(e => e.IsAssignableFrom(s)));
            }

            return set.ToArray();
        }
    }
}
