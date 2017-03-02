using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.Algorithms.TypeFetching;
using Loot3Framework.Types.Classes.Algorithms.ObjectFetching;

namespace WebTest.LootEngine
{
    public class ItemHandler : BaseLootHolder<string>
    {
        private static ItemHandler instance;

        private ItemHandler() 
            : base(new FetchByInheritance<string>(typeof(ILootable<string>)))
        {
            AddRange(ObjectFetcherAccess<string>.GetObjects());
        }

        public static ItemHandler Instance
        {
            get { return instance ?? (instance = new ItemHandler()); }
        }
    }
}
