using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Interfaces
{
    
    public interface ILootFilter
    {
        ILootable<T>[] Filter<T>(ILootable<T>[] allLoot);
    }
}
