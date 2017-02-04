using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Global;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    [CLSCompliant(true)]
    public class MultiIntervallProp : IItemProperty
    {
        public string[] names;
        public Intervall[] intervalls;

        public MultiIntervallProp(string[] _names, Intervall[] _intervalls)
        {
            if (_names.Length != _intervalls.Length) throw new Exception();
            names = _names;
            intervalls = _intervalls;
        }

        public override string ToString()
        {
            return Generate();
        }

        public string Generate()
        {
            int rdm = GlobalRandom.Next(0, names.Length);
            return names[rdm] + "(" + intervalls[rdm].Rand() + ")";
        }

        public static implicit operator string(MultiIntervallProp m)
        {
            return m.Generate();
        }
    }
}
