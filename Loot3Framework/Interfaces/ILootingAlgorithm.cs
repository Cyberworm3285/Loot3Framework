using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    
    public interface ILootingAlgorithm<T>
    {
        ILootable<T> Loot(ILootable<T>[] allLoot);
    }
}
