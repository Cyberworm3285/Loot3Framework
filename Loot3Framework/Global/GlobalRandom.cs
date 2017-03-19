using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Global
{
    /// <summary>
    /// Der global benutzte Randomizer
    /// </summary>
    public static class GlobalRandom
    {
        private static Random random = new Random();

        #region Methods
        /// <summary>
        /// Führt die Next-Funktion des internen Randomizers aus
        /// </summary>
        /// <param name="a">Untere Grenze</param>
        /// <param name="b">Obere Grenze</param>
        /// <returns>Zufallszahl größer/gleich a und kleiner b</returns>
        public static int Next(int a, int b)
        {
            return random.Next(a, b);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Zum setzen/anderweitigen vernwenden des internen <see cref="Random"/>izers
        /// </summary>
        public static Random Randomizer
        {
            get { return random; }
            set { random = value; }
        }

        #endregion
    }
}
