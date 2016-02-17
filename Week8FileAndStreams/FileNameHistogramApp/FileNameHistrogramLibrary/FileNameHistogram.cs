using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileNameHistrogramLibrary
{
    public class FileNameHistogram
    {
        public Dictionary<string,int> FileNumber(DirectoryInfo dirInf,Dictionary<string,int> searcher)
        {
            foreach (var dir in dirInf.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                if (searcher.ContainsKey(dir.Name))
                {
                    searcher[dir.Name] = searcher[dir.Name] + 1;
                }
                else
                {
                    searcher.Add(dir.Name, 1);
                }
            }
            return searcher;
        }

    }
}
