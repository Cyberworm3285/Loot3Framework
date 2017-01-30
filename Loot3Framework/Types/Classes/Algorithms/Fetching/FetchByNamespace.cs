using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    public class FetchByNamespace : ILootTypeFetcher
    {
        string spaceName;
        Assembly[] currAssemblies;

        public FetchByNamespace(string _spaceName, Assembly[] _currAssemblies)
        {
            spaceName = _spaceName;
            currAssemblies = _currAssemblies;
        }

        public FetchByNamespace(string _spaceName)
        {
            spaceName = _spaceName;
            currAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        public Type[] GetAllLootableTypes()
        {
            List<Type> types = new List<Type>();
            currAssemblies.ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => t.Namespace == spaceName && t.GetInterfaces().Contains(typeof(ILootable)) && t.HasNonParameterConstructor()).ToArray()));
            return types.ToArray();
        }
    }
}
