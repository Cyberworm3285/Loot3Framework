using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.ExtensionMethods.Other;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    public class TypeForwardFetching : ILootTypeFetcher
    {
        Type[] types;

        public TypeForwardFetching(Type[] _types)
        {
            if (!_types.All(t => t.GetInterfaces().Contains(typeof(ILootable)) && t.HasNonParameterConstructor()))
                throw new Exception();
            types = _types;
        }

        public TypeForwardFetching(ILootable[] _types)
        {
            types = Type.GetTypeArray(_types);
        }

        public Type[] GetAllLootableTypes()
        {
            return types;
        }
    }
}
