using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Comperators
{
    /// <summary>
    /// Vergleicht zwei <see cref="string"/>s anhand ihrer Position in einer Seltenheits-Referenztabelle
    /// </summary>
    /// <seealso cref="Types.Classes.RarityTables"/>
    public class RarTableOrderComperator : IComparer<string>
    {
        private string[] tableValues;

        /// <summary>
        /// Konstruktor, der die Seltenheits-Referenztabelle setzt
        /// </summary>
        /// <param name="table">Die</param>
        public RarTableOrderComperator(ILootRarityTable table)
        {
            tableValues = table.Values;
        }
        /// <summary>
        /// Vergleicht zwei <see cref="string"/>s
        /// </summary>
        /// <param name="x"><see cref="string"/> 1</param>
        /// <param name="y"><see cref="string"/> 2</param>
        /// <returns>Standard-Vergleichs-Integer</returns>
        public int Compare(string x, string y)
        {
            if (Array.IndexOf(tableValues, x) > Array.IndexOf(tableValues, y))
            {
                return -1;
            }
            else if (Array.IndexOf(tableValues, x) < Array.IndexOf(tableValues, y))
            {
                return 1;
            }
            else return 0;
        }
    }
}
