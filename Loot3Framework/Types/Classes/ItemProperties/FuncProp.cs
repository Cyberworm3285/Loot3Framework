using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    public class FuncProp<T> : IItemProperty<T>
    {
        private readonly Func<T> provider;

        public FuncProp(Func<T> _provider) => provider = _provider;

        public T Generate() => provider();
    }
}
