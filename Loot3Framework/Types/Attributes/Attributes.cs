using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loot3Framework.Types.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class LootTagAttribute : Attribute
    {
        readonly string lootTag;

        public LootTagAttribute(string positionalString)
        {
            this.lootTag = positionalString;
        }

        public string LootTag
        {
            get { return lootTag; }
        }
    }
}
