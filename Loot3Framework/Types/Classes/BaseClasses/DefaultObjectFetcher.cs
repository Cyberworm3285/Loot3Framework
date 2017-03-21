using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.BaseClasses
{
    /// <summary>
    /// Die Standard-Klasse zum Object fetchen (muss zum benutzen erweitert werden)
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootObjectFetcher{T}"/>
    /// <seealso cref="Types.Classes.Algorithms.ObjectFetching.ObjectFetcherAccess{T}"/>
    /// <example>
    /// <code>  
    /// public class ExampleContainerProvider : DefaultObjectFetcher&lt;string&gt;
    /// {
    ///     public ExampleContainerProvider() : base(new ILootable&lt;string&gt;[]
    ///         {
    ///             new LootObjectContainer&lt;string&gt;("A").SetProps(true, "A", 10, "A"),
    ///             new LootFunctionContainer&lt;string&gt;(() => GlobalRandom.Next(0, 1000) + " Bs").SetProps(true, "B", 400, "B"),
    ///             new LootFunctionContainer&lt;string&gt;(() => "C").SetProps(true, "C", 700, "C"),
    ///         }) { }
    /// }
    /// </code>
    /// </example>
    public abstract class DefaultObjectFetcher<T> : ILootObjectFetcher<T>
    {
        /// <summary>
        /// Alle auszugebenden Objekte
        /// </summary>
        protected ILootable<T>[] objects;
        /// <summary>
        /// Konstruktor, der die auszugebenden Objekte setzt
        /// </summary>
        /// <param name="_objects">Die Objekte</param>
        public DefaultObjectFetcher(ILootable<T>[] _objects)
        {
            objects = _objects;
        }
        /// <summary>
        /// Gibt alle gespeicherten Objekte in der angegebenen <see cref="ICollection{T}"/> aus
        /// </summary>
        /// <typeparam name="TCollection">Die <see cref="ICollection{T}"/></typeparam>
        /// <returns>Die auszugebeneden Objekte</returns>
        public virtual TCollection GetLootObjects<TCollection>() where TCollection : ICollection<ILootable<T>>, new()
        {
            TCollection result = new TCollection();
            Array.ForEach(objects, o => result.Add(o));
            return result;
        }
    }
}
