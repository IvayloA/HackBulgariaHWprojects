using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyEveryCharacterKthTimes
{
    class CopyEveryCharacter
    {

        static string CopyEveryChar(string input, int k)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                result.Append(input[i], k);
            }
            return result.ToString();
        }

        static void Main()
        {
            Console.Write("Enter a string: ");
            string userInput = Console.ReadLine();
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine("\nResult: " + CopyEveryChar(userInput, k));
            Console.ReadLine();
        }


    }
}