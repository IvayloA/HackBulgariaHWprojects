using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class FunctionFact
    {
        static void Main(string[] args)
        {
            int fact = 1;
            int n = 5;
            for (int i = 1; i<=n; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine("factorial of " + n + " is: {0}", fact);
            Console.ReadLine();
        }
    }
}
