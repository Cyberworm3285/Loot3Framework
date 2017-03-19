using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Global;
using Loot3Framework.Types.Structs;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.Types.Classes.Comperators;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    /// <summary>
    /// Lootalgorithmus, der erst aus einer Seltenheits-Referenztabelle auswählt und dann mit einem inneren Algorithmus das lootobjekt auswählt 
    /// </summary>
    /// <typeparam name="T">Der zu lootende Type</typeparam>
    /// <typeparam name="TLooter">Der Typ des inneren Algorithmusses</typeparam>
    /// <seealso cref="ILootingAlgorithm{T}"/>
    /// <seealso cref="PartitionLoot{T}"/>
    /// <seealso cref="RandomLoot{T}"/>
    public class PR_PartionLoot<T, TLooter> : ILootingAlgorithm<T> where TLooter : ILootingAlgorithm<T>
    {
        /// <summary>
        /// Die benutzte Seltenheits-Referenztabelle
        /// </summary>
        protected ILootRarityTable rarTable;
        /// <summary>
        /// Die Wahrscheinlichkeit für die letzte ausgewählte Wahrscheinlichkeit 
        /// </summary>
        protected double lastProp;
        /// <summary>
        /// Der Zufalswert für die letzte ausgewählte Wahrscheinlichkeit
        /// </summary>
        protected int lastRandomRoll;
        /// <summary>
        /// Die letzte gesamte Seltenheits-Strecke
        /// </summary>
        protected Intervall lastEntireRarRange;
        /// <summary>
        /// Die Länge der letzten ausgewählten Seltenheit auf der Seltenheits-Strecker 
        /// </summary>
        protected Intervall lastRarRange;
        /// <summary>
        /// Der Name der letzten ausgewählten Seltenheit
        /// </summary>
        protected string lastRarName;
        /// <summary>
        /// Zugriff auf den benutzen inneren Algorithmus
        /// </summary>
        protected TLooter lastLootingAlgorithm;

        /// <summary>
        /// Konstruktor, der die Sletneheits-Referenztabelle, den inneren Algorithmus und die benutzerdfinierten erlaubten Seltenheiten setzt
        /// </summary>
        /// <param name="table">Die Seltenheits-Referenztabelle</param>
        /// <param name="innerLooting">Der innere Algorithmus</param>
        /// <param name="allowedRarityNames">Die benutzerdifinierten erlaubten Seltenheiten</param>
        public PR_PartionLoot(ILootRarityTable table, TLooter innerLooting, string[] allowedRarityNames)
        {
            lastLootingAlgorithm = innerLooting;
            allowedRarityNames = allowedRarityNames.DoWith(s => Array.Sort(s, new RarTableOrderComperator(table)));
            List<string> allowedNames = new List<string>();
            List<int> allowedRanges = new List<int>();
            int counter = 0;

            for (int i = 0; i < table.Values.Length; i++)
            {
                if (allowedRarityNames.Contains(table.Values[i]))
                {
                    counter += table.Chain.Intervalls[i].Range;
                    allowedRanges.Add(counter);
                    allowedNames.Add(table.Values[i]);
                }
            }
            rarTable = new DynamicRarityTable(allowedNames.ToArray(), new IntervallChain(allowedRanges.ToArray(), startValue: 0));
        }
        /// <summary>
        /// Konstruktor, der die Sletneheits-Referenztabelle und den inneren Algorithmus  setzt
        /// </summary>
        /// <param name="table">Die Seltenheits-Referenztabelle</param>
        /// <param name="innerLooting">Der innere Algorithmus</param>
        public PR_PartionLoot(ILootRarityTable table, TLooter innerLooting)
        {
            lastLootingAlgorithm = innerLooting;
            rarTable = table;
        }
        /// <summary>
        /// Wählt erst eine Seltenheit aus und dann durch den inneren Algorithmus das finale Loot-Objekt
        /// </summary>
        /// <param name="allLoot">Das ursprüngliche gesamte Loot</param>
        /// <returns>Das gelootete Objekt</returns>
        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            int lowest = rarTable.Chain.Intervalls.First().X;
            int highest = rarTable.Chain.Intervalls.Last().Y;
            lastEntireRarRange = new Intervall(lowest, highest);
            lastRandomRoll = GlobalRandom.Next(lowest + 1, highest + 1);
            int intervallIndex = Array.FindIndex(rarTable.Chain.Intervalls, i => i.X <= lastRandomRoll && i.Y >= lastRandomRoll);
            lastRarRange = rarTable.Chain.Intervalls[intervallIndex];
            lastProp = 100 / (double)(highest - lowest) * (double)lastRarRange.Range;
            lastRarName = rarTable.Values[intervallIndex];
            return lastLootingAlgorithm.Loot(allLoot.Where(i => i.Rarity > lastRarRange.X && i.Rarity <= lastRarRange.Y).ToArray());
        }
        /// <summary>
        /// Die benutzte Seltenheits-Referenztabelle
        /// </summary>
        public ILootRarityTable Table
        {
            get { return rarTable; }
            set { rarTable = value; }
        }
        /// <summary>
        /// Die Wahrscheinlichkeit für die letzte ausgewählte Wahrscheinlichkeit 
        /// </summary>
        public double LastProbability
        {
            get { return lastProp; }
        }
        /// <summary>
        /// Der Zufalswert für die letzte ausgewählte Wahrscheinlichkeit
        /// </summary
        public int LastRoll
        {
            get { return lastRandomRoll; }
        }
        /// <summary>
        /// Die letzte gesamte Seltenheits-Strecke
        /// </summary>
        public Intervall LastRarityRange
        {
            get { return lastRarRange; }
        }
        /// <summary>
        /// Der Name der letzten ausgewählten Seltenheit
        /// </summary>
        public string LastRarity
        {
            get { return lastRarName; }
        }
        /// <summary>
        /// Zugriff auf den benutzen inneren Algorithmus
        /// </summary>
        public TLooter InnerAlgorithm
        {
            get { return lastLootingAlgorithm; }
        }
    }
}
