using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
   class Program
    {

        static void Main()
        {

            test1 test = new test1();
            test.ValueOne = 1;
            test.ValueTwo = 2;
            test.StringValue = "test";

            ExtensionMethod.IncrementExtensionMethod(test);

            Console.WriteLine(test.ValueOne);
            Console.WriteLine(test.ValueTwo);
            Console.WriteLine(test.StringValue);
            Console.ReadLine();
          
        }
    }
}