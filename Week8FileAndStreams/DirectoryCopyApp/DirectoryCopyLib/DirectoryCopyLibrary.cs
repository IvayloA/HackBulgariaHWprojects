using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryCopyLib
{
    public class DirectoryCopyLibrary
    {
        public void CopyDirectory(string oldDirectory, string newDirectory, bool CopySubDirs)
        {
            DirectoryInfo dirInf = new DirectoryInfo(oldDirectory);

            if (!dirInf.Exists)
            {
                throw new DirectoryNotFoundException("Directory doesn't exist or could not be found: " + oldDirectory);
            }

            DirectoryInfo[] dirs = dirInf.GetDirectories();
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            FileInfo[] files = dirInf.GetFiles();
            foreach (FileInfo file in files)
            {
                string path = Path.Combine(newDirectory, file.Name);
                file.CopyTo(path, false);
            }

            if (CopySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string path = Path.Combine(newDirectory, subdir.Name);
                    CopyDirectory(subdir.FullName, path, CopySubDirs);
                }
            }
        }


    }
}
