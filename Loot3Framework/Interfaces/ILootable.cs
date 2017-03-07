using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    
    public interface ILootable<T>
    {
        #region Properties

        T Item { get; }

        int Rarity { get; }
        string RarityName { get; }
        string Type { get; }
        string Name { get; }
        bool IsQuestItem { get; }
        ILootRarityTable rarTable { get; }

        #endregion
    }
}
