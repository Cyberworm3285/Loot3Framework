using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

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
            rarity = 1;
            name = "Item1";
            type = "Dummy1";
            isQuestItem = true;
            attributes = new IItemProperty<string>[]
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
            rarity = 9;
            isQuestItem = false;
            type = "Dummy2";
            attributes = new IItemProperty<string>[]
            {
                new RandomMultiProp(
                    new IItemProperty<string>[]
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
        public Item3() : base("WasGeht")
        {
            rarity = 251;
			type = "Bla";
        }
    }

    public class Item4 : BasePP_StringItem
    {
        public Item4() : base("Jo")
        {
            rarity = 401;
            type = "Ichhoffedasklappt";
        }
    }
    public class Item5 : BasePP_StringItem
    {
        public Item5()
        {
            rarity = 1;
            name = "Item5";
            type = "Dummy5";
            isQuestItem = true;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("Unkaputtbar"),
                new SingleIntervallProp("Basisschaden", new Intervall(5,10)),
                new MultiIntervallProp(
                    new string[]    {   "Normal",              "Krass"             },
                    new Intervall[] {   new Intervall(1,5),    new Intervall(5,10) }),
            };
        }
    }

    public class Item6 : Item1
    {
        public Item6() : base()
        {
            name = "Item6";
            rarity = 11;
            isQuestItem = false;
            type = "Dummy6";
            attributes = new IItemProperty<string>[]
            {
                new RandomMultiProp(
                    new IItemProperty<string>[]
                    {
                        new NameOnlyProp("NameOnly"),
                        new SingleIntervallProp("SingleIntervall", new Intervall(123,1222)),
                    }
                    )
            };
        }
    }

    public class Item7 : BasePP_StringItem
    {
        public Item7() : base("WasGeht")
        {
            rarity = 251;
            type = "Bla";
        }
    }

    public class Item8 : BasePP_StringItem
    {
        public Item8() : base("Jo")
        {
            rarity = 401;
            type = "Ichhoffedasklappt";
        }
    }
}
namespace Containers
{
    public class ContainerProvider : DefaultObjectFetcher<string>
    {
        public ContainerProvider() : base(new ILootable<string>[]
            {
                new LootObjectContainer<string>("Mettwurst2").SetProps(true, "Mettwurst", 599, "Artefakt"),
                new LootFunctionContainer<string>(() => GlobalRandom.Next(13, 667) + " Euronen2").SetProps(true, "Func", 400, "LootFunction"),
                new LootFunctionContainer<string>(() => "!FunctionKek").SetProps(true, "blaaa", 350, "BackFuck"),
                new LootObjectContainer<string>("Achteck").SetProps(true, "Achteck", 260, "Achteck"),
                new LootObjectContainer<string>("Würfel").SetProps(false, "Quader", 450, "Objekt"),
                new LootObjectContainer<string>("Peter").SetProps(false, "Peter", 5, "Sklave"),
                new LootObjectContainer<string>("null").SetProps(false, "null", 25, "leere"),
                new LootObjectContainer<string>("Satan").DoWith(i => i.SetProps(true, "HerrDerSiebenHöllen", 5, "PrimeEvil"))
            }) { }
    }

    public class ContainerProvider2 : ILootObjectFetcher<int>
    {
        public TCollection GetLootObjects<TCollection>() where TCollection : ICollection<ILootable<int>>, new()
        {
            TCollection result = new TCollection();
            new ILootable<int>[]
            {
                new LootObjectContainer<int>(13).SetProps(true, "Zahl", 400, "Integer"),
                new LootFunctionContainer<int>(() => GlobalRandom.Next(0,501)).SetProps(true, "Func<Integer>",500, "Integer"),
            }.DoAction(l => result.Add(l));
            return result;
        }
    }
}
