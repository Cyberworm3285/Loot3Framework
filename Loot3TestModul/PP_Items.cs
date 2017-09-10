using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Attributes;
using Loot3Framework.Types.Classes.BaseClasses;
using Loot3Framework.Types.Classes.ItemProperties;
using Loot3Framework.Global;
using Loot3Framework.Interfaces;

using static Loot3Vorbereitung.CommonProps;

namespace Loot3Vorbereitung
{
    public static class CommonProps
    {
        public static int Rand(int a, int b) => GlobalRandom.Next(a, b + 1);

        public static readonly RandomMultiProp<string> WEAPON_MODIFY_RIFLE 
            = new RandomMultiProp<string>(new NameOnlyProp("[Schallgedämpft]"), new NameOnlyProp("[Kurz]"), new NameOnlyProp("[Kuhl]"), new NameOnlyProp("[Lang]"));

        public static readonly RandomMultiProp<string> WEAPON_MODIFY_PISTOL
            = new RandomMultiProp<string>(new NameOnlyProp("[Schallgedämpft]"), new NameOnlyProp("[Sauber]"), new NameOnlyProp("[Kuhl]"), new NameOnlyProp("[Brutal]"), new NameOnlyProp("[Lang]"));

        public static readonly RandomMultiProp<string> WEAPON_MODIFY_KNIFE
            = new RandomMultiProp<string>(new NameOnlyProp("[Sauber]"), new NameOnlyProp("[Brutal]"));

        public static readonly RandomMultiProp<string> ARMOUR_MODIFY_LIGHT
            = new RandomMultiProp<string>(new NameOnlyProp("[Fancy]"), new NameOnlyProp("[Camouflage]"));

        public static readonly RandomMultiProp<string> ARMOUR_MODIFY_MEDIUM
            = new RandomMultiProp<string>(new NameOnlyProp("[Fancy]"), new NameOnlyProp("[Camouflage]"), new NameOnlyProp("Unauffällig"));

        public static readonly RandomMultiProp<string> ARMOUR_MODIFY_HEAVY
            = new RandomMultiProp<string>(new NameOnlyProp("[Fancy]"), new NameOnlyProp("[Camouflage]"), new NameOnlyProp("UnauffälligER"));
    }


    /*  notes to me, myself and i kek
     *  Lang                    :   ziemlich auffällig und unpraktisch, dafür trifft man aaber besser (+1 auf Hit-Würfe)
     *  Schallgedämpft, Leise   :   unhörbar bis mittlere Distanz 
     *  Brutal                  :   hinterlässt Blutspritzer und ggf. Einzelteile
     *  Sauber                  :   hinterlässt abgesehen von dem Ziel keine Rückstände
     *  Laut                    :   hörbar über längere Distanzen
     *  Still                   :   völlig lautlos
     *  Kuhl                    :   sehr eindrucksvoll
     *  Tödlich                 :   tötet unaufmerksame Ziele One-Hit
     *  Sauerei                 :   das Ziel verwandelt sich in einen Haufen Brei aus Eingeweiden, Knochen und Blut
     *  Volle Heilung           :   heilt das Ziel vollständig
     *  Heilige Auswahl         :   Trifft sämtliche ausgewählte Ziele im Bereich
     *  Kurz                    :   kurzes Design -> weniger auffällig
     *  
     *  Masochist(x)            :   Kostet den Anwender x Lebenspunkte
     *  x Dmg                   :   verursacht x Base-Damage
     *  x Spitzen               :   trifft ein Ziel x mal
     *  x Kugeln/Salve          :   feuert x Kugeln in die Richtung ab
     *  x Kugeln pro Schuss     :   feuert x Kugeln in die Richtung ab
     *  x Heilung               :   heilt das Ziel um x Lebenspunkte bei Erfolg
     */


    #region Bauer

