﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    public interface IItemHolder
    {
        ILootable GetLoot(ILootingAlgorithm algo);
        ILootable GetLoot(ILootingAlgorithm algo, ILootFilter filter);

        void InitLootables(ILootTypeFetcher fetcher);

        #region Properties

        ILootable[] AllLoot
        {
            get;
        }

        #endregion
    }
}