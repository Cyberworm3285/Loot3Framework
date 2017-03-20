using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;
using Loot3Framework.Global;

namespace Loot3Framework.Types.Classes.ItemProperties
{
    /// <summary>
    /// Eine Meta-Item-Eigenschaft, die aus mehreren anderen Eigenschaften besteht und zufällig eine auswählt und generiert
    /// </summary>
    /// <typeparam name="T">Der Eigenschafts-Typ</typeparam>
    /// <seealso cref="IItemProperty{T}"/>
    /// <seealso cref="MultiIntervallProp"/>
    /// <seealso cref="NameOnlyProp"/>
    /// <seealso cref="SingleIntervallProp"/>
    public class RandomMultiProp<T> : IItemProperty<T>
    {
        private IItemProperty<T>[] props;
        /// <summary>
        /// Konstruktor, der die inneren Eigenschaften setzt
        /// </summary>
        /// <param name="_props">Die inneren Eigenschaften</param>
        public RandomMultiProp(IItemProperty<T>[] _props)
        {
            props = _props;
        }
        /// <summary>
        /// Sucht eine Eigenschaft aus und gibt deren Output aus
        /// </summary>
        /// <returns>Den Output einer zufälligen Eigenschaft</returns>
        public T Generate()
        {
            return props[GlobalRandom.Next(0, props.Length)].Generate();
        }
    }
}
