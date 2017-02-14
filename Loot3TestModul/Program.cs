using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Enums;
using Loot3Framework.Tools;

namespace Loot3Vorbereitung
{
    class Program
    {
        static void Main(string[] args)
        {
            RuntimeCompiler.CompileAllFilesInDirectory(Path.Combine(Environment.CurrentDirectory, "Items"), new string[] { "System.Linq.dll" }).DoAction(s => Console.WriteLine(s)); ;
            MainForm form = new MainForm();
            form.ShowDialog();
        }
    }


}


