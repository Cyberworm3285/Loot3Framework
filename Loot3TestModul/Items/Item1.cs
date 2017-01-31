using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.Types.Classes.ItemProperties;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Vorbereitung.Items
{
    public class Item1 : BaseItem
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
            rarity = 500;
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
}
