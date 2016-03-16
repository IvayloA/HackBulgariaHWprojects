using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerPalindrom
{
    class IntPalindrome
    {
        static bool isIntPalindrome(long Number)
        {
            bool isPalindrome = false;
            string Holder = Convert.ToString(Number);

            string firstHlf = Holder.Substring(0, Holder.Length / 2);
            char[] arr = Holder.ToCharArray();
            Array.Reverse(arr);
            string helper = new string(arr);
            string secondHlf = helper.Substring(0, helper.Length / 2);
            if (firstHlf.Equals(secondHlf) == true)
            {
                isPalindrome = true;
            }
           

            return isPalindrome;
        }


        private static long LargestPalindrome(long number)
        {

            string numbStr = String.Empty;
            int counter = 0;

            while (number > 0)
            {
                numbStr = Convert.ToString(number);
                if (numbStr.Length % 2 == 0)
                {
                    for (int i = 0; i < numbStr.Length / 2; i++)
                    {
                        if (numbStr[i] == numbStr[numbStr.Length - (i + 1)])
                        {
                            counter++;
                        }
                    }
                    if (counter == numbStr.Length / 2)
                    {
                        return number;
                    }
                    else counter = 0;
                } else if (numbStr.Length % 2 != 0)
                {
                    for (int i = 0; i < (numbStr.Length / 2) + 1; i++)
                    {
                        if (numbStr[i] == numbStr[numbStr.Length - (i + 1)])
                        {
                            counter++;
                        }
                    }
                    if (counter == (numbStr.Length / 2) + 1)
                    {
                        return number;
                    }
                    else counter = 0;
                }
                number--;
            }
            return 0;
        }


        static void Main(string[] args)
        {
            Console.Write("Enter a number to check if it's a palindrome. ");
            long num = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Is the number {0} a palindrome? {1}", num, isIntPalindrome(num));

            Console.Write("Write a number: ");
            string  numHolder = Console.ReadLine();
            long numTest = Convert.ToInt64(numHolder);

            Console.Write("Next palindrome smaller than {0} is: ", numTest);
            Console.WriteLine(LargestPalindrome(numTest));
            Console.ReadLine();
        }
    }
}
