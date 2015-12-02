using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDigits
{
    class Digits
    {
        static int CountDigits(int Number)
        {
            string numberHoler = Convert.ToString(Number);
            int counter = 0;
            foreach (char item in numberHoler)
            {
                counter++;

            }
            return counter;
        }


        static int SumDigits(int Number)
        {
            string NumHolder = Convert.ToString(Number);
            int sum = 0;
            foreach (char item in NumHolder)
            {
                sum = sum + (int)Char.GetNumericValue(item);
            }
            return sum;
        }

        static int Factorial(int Number)
        {
            if (Number == 0)
            {
                return 1;
            }
            else
            {
                    return (Number * Factorial(Number - 1));
            }
        }


        static int FactorialDigits(int Number)
        {
            string NumHolder = Convert.ToString(Number);
            int sum = 0;
            foreach (char item in NumHolder)
            {
                sum = sum + Factorial((int)Char.GetNumericValue(item));
            }

            return sum;


        }


        static void Main(string[] args)
        {
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Number of digits in {0} is {1}.", number, CountDigits(number));
            Console.WriteLine("Sum of digits in {0} is {1}.", number, SumDigits(number));
            Console.WriteLine("Factorial Sum of digits in {0} is {1}.", number, FactorialDigits(number));
            Console.Read();
        }
    }
}
