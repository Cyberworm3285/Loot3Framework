using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Attributes;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    /// <summary>
    /// Sucht Loot Typen anhand ihrer <see cref="LootTagAttribute"/>n
    /// </summary>
    /// <typeparam name="T">Der zu lootende Typ</typeparam>
    /// <seealso cref="ILootTypeFetcher{T}"/>
    /// <seealso cref="FetchByInheritance{T}"/>
    /// <seealso cref="FetchByNamespace{T}"/>
    /// <seealso cref="Multifetching{T}"/>
    /// <seealso cref="TypeForwardFetching{T}"/>
    public class FetchByLootTags<T> : ILootTypeFetcher<T>
    {
        /// <summary>
        /// Die gültigen Tags
        /// </summary>
        protected string[] tags;

        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        public FetchByLootTags() { }
        /// <summary>
        /// Konstruktor, der die gültigen <see cref="LootTagAttribute"/> einschränkt
        /// </summary>
        /// <param name="_tag">Der gültige Wert für die Tags</param>
        public FetchByLootTags(string _tag)
        {
            tags = new string[] { _tag };
        }
        /// <summary>
        /// Konstruktor, der die gültigen <see cref="LootTagAttribute"/> einschränkt
        /// </summary>
        /// <param name="_tags">Die gültigen Werte für die Tags</param>
        public FetchByLootTags(string[] _tags)
        {
            tags = _tags;
        }
        /// <summary>
        /// Sucht alle Typen mit gültigen Tags und git diese aus
        /// </summary>
        /// <returns>Alle gültigen Typen</returns>
        public Type[] GetAllLootableTypes()
        {
            List<Type> types = new List<Type>();

            foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type t in a.GetTypes())
                {
                    MemberInfo info = t;
                    object[] atts = info.GetCustomAttributes(typeof(LootTagAttribute), false).ToArray();
                    foreach(Attribute att in atts)
                    {
                        if (att != null)
                        {
                            if (tags.Contains((att as LootTagAttribute).LootTag) && typeof(ILootable<T>).IsAssignableFrom(t) && !t.IsAbstract && t.HasNonParameterConstructor() && !t.IsGenericType)
                            {
                                types.Add(t);
                                break;
                            }
                        }
                    }
                }
            }

            return types.ToArray();
        }
    }
}
