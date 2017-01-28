using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.BaseClasses;

namespace Loot3Framework.Types.Classes.Algorithms.Fetching
{
    public class FetchByNamespace : ILootTypeFetcher
    {
        string spaceName;
        Assembly currAssembly;

        public FetchByNamespace(Assembly _currAssembly, string _spaceName)
        {
            spaceName = _spaceName;
            currAssembly = _currAssembly;
        }

        public Type[] GetAllLootableTypes()
        {
            return currAssembly.GetTypes().Where(t => t.Namespace == spaceName && t.GetInterfaces().Contains(typeof(ILootable))).ToArray();
        }
    }
}
