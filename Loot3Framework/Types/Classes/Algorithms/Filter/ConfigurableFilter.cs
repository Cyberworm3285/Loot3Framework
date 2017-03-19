using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.Filter
{
    /// <summary>
    /// Ein Konfigurierbarer Loot-Filter 
    /// </summary>
    /// <seealso cref="ILootFilter"/>
    /// <seealso cref="StringComparing"/>
    /// <seealso cref="StandardNCSFilter"/>
    public class ConfigurableFilter : ILootFilter
    {
        private string nameContains;
        private string typeContains;
        private string rarityName;
        private string[] allowedTypes;
        private string[] allowedRarities;
        private int rarityLowerBound;
        private int rarityUpperBound;
        private StringComparing[] modes;
        private bool allowQuestItems;
        /// <summary>
        /// Konstruktor mit standardisierten Parametern (final)
        /// </summary>
        /// <param name="_modeName">Vergleichsmodus für das Name-Attribut</param>
        /// <param name="_modeType">Vergleichsmodus für das Type-Attribut</param>
        /// <param name="_modeRarity">Vergleichsmodus für das Seltenheits-Attribut</param>
        /// <param name="_nameContains">Name-Attribut Einschränkungen</param>
        /// <param name="_typeContains">Type-Attribut Einschränkungen</param>
        /// <param name="_rarityName">RarityName-Attribut Einschränkungen</param>
        /// <param name="_allowQuestItems">Einschränkung für das benutzen von QuestItems</param>
        /// <param name="_allowedTypes">Einschränkung für erlaubte Type-Attribute</param>
        /// <param name="_allowedRarities">Einschränkung für erlaubte Seltenheiten</param>
        /// <param name="_rarityLowerBound">Einschränkung für die untere Grenze des Rarity-Attributs</param>
        /// <param name="_rarityUpperBound">Einschränkung für für die obere Grenze des Rarity-Attributs</param>
        public ConfigurableFilter(
            StringComparing _modeName = StringComparing.NonCaseSensitiveInclude, 
            StringComparing _modeType = StringComparing.NonCaseSensitiveInclude, 
            StringComparing _modeRarity = StringComparing.NonCaseSensitiveInclude, 
            string _nameContains = "", 
            string _typeContains = "", 
            string _rarityName= "", 
            bool _allowQuestItems = true ,
            string[] _allowedTypes = null ,
            string[] _allowedRarities = null,
            int _rarityLowerBound = 0, int _rarityUpperBound = 1000)
        {
            modes = new StringComparing[] { _modeName, _modeType, _modeRarity };
            nameContains = _nameContains;
            typeContains = _typeContains;
            rarityName = _rarityName;
            allowedTypes = _allowedTypes;
            allowedRarities = _allowedRarities;
            allowQuestItems = _allowQuestItems;
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

                ((l.Name.CompareToString(nameContains,      modes[0]))  || (nameContains == "") || (nameContains == null))    &&
                ((l.Type.CompareToString(typeContains,      modes[1]))  || (typeContains == "") || (typeContains == null))    &&
                ((l.RarityName.CompareToString(rarityName,  modes[2]))  || (rarityName == "") || (rarityName == null))          &&
                ((allowedTypes==null)?true:(allowedTypes.Contains(l.Type)))                         &&
                ((allowedRarities == null)?true:(allowedRarities.Contains(l.RarityName)))           &&
                ((allowQuestItems == l.IsQuestItem) || !l.IsQuestItem)                              &&
                ((l.Rarity >= rarityLowerBound && l.Rarity <= rarityUpperBound) || (rarityLowerBound == 0 && rarityUpperBound == 0))

            ).ToArray();
        }
    }
}
