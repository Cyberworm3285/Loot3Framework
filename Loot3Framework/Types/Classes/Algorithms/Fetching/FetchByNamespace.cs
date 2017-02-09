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
    [CLSCompliant(true)]
    public class FetchByNamespace : ILootTypeFetcher
    {
        string[] spaceNames;
        Assembly[] currAssemblies;

        public FetchByNamespace(string[] _spaceNames, Assembly[] _currAssemblies)
        {
            spaceNames = _spaceNames;
            currAssemblies = _currAssemblies;
        }

        public FetchByNamespace(string _spaceName)
        {
            spaceNames = new string[] { _spaceName };
            currAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        public Type[] GetAllLootableTypes()
        {
            List<Type> types = new List<Type>();
            currAssemblies.ToList().ForEach(a => types.AddRange(a.GetTypes().Where(t => spaceNames.Contains(t.Namespace) && t.GetInterfaces().Contains(typeof(ILootable)) && t.HasNonParameterConstructor()).ToArray()));
            return types.ToArray();
        }
    }
}
