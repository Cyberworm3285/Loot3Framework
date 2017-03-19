using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Algorithms.Filter
{
    /// <summary>
    /// Normaler NonCaseSensitive-Filter für Name-, Type- und RarityName Attribute sowie Rarity Grenzen
    /// </summary>
    /// <seealso cref="ILootFilter"/>
    /// <seealso cref="ConfigurableFilter"/>
    public class StandardNCSFilter : ILootFilter
    {
        private string nameContains;
        private string typeContains;
        private string rarityName;
        private int rarityLowerBound;
        private int rarityUpperBound;

        /// <summary>
        /// Konstruktor der die Filtereinstellungen setzt (final)
        /// </summary>
        /// <param name="_nameContains">Name-Attribut Einschränkungen</param>
        /// <param name="_typeContains">Type-Attribut Einschränkungen</param>
        /// <param name="_rarityName">RarityName-Attribut Einschränkungen</param>
        /// <param name="_rarityLowerBound">Einschränkung für die untere Grenze des Rarity-Attributs</param>
        /// <param name="_rarityUpperBound">Einschränkung für für die obere Grenze des Rarity-Attributs</param>
        public StandardNCSFilter(string _nameContains, string _typeContains, string _rarityName, int _rarityLowerBound, int _rarityUpperBound)
        {
            nameContains = _nameContains;
            typeContains = _typeContains;
            rarityName = _rarityName;
            rarityLowerBound = _rarityLowerBound;
            rarityUpperBound = _rarityUpperBound;
        }
        /// <summary>
        /// Filtert den Eingangs-<see cref="Array"/> und gibt alle gültigen Objekte wieder aus
        /// </summary>
        /// <typeparam name="T">Der zu lootende Typ</typeparam>
        /// <param name="allLoot">Das gesamte ursprüngliche Loot</param>
        /// <returns>Alle gültigen Objekte</returns>
        public ILootable<T>[] Filter<T>(ILootable<T>[] allLoot)
        {
            return allLoot.Where(l => 

                (l.Name.ToUpper().Contains(nameContains.ToUpper()) || (nameContains == "")) &&
                (l.Type.ToUpper().Contains(typeContains.ToUpper()) || (typeContains == "")) &&
                ((l.RarityName.ToUpper() == rarityName) || (rarityName == "")) &&
                ((l.Rarity >= rarityLowerBound && l.Rarity <= rarityUpperBound) || (rarityLowerBound == 0 && rarityUpperBound == 0))
                
                ).ToArray();
        }
    }
}
