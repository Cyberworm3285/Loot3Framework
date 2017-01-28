using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
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
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)));
            return types.ToArray();;
        }
    }
}
