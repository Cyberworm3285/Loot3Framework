using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    public class RandomMultiProp : IItemProperty
    {
        public IItemProperty[] props;

        public RandomMultiProp(IItemProperty[] _props)
        {
            props = _props;
        }

        public string Generate()
        {
            return props[GlobalRandom.Next(0, props.Length)].Generate();
        }
    }
}
