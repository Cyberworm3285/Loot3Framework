using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    [CLSCompliant(true)]
    public class Multifetching : ILootTypeFetcher
    {
        ILootTypeFetcher[] fetchers;
        ILootTypeFetcher[] excludeFetchers = null;

        public Multifetching(ILootTypeFetcher[] _fetchers, ILootTypeFetcher[] _excludeFetchers)
        {
            fetchers = _fetchers;
            excludeFetchers = _excludeFetchers;
        }

        public Multifetching(ILootTypeFetcher[] _fetchers)
        {
            fetchers = _fetchers;
        }

        public Type[] GetAllLootableTypes()
        {
            HashSet<Type> set = new HashSet<Type>();
            HashSet<Type> excludeSet = new HashSet<Type>();
            fetchers.DoFunc(f => f.GetAllLootableTypes()).ChainUp(set);
            if (!(excludeFetchers == null))
            {
                excludeFetchers.DoFunc(f => f.GetAllLootableTypes()).ChainUp(excludeSet);
                set.RemoveIf(s => excludeSet.HasItemWhere(e => e.IsAssignableFrom(s)));
            }

            return set.ToArray();
        }
    }
}
