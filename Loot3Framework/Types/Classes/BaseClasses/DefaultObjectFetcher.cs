using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    public abstract class DefaultObjectFetcher<T> : ILootObjectFetcher<T>
    {
        protected ILootable<T>[] objects;

        public DefaultObjectFetcher(ILootable<T>[] _objects)
        {
            objects = _objects;
        }

        public TCollection GetLootObjects<TCollection>() where TCollection : ICollection<ILootable<T>>, new()
        {
            TCollection result = new TCollection();
            Array.ForEach(objects, o => result.Add(o));
            return result;
        }
    }
}
