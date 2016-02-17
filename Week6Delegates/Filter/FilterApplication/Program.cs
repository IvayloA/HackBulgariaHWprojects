using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilterLibrary;

namespace FilterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FilterClassLibrary op = new FilterClassLibrary();
            List<int> test = new List<int>() { 1, 3, 4, 5, 6, 7, 8, 9, 10 };
            op.Creator(test);
            List<int> result = op.Filter(test, op.IsEven);
    
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

    }
}
