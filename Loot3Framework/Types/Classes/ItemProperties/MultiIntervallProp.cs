using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Global;
using Loot3Framework.Interfaces;
using Loot3Framework.Types.Structs;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    
    public class MultiIntervallProp : IItemProperty<string>
    {
        public string[] names;
        public Intervall[] intervalls;

        ///<exception cref="IndexOutOfRangeException">at uneven array lengths</exception>
        public MultiIntervallProp(string[] _names, Intervall[] _intervalls)
        {
            if (_names.Length != _intervalls.Length)
                throw new IndexOutOfRangeException("uneven array lengths");
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

        public static explicit operator string(MultiIntervallProp m)
        {
            return m.Generate();
        }
    }
}
