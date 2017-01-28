using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Enums;

namespace Loot3Vorbereitung
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(GlobalItems.Instance.GetLoot(
                    new PartitionLoot(),
                    new ConfigurableFilter(
                        StringComparing.NonCaseSensitiveInclude,
                        StringComparing.NonCaseSensitiveEqual,
                        StringComparing.CaseSensitiveEqual,
                        "em",
                        "dummy"
                    )
                ).Generate());

            Console.ReadKey();
        }
    }


}


