using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Types.Classes.HelperClasses
{
    /// <summary>
    /// Eine simple Tuple-Klasse, die zwei Objekte aneinander bindet
    /// </summary>
    /// <typeparam name="T1">Typ 1</typeparam>
    /// <typeparam name="T2">Typ 2</typeparam>
    [Serializable]
    public sealed class FusionTuple<T1, T2>
    {
        private T1 t1 { get; set; }
        private T2 t2 { get; set; }
        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        public FusionTuple() { }
        /// <summary>
        /// Kosntruktor, der beide Items einspeichert und bindet
        /// </summary>
        /// <param name="_t1">Item 1</param>
        /// <param name="_t2">Item 2</param>
        public FusionTuple(T1 _t1, T2 _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }
        /// <summary>
        /// Formatiert die Eigenschaften des Tuples als <see cref="string"/>
        /// </summary>
        /// <returns>Die Eigenschaften</returns>
        public override string ToString()
        {
            return "[" + t1 + ";" + t2 + "]";
        }
        /// <summary>
        /// Zugriff auf Item 1
        /// </summary>
        public T1 Item1
        {
            get { return t1; }
            set { t1 = value; }
        }
        /// <summary>
        /// Zugriff auf Item 2
        /// </summary>
        public T2 Item2
        {
            get { return t2; }
            set { t2 = value; }
        }
    }
}
