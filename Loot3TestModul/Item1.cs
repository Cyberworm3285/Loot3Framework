using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.Types.Classes.ItemProperties;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.Global;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Items
{
    public class Item1 : BasePP_StringItem
    {
        public Item1()
        {
            name = "Item1";
            type = "Dummy1";
            isQuestItem = true;
            attributes = new IItemProperty[]
            {
                new NameOnlyProp("Unkaputtbar"),
                new SingleIntervallProp("Basisschaden", new Intervall(5,10)),
                new MultiIntervallProp( 
                    new string[]    {   "Normal",              "Krass"             },
                    new Intervall[] {   new Intervall(1,5),    new Intervall(5,10) }),
            };
        }
    }

    public class Item2 : Item1
    {
        public Item2() : base()
        {
            name = "Item2";
            rarity = 50;
            isQuestItem = false;
            type = "Dummy2";
            attributes = new IItemProperty[]
            {
                new RandomMultiProp(
                    new IItemProperty[]
                    {
                        new NameOnlyProp("NameOnly"),
                        new SingleIntervallProp("SingleIntervall", new Intervall(123,1222)),
                    }
                    )
            };
        }
    }

    public class Item3 : BasePP_StringItem
    {
        public Item3() : base("testnummertausend")
        {
            rarity = 400;
			type = "Ichhoffedasklappt";
            rarityTable = new RarityForwardTable("FischermensFriend");
        }
    }
}
namespace ExItems
{
    public class LootableExceptionLol : Exception, ILootable<string>
    {
        public LootableExceptionLol() : base("lol") { }

        public string[] AllowedAreas
        {
            get
            {
                return new string[] { };
            }
        }

        public bool IsQuestItem
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "ExceptionItem";
            }
        }

        public int Rarity
        {
            get
            {
                return 10;
            }
        }

        public string RarityName
        {
            get
            {
                return "ExceptionalRarity";
            }
        }

        public string Type
        {
            get
            {
                return "Exception";
            }
        }

        public string Item
        {
            get
            {
                throw this;
            }
        }
    }

    public class ExceptionLootLol : ILootable<Exception>
    {
        public string[] AllowedAreas
        {
            get
            {
                return new string[] { };
            }
        }

        public bool IsQuestItem
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "ItemException";
            }
        }

        public int Rarity
        {
            get
            {
                return 10;
            }
        }

        public string RarityName
        {
            get
            {
                return "ExceptionalRarity";
            }
        }

        public string Type
        {
            get
            {
                return "Exception";
            }
        }

        public Exception Item
        {
            get
            {
                return new Exception();
            }
        }
    }
}
namespace Containers
{
    public class ContainerProvider : ILootObjectFetcher<string>
    {
        TCollection ILootObjectFetcher<string>.GetLootObjects<TCollection>()
        {
            TCollection result = new TCollection();
            new ILootable<string>[]
            {
                new LootObjectContainer<string>("Mettwurst").SetProps(null, true, "Mettwurst", 599, "Artefakt"),
                new LootFunctionContainer<string>(() => GlobalRandom.Next(13, 667) + " Euronen").SetProps(null, true, "Func", 400, "LootFunction"),
            }.DoAction(l => result.Add(l));
            return result;
        }
    }
}
