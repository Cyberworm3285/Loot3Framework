using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Types.Structs;

namespace Loot3Framework.Interfaces
{
    
    public interface ILootRarityTable
    {
        string ToRarityName(int rarity);

        #region Properties

        IntervallChain Chain
        {
            get;
        }

        string[] Values
        {
            get;
        }

        #endregion
    }
}
