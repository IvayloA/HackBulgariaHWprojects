using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatesLibrary;

namespace Aggregates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            AggregatesLib test = new AggregatesLib();

            test.Create(testList);
            decimal result = test.AggregateCollection(testList, test.Sum);
            Console.WriteLine(result);
            Console.Read();

        }
    }
}
