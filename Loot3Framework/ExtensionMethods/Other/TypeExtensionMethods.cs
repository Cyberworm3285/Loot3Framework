using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Loot3Framework.ExtensionMethods.Other
{
    public static class TypeExtensionMethods
    {
        public static object GetInstance(this Type t)
        {
            ConstructorInfo cInfo = t.GetConstructors().Where(c => c.GetParameters().Length == 0).First();
            if (cInfo == null) throw new Exception();
            return cInfo.Invoke(new object[] { });
        }

        public static object[] GetInstances(this Type[] ts)
        {
            object[] result = new object[ts.Length];
            for (int i = 0; i < ts.Length; i++)
            {
                result[i] = ts[i].GetInstance();
            }
            return result;
        }

        public static bool HasNonParameterConstructor(this Type t)
        {
            return (t.GetConstructors().Where(tt => tt.GetParameters().Length == 0).ToArray().Length > 0);
        }
    }
}
