using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibunaci
{
    class Program
    { 
        static void Fibunacci(int number,int fibunacci)
        {
            int fib1 = 1;
            int fib2 = 1;


            for (int i = 0; i < number; i++)
            {
                if (i==0)
                {
                    fibunacci = fib1;
                    Console.Write("{0} ", fibunacci);
                }
                else if (i==1)
                {
                    fibunacci = fib2;
                    Console.Write("{0} ", fibunacci);
                } else
                {
                    fibunacci = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = fibunacci;
                    Console.Write("{0} ", fibunacci);
                }
            }
        }

        static void Main(string[] args)
        {
     
            Fibunacci(6, 0);
            Console.ReadLine();
        
        }
    }
}

