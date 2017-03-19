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
    
    [Serializable]
    public abstract class Loot3FrameworkException : Exception
    {
        public Loot3FrameworkException(string message) : base(message) { }
        public Loot3FrameworkException() : base() { }
    }
    
    [Serializable]
    public class NoMatchingLootException : Loot3FrameworkException
    {
        public NoMatchingLootException(string message) : base(message) { }
        public NoMatchingLootException() : base() { }
    }
    
    [Serializable]
    public class RuntimeCompileException : Loot3FrameworkException
    {
        protected CompilerErrorCollection innerErrors;

        public RuntimeCompileException(CompilerResults results, string message) 
            : base(message)
        {
            innerErrors = results.Errors;
        }

        public RuntimeCompileException(CompilerResults results)
            : base()
        {
            innerErrors = results.Errors;
        }

        public RuntimeCompileException(string message)
            : base(message)
        {

        }

        public RuntimeCompileException() 
            : base()
        {

        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public CompilerErrorCollection Errors
        {
            get
            {
                return innerErrors;
            }
        }
    }
}
