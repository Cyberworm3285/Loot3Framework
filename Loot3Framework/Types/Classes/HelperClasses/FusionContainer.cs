using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Types.Classes.HelperClasses
{
    [Serializable]
    public sealed class FusionContainer<T1, T2>
    {
        private T1 t1 { get; set; }
        private T2 t2 { get; set; }

        public FusionContainer() { }

        public FusionContainer(T1 _t1, T2 _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }

        public override string ToString()
        {
            return "[" + t1 + ";" + t2 + "]";
        }

        public static explicit operator Tuple<T1, T2>(FusionContainer<T1, T2> fus)
        {
            return Tuple.Create(fus.Item1, fus.Item2);
        }

        public static explicit operator FusionContainer<T1, T2>(Tuple<T1, T2> tup)
        {
            return new FusionContainer<T1, T2>(tup.Item1, tup.Item2);
        }

        public T1 Item1
        {
            get { return t1; }
            set { t1 = value; }
        }

        public T2 Item2
        {
            get { return t2; }
            set { t2 = value; }
        }
    }
}
