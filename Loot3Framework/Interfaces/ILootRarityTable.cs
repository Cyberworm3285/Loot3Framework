using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Types.Structs;

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funktionalitäten der Seltenheits-Referenztabelle vor
    /// </summary>
    public interface ILootRarityTable
    {
        /// <summary>
        /// Wandelt eine Seltenheit in den entsprechenden Namn um
        /// </summary>
        /// <param name="rarity">Die Seltenheit</param>
        /// <returns>Der entsprechende Name</returns>
        string ToRarityName(int rarity);

        #region Properties
        /// <summary>
        /// Die innere Kette an Intervallen der Seltenheits-Grenzen
        /// </summary>
        IntervallChain Chain
        {
            get;
        }
        /// <summary>
        /// Die zu den Intervallen in der Kette passenden Seltenheits-Namen
        /// </summary>
        string[] Values
        {
            get;
        }

        #endregion
    }
}
