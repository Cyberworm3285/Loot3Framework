using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Enums;
using Loot3Framework.Tools;

namespace Loot3Vorbereitung
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namespaces;
            RuntimeCompiler.TryCompileFiles(Path.Combine(Environment.CurrentDirectory, "Item1.cs"), new string[] { "System.Linq.dll" }, out namespaces);
            Console.WriteLine("namespaces: " + string.Join(",", namespaces));
            MainForm form = new MainForm();
            form.ShowDialog();
        }
    }


}


