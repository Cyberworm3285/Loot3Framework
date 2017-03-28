using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.TypeFetching;
using Loot3Framework.Types.Classes.EventArguments;

namespace Loot3Vorbereitung
{
    public class GlobalItems : BaseLootHolder<string>
    {
        private static GlobalItems instance;
        private ILootable<string>[] allowedItems;

        public override ILootable<string> GetLoot(ILootingAlgorithm<string> algo)
        {
            return algo.Loot(allowedItems);
        }

        public override ILootable<string> GetLoot(ILootingAlgorithm<string> algo, ILootFilter filter)
        {
            return algo.Loot(filter.Filter(allowedItems));
        }

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
            allowedItems = allLoot.ToArray();
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

        public ILootable<string>[] AllowedLoot
        {
            get
            {
                return allowedItems;
            }
            set
            {
                allowedItems = value;
            }
        }

        #endregion
    }
}
