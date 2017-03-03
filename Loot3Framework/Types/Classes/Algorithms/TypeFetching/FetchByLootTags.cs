using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Loot3Framework.Interfaces;
using Loot3Framework.Types.Attributes;
using Loot3Framework.ExtensionMethods.Other;

namespace Loot3Framework.Types.Classes.Algorithms.TypeFetching
{
    public class FetchByLootTags<T> : ILootTypeFetcher<T>
    {
        protected string[] tags;

        public FetchByLootTags() { }

        public FetchByLootTags(string _tag)
        {
            tags = new string[] { _tag };
        }

        public FetchByLootTags(string[] _tags)
        {
            tags = _tags;
        }

        public Type[] GetAllLootableTypes()
        {
            List<Type> types = new List<Type>();

            foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type t in a.GetTypes())
                {
                    MemberInfo info = t;
                    object[] atts = info.GetCustomAttributes(typeof(LootTagAttribute)).ToArray();
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
