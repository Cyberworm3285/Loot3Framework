using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;

namespace Loot3Framework.Tools
{
    [CLSCompliant(true)]
    public static class RuntimeCompiler
    {
        public static string[] CompileFiles(string path, string[] dependencies)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add("Loot3Framework.dll");
            foreach (string s in dependencies)
                parameters.ReferencedAssemblies.Add(s);
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, string.Join(" ", File.ReadAllLines(path)));
            if (results.Errors.HasErrors)
                throw new Exception();

            List<string> namespaces = new List<string>();
            results.CompiledAssembly.GetTypes().ToList().ForEach(t => { if (!namespaces.Contains(t.Namespace)) namespaces.Add(t.Namespace); });

            return namespaces.ToArray();
        }

        public static string[] CompileFiles(string[] path, string[] dependencies)
        {
            List<string> namespaces = new List<string>();

            foreach (string s in path)
            {
                namespaces.AddRange(CompileFiles(s, dependencies));
            }

            return namespaces.ToArray();
        }

        public static string[] CompileAllFilesInDirectory(string path, string[] dependencies)
        {
            string[] filesNames = Directory.GetFiles(path);
            return CompileFiles(filesNames, dependencies);            
        }

        public static bool TryCompileFiles(string path, string[] dependencies, out string[] outputNamespaces)
        {
            try
            {
                outputNamespaces = CompileFiles(path, dependencies);
                return true;
            }
            catch (Exception)
            {
                outputNamespaces = new string[] { };
                return false;
            }
        }

        public static bool TryCompileFiles(string[] path, string[] dependencies, out string[] outputNamespace)
        {
            bool flag = true;
            List<string> results = new List<string>();
            foreach(string s in path)
            {
                string[] result = null;
                flag = !flag && TryCompileFiles(s, dependencies, out result);
                if (result != null) results.AddRange(result);
            }
            outputNamespace = results.ToArray();
            return flag;
        }

        public static bool TryCompileAllFilesInDirectory(string path, string[] dependencies, out string[] outputNamespace)
        {
            string[] fileNames = Directory.GetFiles(path);
            string[] results;
            bool flag = TryCompileFiles(fileNames, dependencies, out results);
            outputNamespace = results;
            return flag;
        }
    }
}
