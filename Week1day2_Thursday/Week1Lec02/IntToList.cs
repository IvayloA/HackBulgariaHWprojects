using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Lec02
{
    class IntToList
    {
        static List<int> NumberToList(int num)
        {
            List<int> numDigits = new List<int>();
            int numLength = num.ToString().Length;
            for (int i = 0; i < numLength; i++)
            {         
                    numDigits.Add(num % 10);
                    num = num / 10;  
            }
            numDigits.Reverse();
            Console.Write("The number in the list is: ");
            return numDigits;
        }
        static void Main(string[] args)
      {
            Console.Write("Ender a number: ");
            List<int> result = NumberToList(Int32.Parse(Console.ReadLine()));
            foreach (int digit in result)
            {
                Console.Write(digit);
            }
            Console.Read();
        }
    }
}
