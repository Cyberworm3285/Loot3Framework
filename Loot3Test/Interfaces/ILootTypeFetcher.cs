using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Interfaces
{
    public interface ILootTypeFetcher
    {
        Type[] GetAllLootableTypes(); 
    }
}
