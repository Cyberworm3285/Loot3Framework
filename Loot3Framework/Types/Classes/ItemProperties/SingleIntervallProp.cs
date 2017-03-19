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
    
    public class SingleIntervallProp : IItemProperty<string>
    {
        public Intervall intervall;
        public string[] propNames;

        public SingleIntervallProp(string[] _propNames, Intervall _intervall)
        {
            intervall = _intervall;
            propNames = _propNames;
        }

        public SingleIntervallProp(string _propName, Intervall _intervall)
        {
            intervall = _intervall;
            propNames = new string[] { _propName };
        }

        public string Generate()
        {
            return propNames[GlobalRandom.Next(0, propNames.Length)] + "(" + intervall.Rand() + ")";
        }

        public override string ToString()
        {
            return Generate();
        }

        public static implicit operator string(SingleIntervallProp s)
        {
            return s.Generate();
        }
    }
}
