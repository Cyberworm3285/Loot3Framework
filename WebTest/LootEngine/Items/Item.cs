﻿using System;
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
using Loot3Framework.Types.Attributes;

namespace Items
{
    [LootTag("Space")]
    [LootTag("Pirate")]
    public class Item : BasePP_StringItem
    {
        public Item()
        {
            name = "Item1";
            type = "Both1";
            isQuestItem = true;
            attributes = new IItemProperty[]
            {
                new NameOnlyProp("Unkaputtbar"),
                new SingleIntervallProp("Basisschaden", new Intervall(5,10)),
                new MultiIntervallProp( 
                    new string[]    {   "Schaden(Normal)",      "Schaden(Krass)"    },
                    new Intervall[] {   new Intervall(1,5),     new Intervall(5,10) }),
            };
        }
    }
    [LootTag("Space")]
    public class Item2 : Item
    {
        public Item2() : base()
        {
            name = "Item2";
            rarity = 50;
            isQuestItem = false;
            type = "Space2";
            attributes = new IItemProperty[]
            {
                new RandomMultiProp(
                    new IItemProperty[]
                    {
                        new NameOnlyProp("NameOnly"),
                        new SingleIntervallProp("Energie Schaden", new Intervall(123,1222)),
                    }
                    )
            };
        }
    }
    [LootTag("Pirate")]
    public class Item3 : BasePP_StringItem
    {
        public Item3() : base("Item3")
        {
            rarity = 400;
			type = "Pirates1";
            rarityTable = new RarityForwardTable("FischermensFriend");
            attributes = new IItemProperty[]
            {
                new SingleIntervallProp("Draufhauen", new Intervall(0,133))
            };
        }
    }
}
namespace Containers
{
    public class ContainerProvider : DefaultObjectFetcher<string>
    {
        public ContainerProvider() : base(new ILootable<string>[]
            {
                new LootObjectContainer<string>("Mettwurst").SetProps(null, true, "Mettwurst", 599, "Artefakt"),
                new LootFunctionContainer<string>(() => GlobalRandom.Next(13, 667) + " Euronen").SetProps(null, true, "Func", 400, "LootFunction"),
            }) { }
    }
}