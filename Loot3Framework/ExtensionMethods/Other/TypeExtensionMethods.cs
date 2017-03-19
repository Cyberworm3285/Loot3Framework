using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using System.Reflection;

namespace Loot3Framework.ExtensionMethods.Other
{
    /// <summary>
    /// Extension Methods für den <see cref="Type"/>-Typ
    /// </summary>
    public static class TypeExtensionMethods
    {
        /// <summary>
        /// Erstellt eine Instanz des erweiterten <see cref="Type"/>-Typen
        /// </summary>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <returns>Eine neue Instanz</returns>
        ///<exception cref="TypeInitializationException">Wenn kein Konstruktor mit 0 Parametern existiert</exception>
        public static object GetInstance(this Type t)
        {
            ConstructorInfo cInfo = t.GetConstructors().Where(c => c.GetParameters().Length == 0).First();
            if (cInfo == null)
                throw new TypeInitializationException(t.FullName, new NullReferenceException("type has no 0-param-constructor"));
            return cInfo.Invoke(new object[] { });
        }
        /// <summary>
        /// Erstellt vom gesamten Array Instanzen als <see cref="object"/>
        /// </summary>
        /// <param name="ts">Das erweiterte Objekt</param>
        /// <returns>Von jedem Element eine neue Instanz als <see cref="object"/></returns>
        public static object[] GetInstances(this Type[] ts)
        {
            object[] result = new object[ts.Length];
            for (int i = 0; i < ts.Length; i++)
            {
                result[i] = ts[i].GetInstance();
            }
            return result;
        }
        /// <summary>
        /// Gibt an, ob es einen leeren Konstruktor gibt (Konstruktor ohne Parameter)
        /// </summary>
        /// <param name="t">Das erweiterte Objekt</param>
        /// <returns></returns>
        public static bool HasNonParameterConstructor(this Type t)
        {
            return (t.GetConstructors().Where(tt => tt.GetParameters().Length == 0).ToArray().Length > 0);
        }
    }
}
