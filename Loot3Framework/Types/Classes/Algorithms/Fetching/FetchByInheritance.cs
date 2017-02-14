using System;
using System.Collections.Generic;
using System.Linq;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    [CLSCompliant(true)]
    public class FetchByInheritance<T> : ILootTypeFetcher<T>
    {
        List<Type> types;
        Type baseType;

        public FetchByInheritance(Type _baseType)
        {
            types = new List<Type>();
            baseType = _baseType;
            
        }

        public Type[] GetAllLootableTypes()
        {
            Type typooo = typeof(Loot3Framework.Types.Classes.BaseClasses.BasePP_StringItem);
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && t.HasNonParameterConstructor() && !t.IsGenericType)));
            return types.ToArray();;
        }
    }
}
