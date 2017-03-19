using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    
    public class RandomMultiProp : IItemProperty<string>
    {
        public IItemProperty<string>[] props;

        public RandomMultiProp(IItemProperty<string>[] _props)
        {
            props = _props;
        }

        public string Generate()
        {
            return props[GlobalRandom.Next(0, props.Length)].Generate();
        }
    }
}
