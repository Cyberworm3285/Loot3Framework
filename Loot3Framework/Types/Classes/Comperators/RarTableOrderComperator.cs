using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.Comperators
{
    class RarTableOrderComperator : IComparer<string>
    {
        private string[] tableValues;

        public RarTableOrderComperator(ILootRarityTable table)
        {
            tableValues = table.Values;
        }

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