    [LootTag("Bauer")]
    public class Schrotze : BasePP_StringItem
    {
        public Schrotze()
            : base("Schrotze")
        {
            type = "Schrotflinte";
            rarity = 1000;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(3,5)} Kugeln pro Schuss]|[{Rand(1,2)} Dmg][Brutal]"),
            };
        }
    }

    [LootTag("Bauer")]
    public class Harke : BasePP_StringItem
    {
        public Harke()
            : base("Harke")
        {
            type = "Nahkampf";
            rarity = 800;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[Brutal]|[{Rand(4,5)} Spitzen]|[{Rand(1,2)} Dmg]"),
            };
        }
    }

    [LootTag("Bauer")]
    public class Machete : BasePP_StringItem
    {
        public Machete()
            : base("Machete")
        {
            type = "Nahkampf";
            rarity = 800;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[Brutal]|[{Rand(2,3)} Angriffe]|[{Rand(1,2)} Dmg]"),
            };
        }
    }

    [LootTag("Bauer")]
    public class Jagdgewehr : BasePP_StringItem
    {
        public Jagdgewehr()
            : base("Jagdgewehr")
        {
            type = "Sniper";
            rarity = 800;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[Sauber]|[1 Angriff]|[12 Dmg]"),
            };
        }
    }

    [LootTag("Bauer")]
    public class Bandage : BasePP_StringItem
    {
        public Bandage()
            : base("Bandage")
        {
            type = "Medipack";
            rarity = 1000;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(5,10)} Heilung]"),
            };
        }
    }

    [LootTag("Bauer")]
    public class Light_Armour_Bauer : BasePP_StringItem
    {
        public Light_Armour_Bauer()
            : base("Rags")
        {
            type = "Leichte Rüstung";
            rarity = 1000;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[1 Dmg Reduction]"),
                ARMOUR_MODIFY_LIGHT
            };
        }
    }

    #endregion

    #region Soldat

    [LootTag("Soldat")]
    public class AMR16 : BasePP_StringItem
    {
        public AMR16()
            : base("AMR-16")
        {
            type = "Sturmkarabiner";
            rarity = 800;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(20,30)} Schuss]|[{Rand(2,4)} Schuss/Salve]|[{Rand(3,4)} Dmg]"),
                WEAPON_MODIFY_RIFLE
            };
        }
    }

    [LootTag("Soldat")]
    public class F2000 : BasePP_StringItem
    {
        public F2000()
            : base("F-2000")
        {
            type = "Sturmkarabiner";
            rarity = 500;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(25,30)} Schuss]|[{Rand(4,5)} Schuss/Salve]|[{Rand(2,4)} Dmg]"),
                WEAPON_MODIFY_RIFLE
            };
        }
    }

    [LootTag("Soldat")]
    public  class M24 : BasePP_StringItem
    {
        public M24()
            : base("M24")
        {
            type = "Sniper";
            rarity = 400;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Schuss]|[18 Dmg][Sauber]"),
                WEAPON_MODIFY_RIFLE
            };
        }
    }

    [LootTag("Soldat")]
    public class M1911 : BasePP_StringItem
    {
        public M1911()
            : base("M1911")
        {
            type = "Pistole";
            rarity = 550;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Schuss]|[{Rand(2,4)} Dmg]"),
                WEAPON_MODIFY_PISTOL
            };
        }
    }

    [LootTag("Soldat")]
    public class Tanto : BasePP_StringItem
    {
        public Tanto()
            : base("Tanto")
        {
            type = "Nahkampf";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(20,25)} Dmg]"),
                WEAPON_MODIFY_KNIFE
            };
        }
    }

    [LootTag("Soldat")]
    public class ErsteHilfe : BasePP_StringItem
    {
        public ErsteHilfe()
            : base("ErsteHilfe")
        {
            type = "Medipack";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(10,15)} Heilung]"),
            };
        }
    }

    [LootTag("Soldat")]
    public class MCS870 : BasePP_StringItem
    {
        public MCS870()
            : base("870-MCS")
        {
            type = "Schrotflinte";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,5)} Kugeln pro Schuss]|[Brutal]|[{Rand(2,4)} Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    public class Light_Armour_Soldat : BasePP_StringItem
    {
        public Light_Armour_Soldat()
            : base("Standard Körperpanzer")
        {
            type = "Leichte Rüstung";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(2,3)} Dmg Reduction]"),
                ARMOUR_MODIFY_LIGHT
            };
        }
    }

    [LootTag("Soldat")]
    public class Medium_Armour_Soldat : BasePP_StringItem
    {
        public Medium_Armour_Soldat()
            : base("Mittlere Körperpanzer")
        {
            type = "Mittlere Rüstung";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(3,5)} Dmg Reduction]"),
                ARMOUR_MODIFY_MEDIUM
            };
        }
    }

    [LootTag("Soldat")]
    public class Heavy_Armour_Soldat : BasePP_StringItem
    {
        public Heavy_Armour_Soldat()
            : base("Schwere Körperpanzer")
        {
            type = "Schwere Rüstung";
            rarity = 700;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Dmg Reduction]"),
                ARMOUR_MODIFY_HEAVY
            };
        }
    }

    #endregion
    #region EliteSoldat

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class M95 : BasePP_StringItem
    {
        public M95()
            : base("M95")
        {
            type = "Sniper";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Schuss]|[25 Dmg][Brutal][Laut]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class AK416 : BasePP_StringItem
    {
        public AK416()
            : base("AK416")
        {
            type = "Sturmgewehr";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(25,35)} Schuss]|[{Rand(2,4)} Schuss/Salve]|[{Rand(5,8)} Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class M14Carbon : BasePP_StringItem
    {
        public M14Carbon()
            : base("M14 Carbon")
        {
            type = "DMR";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(12,18)} Schuss]|[2 Schuss/Salve]|[{Rand(13,15)} Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class ZweiteHilfe : BasePP_StringItem
    {
        public ZweiteHilfe()
            : base("ZweiteHilfe")
        {
            type = "Medipack";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(15,20)} Heilung]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class SPAS12 : BasePP_StringItem
    {
        public SPAS12()
            : base("SPAS-12")
        {
            type = "Schrotflinte";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Kugeln pro Schuss]|[Brutal]|[{Rand(5,8)} Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class Light_Armour_Elite_Soldat : BasePP_StringItem
    {
        public Light_Armour_Elite_Soldat()
            : base("Leichter Kampfpanzer")
        {
            type = "Leichte Rüstung";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(3,5)} Dmg Reduction]"),
                ARMOUR_MODIFY_LIGHT
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class Medium_Armour_Elite_Soldat : BasePP_StringItem
    {
        public Medium_Armour_Elite_Soldat()
            : base("Mittlerer Kampfpanzer")
        {
            type = "Mittlere Rüstung";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(4,6)} Dmg Reduction]"),
                ARMOUR_MODIFY_MEDIUM
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    public class Heavy_Armour_Elite_Soldat : BasePP_StringItem
    {
        public Heavy_Armour_Elite_Soldat()
            : base("Schwerer Kampfpanzer")
        {
            type = "Schwere Rüstung";
            rarity = 100;
            attributes = new IItemProperty<string>[]
            {
                new FuncProp<string>(() => $"[{Rand(5,8)} Dmg Reduction]"),
                ARMOUR_MODIFY_HEAVY
            };
        }
    }

    #endregion
    #region Boss

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class DerLeiseTod : BasePP_StringItem
    {
        public DerLeiseTod()
            : base("DerLeiseTod")
        {
            type = "Sniper";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[5 Schuss][Still][Sauber][Kuhl][30 Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class AzraelsDolch : BasePP_StringItem
    {
        public AzraelsDolch()
            : base("Azraels Dolch")
        {
            type = "Nahkampf";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[Laut][Sauber][Kuhl][Tödlich][Masochist(5)]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class LVOAC_Gore : BasePP_StringItem
    {
        public LVOAC_Gore()
            : base("LVOA-C Gore")
        {
            type = "Sturmkarabiner";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[Still][Sauerei][Kuhl][40 Schuss][4 Schuss/Salve][10 Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class Deagle : BasePP_StringItem
    {
        public Deagle()
            : base("Deagle")
        {
            type = "Pistole";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[Laut][Brutal][Kuhl][12 Schuss][15 Dmg]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class SatansTraene : BasePP_StringItem
    {
        public SatansTraene()
            : base("SatansTräne")
        {
            type = "Medipack";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[Volle Heilung]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class HeiligeOffensive : BasePP_StringItem
    {
        public HeiligeOffensive()
            : base("Heilge Offensive")
        {
            type = "Schrotflinte";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[Heilige Auswahl]|[6 Dmg][Brutal][Masochist(0.5)]"),
            };
        }
    }

    [LootTag("Soldat")]
    [LootTag("EliteSoldat")]
    [LootTag("Boss")]
    public class Armour_Boss : BasePP_StringItem
    {
        public Armour_Boss()
            : base("Mythril Haut")
        {
            type = "Leichte Rüstung";
            rarity = 10;
            attributes = new IItemProperty<string>[]
            {
                new NameOnlyProp("[9 Dmg Reduction]"),
                ARMOUR_MODIFY_LIGHT
            };
        }
    }

    #endregion
}
