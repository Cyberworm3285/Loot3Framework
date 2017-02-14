﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    [CLSCompliant(true)]
    public interface IItemHolder<T>
    {
        ILootable<T> GetLoot(ILootingAlgorithm<T> algo);
        ILootable<T> GetLoot(ILootingAlgorithm<T> algo, ILootFilter filter);

        void InitLootables(ILootTypeFetcher<T> fetcher);

        #region Properties

        ILootable<T>[] AllLoot
        {
            get;
        }

        string[] AllTypeNames
        {
            get;
        }

        string[] AllRarityNames
        {
            get;
        }

        #endregion
    }
}
