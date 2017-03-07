using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.ExtensionMethods.Other;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    
    public class TypeForwardFetching<T> : ILootTypeFetcher<T>
    {
        Type[] types;

        public TypeForwardFetching(params Type[] _types)
        {
            types = _types;
        }

        public TypeForwardFetching(ILootable<T>[] _types)
        {
            types = Type.GetTypeArray(_types);
        }

        public Type[] GetAllLootableTypes()
        {
            return types;
        }
    }
}
