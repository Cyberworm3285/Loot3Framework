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
    public class GlobalItems : BaseLootHolder<string>
    {
        private static GlobalItems instance = null;

        private GlobalItems() : base(
            new Multifetching<string>(
                new ILootTypeFetcher<string>[] 
                {
                    new FetchByInheritance<string>(typeof(ILootable<string>))
                }, 
                new ILootTypeFetcher<string>[]
                {
                    new FetchByInheritance<string>(typeof(Exception))
                }
            )
        )
        {
            int counter = 1;
            allLoot.DoAction(l => Console.WriteLine(counter++ + ": " + l.Item));
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
