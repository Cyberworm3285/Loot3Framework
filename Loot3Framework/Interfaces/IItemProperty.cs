using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

namespace Loot3Framework.Interfaces
{
    /// <summary>
    /// Gibt die grundlegenden Funktionen der ItemProperty vor, die während der Laufzei Variable Werte zum Loot hinzufügt
    /// </summary>
    public interface IItemProperty<T>
    {
        T Generate();
    }
}
