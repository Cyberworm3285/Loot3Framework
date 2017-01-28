using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLibrary.Loot
{
    public interface ILootable
    {
        #region Methods

        string Generate();

        #endregion

        #region Properties

        int Rarity { get; }
        string Type { get; }
        string Name { get; }
        bool IsQuestItem { get; }
        string[] AllowedAreas { get; }

        #endregion
    }
}
