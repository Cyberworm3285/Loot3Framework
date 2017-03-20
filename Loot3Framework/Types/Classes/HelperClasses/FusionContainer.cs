using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Loot3Framework.ExtensionMethods.CollectionOperations;

namespace Loot3Framework.Types.Classes.HelperClasses
{
    /// <summary>
    /// Container für <see cref="FusionTuple{T1, T2}"/>s mit sämtlichen Operationen
    /// </summary>
    /// <typeparam name="T1">Typ 1</typeparam>
    /// <typeparam name="T2">Typ 2</typeparam>
    /// <seealso cref="ExtensionMethods.CollectionOperations.CollectionExtensions.Fuse{T1, T2}(T1[], T2[])"/>
    /// <seealso cref="ExtensionMethods.CollectionOperations.SpecificCollectionExtensions.DeFuse{T1, T2}(FusionTuple{T1, T2}[], out T1[], out T2[])"/>
    /// <seealso cref="FusionTuple{T1, T2}"/>
    public class FusionContainer<T1, T2>
    {
        private FusionTuple<T1, T2>[] fusionResults;
        /// <summary>
        /// Konstruktor, der die inneren <see cref="FusionTuple{T1, T2}"/>s setzt
        /// </summary>
        /// <param name="tuples">Die Tuples</param>
        public FusionContainer(FusionTuple<T1, T2>[] tuples)
        {
            fusionResults = tuples;
        }
        #region Methods

        /// <summary>
        /// Fusioniert zwei <see cref="Array"/>s und speichert das Ergebnis intern ab
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public void Fuse(T1[] t1, T2[] t2)
        {
            fusionResults = t1.Fuse(t2);
        }
        /// <summary>
        /// Trennt die inneren <see cref="FusionTuple{T1, T2}"/>s wieder in ihre Bestandteile auf
        /// </summary>
        /// <param name="t1">Output für Typ 1</param>
        /// <param name="t2">Output für Typ 2</param>
        public void DeFuse(out T1[] t1, out T2[] t2)
        {
            fusionResults.DeFuse(out t1, out t2);
        }
        #endregion
        #region Operators

        /// <summary>
        /// Greift von implizit auf den inneren <see cref="Array"/> zu
        /// </summary>
        /// <param name="f">Das zu 'konvertierende' Objekt</param>
        public static implicit operator FusionTuple<T1, T2>[](FusionContainer<T1, T2> f)
        {
            return f.FusionTuples;
        }
        /// <summary>
        /// Erstellt einen neuen <see cref="FusionContainer{T1, T2}"/> mit dem angegebenen inneren <see cref="Array"/>
        /// </summary>
        /// <param name="f">Der innere <see cref="Array"/></param>
        public static explicit operator FusionContainer<T1, T2>(FusionTuple<T1, T2>[] f)
        {
            return new FusionContainer<T1, T2>(f);
        }
        #endregion
        /// <summary>
        /// Gibt die momentan gespeicherten Tuples aus
        /// </summary>
        public FusionTuple<T1, T2>[] FusionTuples
        {
            get { return fusionResults; }
        }
    }
}
