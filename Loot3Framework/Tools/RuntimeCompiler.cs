using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;

using Loot3Framework.Types.Exceptions;

namespace Loot3Framework.Tools
{
    /// <summary>
    /// Ein Runtime Compiler für C# Code
    /// </summary>
    [CLSCompliant(false)]
    public static class RuntimeCompiler
    {
        /// <summary>
        /// Comiliert die angegebene Datei mit den angegebenen Verweisen
        /// </summary>
        /// <param name="path">Die Datei</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <returns>Die Namespaces des Compilierten C# Codes</returns>
        ///<exception cref="RuntimeCompileException">Wenn das Compilieren fehlschlägt</exception>
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
                throw new RuntimeCompileException(results, "at: " + path);

            List<string> namespaces = new List<string>();
            results.CompiledAssembly.GetTypes().ToList().ForEach(t => { if (!namespaces.Contains(t.Namespace)) namespaces.Add(t.Namespace); });

            return namespaces.ToArray();
        }
        /// <summary>
        /// Comiliert die angegebenen Dateien mit den angegebenen Verweisen
        /// </summary>
        /// <param name="path">Die Dateien</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <returns>Die Namespaces des Compilierten C# Codes</returns>
        public static string[] CompileFiles(string[] path, string[] dependencies)
        {
            List<string> namespaces = new List<string>();

            foreach (string s in path)
            {
                namespaces.AddRange(CompileFiles(s, dependencies));
            }

            return namespaces.ToArray();
        }
        /// <summary>
        /// Comiliert alle Dateien im angegebenen Verzeichnis mit den angegebenen Verweisen
        /// </summary>
        /// <param name="path">Das Verzeichnis</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <returns>Die Namespaces des Compilierten C# Codes</returns>
        public static string[] CompileAllFilesInDirectory(string path, string[] dependencies)
        {
            string[] filesNames = Directory.GetFiles(path);
            return CompileFiles(filesNames, dependencies);            
        }
        /// <summary>
        /// Comiliert die angegebene Datei mit den angegebenen Verweisen (try-Pattern)
        /// </summary>
        /// <param name="path">Die Datei</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <param name="outputNamespaces">Output für die Namespaces des Compilierten C# Codes</param>
        /// <returns>true bei Erfolg</returns>
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
        /// <summary>
        /// Comiliert die angegebenen Dateien mit den angegebenen Verweisen (try-Pattern)
        /// </summary>
        /// <param name="path">Die Dateien</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <param name="outputNamespaces">Output für die Namespaces des Compilierten C# Codes</param>
        /// <returns>true bei Erfolg</returns>
        public static bool TryCompileFiles(string[] path, string[] dependencies, out string[] outputNamespaces)
        {
            bool flag = true;
            List<string> results = new List<string>();
            foreach(string s in path)
            {
                string[] result = null;
                flag = !flag && TryCompileFiles(s, dependencies, out result);
                if (result != null) results.AddRange(result);
            }
            outputNamespaces = results.ToArray();
            return flag;
        }
        /// <summary>
        /// Comiliert alle Dateien im angegebenen Verzeichnis mit den angegebenen Verweisen (try-Pattern)
        /// </summary>
        /// <param name="path">Das Verzeichnis</param>
        /// <param name="dependencies">Die Verweise</param>
        /// <param name="outputNamespaces">Output für die Namespaces des Compilierten C# Codes</param>
        /// <returns>true bei Erfolg</returns>
        public static bool TryCompileAllFilesInDirectory(string path, string[] dependencies, out string[] outputNamespaces)
        {
            string[] fileNames = Directory.GetFiles(path);
            string[] results;
            bool flag = TryCompileFiles(fileNames, dependencies, out results);
            outputNamespaces = results;
            return flag;
        }
    }
}
