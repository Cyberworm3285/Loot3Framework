using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    [CLSCompliant(true)]
    public class FetchByInheritance : ILootTypeFetcher
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
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && t.HasNonParameterConstructor())));
            return types.ToArray();;
        }
    }
}
