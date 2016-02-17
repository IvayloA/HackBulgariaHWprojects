using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileNameHistrogramLibrary;

namespace FileNameHistogramApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInf = new DirectoryInfo(@"C:\SearchFolderHackBG");
            Dictionary<string, int> searcher = new Dictionary<string, int>();
           
            FileNameHistogram fnh = new FileNameHistogram();
            Dictionary<string, int> tester =  fnh.FileNumber(dirInf, searcher);

            foreach (KeyValuePair<string,int> item in tester)
            {
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            }

            Console.Read();
        }
    }
}
