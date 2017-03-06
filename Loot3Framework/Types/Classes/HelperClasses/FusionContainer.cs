using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Types.Classes.HelperClasses
{
    public sealed class FusionContainer<T1, T2>
    {
        private T1 t1;
        private T2 t2;

        public FusionContainer(T1 _t1, T2 _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }

        public T1 Item1
        {
            get { return t1; }
        }

        public T2 Item2
        {
            get { return t2; }
        }
    }
}
