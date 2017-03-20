using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Global;

namespace Loot3Framework.Types.Structs
{
    /// <summary>
    /// Zahlen-Intervall
    /// </summary>
    /// <seealso cref="IntervallChain"/>
    [Serializable]
    public struct Intervall
    {
        private int a { get; set; }
        private int b { get; set; }
        private int range;
        /// <summary>
        /// Konstruktor, der beide zahlenwerte initialisiert
        /// </summary>
        /// <param name="x">Erster Wert</param>
        /// <param name="y">Zweiter Wert</param>
        public Intervall(int x, int y)
        {
            a = x;
            b = y;
            range = y - x;
        }
        /// <summary>
        /// Gibt einen zufälligen Wert zwischen den beiden Zahlenwerten aus
        /// </summary>
        /// <returns>Ein Zufallswer (X&lt;=z&gt;=Y)</returns>
        public int Rand()
        {
            return GlobalRandom.Next(a, b + 1);
        }
        /// <summary>
        /// Formatiert die Instanz in einen <see cref="string"/>
        /// </summary>
        /// <returns>Die <see cref="string"/>-formatierte Instanz</returns>
        public override string ToString()
        {
            return "[" + a + ";" + b + "]";
        }
        /// <summary>
        /// Die Länge des intervalls
        /// </summary>
        public int Range
        {
            get { return range; }
        } 
        /// <summary>
        /// Der erste Wert
        /// </summary>
        public int X
        {
            get { return a; }
            set
            {
                a = value;
                range = b - a;
            }
        }
        /// <summary>
        /// Der Zweite Wert
        /// </summary>
        public int Y
        {
            get { return b; }
            set
            {
                b = value;
                range = b - a;
            }
        }
    }
}
