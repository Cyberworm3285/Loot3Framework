using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
////using System.Threading.Tasks

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace Loot3Framework.Types.Exceptions
{
    /// <summary>
    /// Basis-Exception
    /// </summary>
    [Serializable]
    public abstract class Loot3FrameworkException : Exception
    {
        /// <summary>
        /// Konstruktor, der eine Nachricht weiterleitet
        /// </summary>
        /// <param name="message">Die Nachricht</param>
        public Loot3FrameworkException(string message) : base(message) { }
        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        public Loot3FrameworkException() : base() { }
    }
    /// <summary>
    /// Exception für Lootfindungsprobleme
    /// </summary>
    [Serializable]
    public class NoMatchingLootException : Loot3FrameworkException
    {
        /// <summary>
        /// Konstruktor, der eine Nachricht weiterleitet
        /// </summary>
        /// <param name="message">Die Nachricht</param>
        public NoMatchingLootException(string message) : base(message) { }
        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        public NoMatchingLootException() : base() { }
    }
    /// <summary>
    /// Exception für Probleme beim Kompilieren während der Laufzeit
    /// </summary>
    [Serializable]
    public class RuntimeCompileException : Loot3FrameworkException
    {
        /// <summary>
        /// Kompilierfehler
        /// </summary>
        protected CompilerErrorCollection innerErrors;
        /// <summary>
        /// Konstruktor, der eine Nachricht weiterleitet und die Komplilierfehler speichert
        /// </summary>
        /// <param name="results">Die Kompilierfehler</param>
        /// <param name="message">Die Nachricht</param>
        public RuntimeCompileException(CompilerResults results, string message) 
            : base(message)
        {
            innerErrors = results.Errors;
        }
        /// <summary>
        /// Konstruktor, der die Kompilierfehler speichert
        /// </summary>
        /// <param name="results">Die Kompilierfehler</param>
        public RuntimeCompileException(CompilerResults results)
            : base()
        {
            innerErrors = results.Errors;
        }
        /// <summary>
        /// Konstruktor, der eine Nachricht weiterleitet
        /// </summary>
        /// <param name="message">Die Nachricht</param>
        public RuntimeCompileException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Satndard-Konstruktor
        /// </summary>
        public RuntimeCompileException() 
            : base()
        {

        }
        /// <summary>
        /// Geerbt und reimplementiert von base
        /// </summary>
        /// <param name="info">?</param>
        /// <param name="context">?</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        /// <summary>
        /// Zugriff auf Kompilierfehler
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                return innerErrors;
            }
        }
    }
    /// <summary>
    /// Exception für defekten Code
    /// </summary>
    [Serializable]
    public class BrokenException : Loot3FrameworkException
    {
        /// <summary>
        /// Konstruktor, der eine Nachricht weiterleitet
        /// </summary>
        /// <param name="message">Die Nachricht</param>
        public BrokenException(string message) : base(message) { }
        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        public BrokenException() : base() { }
    }
}
