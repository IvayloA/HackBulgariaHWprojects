﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFact
{
    class RecursiveFact
    {
        static int RecursiveFactor(int number, int numTracer)
        {
            if(number == 0)
            {
                return 1;
            } else
            { 
                {
                    return (number * RecursiveFactor(number - 1, numTracer + 1));
                }

            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveFactor(4,0));
            Console.ReadLine();
        }
    }
}
