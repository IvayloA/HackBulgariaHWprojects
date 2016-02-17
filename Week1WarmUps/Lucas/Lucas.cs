using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucas
{
    class Program
    {
        static void luccas(int number, int lucas)
        {
            /*
             * TODO Optimazi it !
             */
            int luc1 = 2;
            int luc2 = 1;
       
            for (int i = 0; i < number; i++)
            {
                if (i == 0)
                {
                    lucas = luc1;
                    Console.Write("{0} ", lucas);
                } else if(i == 1)
                {
                    lucas = luc2;
                    Console.Write("{0} ", lucas);
                } else
                {
                    lucas = luc1 + luc2;
                    luc1 = luc2;
                    luc2 = lucas;
                    Console.Write("{0} ", lucas);
                }
               
            }
        }

        static void Main(string[] args)
        {
            luccas(6, 0);
            Console.Read();
        }
    }
}

