using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Structs
{
    /// <summary>
    /// Eine Kette von <see cref="Intervall"/>en
    /// </summary>
    /// <see cref="Intervall"/>
    [Serializable]
    public struct IntervallChain
    {
        private Intervall[] intervalls { get; set; }
        /// <summary>
        /// Konstruktor, der Intervalle aus einem <see cref="int"/>-<see cref="Array"/> generiert (optionale start-&amp;Endwerte)
        /// </summary>
        /// <param name="values">Alle Werte</param>
        /// <param name="startValue">Optionaler Startwert</param>
        /// <param name="endValue">Optionaler Endwert</param>
        public IntervallChain(int[] values, int? startValue = null, int? endValue = null)
        {
            List<int> temp = new List<int>();

            if (startValue != null)
                temp.Add(startValue.GetValueOrDefault());

            temp.AddRange(values);

            if (endValue != null)
                temp.Add(endValue.GetValueOrDefault());

            intervalls = new Intervall[temp.Count- 1];
            for (int i = 0; i < temp.Count - 1; i++)
            {
                intervalls[i] = new Intervall(temp[i], temp[i + 1]);
            }
        }
        /// <summary>
        /// Formatiert die Instanz der <see cref="Intervall"/>-Kette in einen <see cref="string"/>
        /// </summary>
        /// <returns>Die <see cref="string"/>-formatierte Instanz</returns>
        public override string ToString()
        {
            return "{" + string.Join("," , intervalls.Select(i => i.ToString()).ToArray()) + "}";
        }

        #region Properties
        /// <summary>
        /// Alle resultierenden <see cref="Intervall"/>e
        /// </summary>
        public Intervall[] Intervalls
        {
            get
            {
                return intervalls;
            }
            set
            {
                intervalls = value;
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Stellt die <see cref="Intervall"/>-Kette implizit als Array dar
        /// </summary>
        /// <param name="chain">Die komplette Chain</param>
        /// <returns>Der innere Array der Chain</returns>
        public static implicit operator Intervall[](IntervallChain chain)
        {
            return chain.Intervalls;
        }

        #endregion
    }
}
