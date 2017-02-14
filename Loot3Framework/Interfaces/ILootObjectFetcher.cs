using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    public interface ILootObjectFetcher<T>
    {
        TCollection GetLootObjects<TCollection>() where TCollection : ICollection<ILootable<T>>, new();
    }
}
