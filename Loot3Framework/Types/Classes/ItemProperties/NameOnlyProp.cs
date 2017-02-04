using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    [CLSCompliant(true)]
    public class NameOnlyProp : IItemProperty
    {
        public string name;

        public NameOnlyProp(string _name)
        {
            name = _name;
        }

        public override string ToString()
        {
            return Generate();
        }

        public string Generate()
        {
            return name;
        }

        public static implicit operator string(NameOnlyProp n)
        {
            return n.Generate();
        }
    }
}
