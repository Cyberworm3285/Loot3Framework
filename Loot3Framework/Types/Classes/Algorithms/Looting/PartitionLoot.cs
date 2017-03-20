using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;
using Loot3Framework.Global;
using Loot3Framework.Types.Exceptions;
using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.Algorithms.Looting
{
    /// <summary>
    /// Loot-Algorithmus, der auf Partitionierung der "Seltenheits-Strecke" anhand des Rarity-Attributes setzt und so das variable Vorkommen umsetzt
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootingAlgorithm{T}"/>
    /// <seealso cref="Intervall"/>
    /// <seealso cref="IntervallChain"/>
    /// <seealso cref="PR_PartionLoot{T, TLooter}"/>
    /// <seealso cref="RandomLoot{T}"/>
    public class PartitionLoot<T> : ILootingAlgorithm<T>
    {
        private static PartitionLoot<T> instance;

        /// <summary>
        /// Der letzte Zufallswert
        /// </summary>
        protected int lastRandomRoll;
        /// <summary>
        /// Die letzte Gesamtlänge der "Loot-Strecke" 
        /// </summary>
        protected int lastEntireRange;
        /// <summary>
        /// Die letzte "Loot-Strecke" als <see cref="IntervallChain"/>
        /// </summary>
        protected IntervallChain lastInnerChain;
        /// <summary>
        /// Das letzte ausgewählte <see cref="Intervall"/>
        /// </summary>
        protected Intervall lastUsedIntervall;
        /// <summary>
        /// Alle letzten Namen der Items in der "Loot-Strecke" 
        /// </summary>
        protected string[] allLastItemNames;
        /// <summary>
        /// Alle letzten Rarity-Attribute der Items in der "Loot-Strecke"
        /// </summary>
        protected int[] allLastItemRarities;

        private PartitionLoot() { }

        /// <summary>
        /// Wählt aus dem Input <see cref="Array"/> ein Objekt aus und gibt dieses zurück
        /// </summary>
        /// <param name="allLoot">Das gesamte Ausgangsmaterial</param>
        /// <returns>Das EINE Loot</returns>
        /// <exception cref="NoMatchingLootException">Bei leerem Input</exception>
        public ILootable<T> Loot(ILootable<T>[] allLoot)
        {
            if (allLoot.Length.Equals(0))
                throw new NoMatchingLootException("no input items");
            int counter = 0;
            int j = 0;
            allLastItemNames = new string[allLoot.Length];
            allLastItemRarities = new int[allLoot.Length];
            lastInnerChain = new IntervallChain((allLoot.Select(l => {
                allLastItemNames[j] = l.Name;
                allLastItemRarities[j++] = l.Rarity;
                return counter += l.Rarity;
            })).ToArray(), 0);
            lastEntireRange = counter;
            lastRandomRoll = GlobalRandom.Next(0, counter);
            int index = Array.FindIndex(lastInnerChain.Intervalls, i => i.X <= lastRandomRoll && i.Y >= lastRandomRoll);
            lastUsedIntervall = lastInnerChain.Intervalls[index];
            return allLoot[index];
        }

        #region Properties

        /// <summary>
        /// Der letzte Zufallswert
        /// </summary>
        public int LastRoll
        {
            get { return lastRandomRoll; }
        }
        /// <summary>
        /// Die letzte Gesamtlänge der "Loot-Strecke" 
        /// </summary>
        public int LastOverallRange
        {
            get { return lastEntireRange; }
        }
        /// <summary>
        /// Die letzte "Loot-Strecke" als <see cref="IntervallChain"/>
        /// </summary>
        public IntervallChain LastChain
        {
            get { return lastInnerChain; }
        }
        /// <summary>
        /// Das letzte ausgewählte <see cref="Intervall"/>
        /// </summary>
        public Intervall LastIntervall
        {
            get { return lastUsedIntervall; }
        }
        /// <summary>
        /// Alle letzten Namen der Items in der "Loot-Strecke" 
        /// </summary>
        public string[] LastItemNames
        {
            get { return allLastItemNames; }
        }
        /// <summary>
        /// Alle letzten Rarity-Attribute der Items in der "Loot-Strecke"
        /// </summary>
        public int[] LastItemRarities
        {
            get { return allLastItemRarities; }
        }
        /// <summary>
        /// Die Globale normale Instanz dieses Algotithmusses
        /// </summary>
        public static PartitionLoot<T> SharedInstance
        {
            get { return instance ?? (instance = new PartitionLoot<T>()); }
        }

        #endregion
    }
}
