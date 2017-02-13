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

        public Multifetching(params ILootTypeFetcher[] _fetchers)
        {
            fetchers = _fetchers;
        }

        public Type[] GetAllLootableTypes()
        {
            List<Type> result = new List<Type>();
            fetchers.DoAction(f => result.AddRange(f.GetAllLootableTypes().DoConditionalFunc(t => t, t => !result.Contains(t))));
            return result.ToArray();
        }
    }
}
