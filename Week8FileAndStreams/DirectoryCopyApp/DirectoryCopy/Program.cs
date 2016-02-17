using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DirectoryCopyLib;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string oldDir = @"C:\Move";
            string newDir = @"D:\Moved";
            DirectoryCopyLibrary test = new DirectoryCopyLibrary();
            test.CopyDirectory(oldDir, newDir, true);

        }
    }
}
