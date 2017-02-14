using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.Fetching;

namespace Loot3Vorbereitung
{
    public class GlobalItems : BaseLootHolder
    {
        private static GlobalItems instance = null;

        private GlobalItems() : base(new Multifetching(
            new ILootTypeFetcher[] {
                new FetchByInheritance(typeof(BaseItem)) } ))
        {
            int counter = 1;
            allLoot.DoAction(l => Console.WriteLine(counter++ + ": " + l.Generate()));
        }

        #region Properties

        public static GlobalItems Instance
        {
            get
            {
                return instance ?? (instance = new GlobalItems());
            }
        }

        #endregion
    }
}
