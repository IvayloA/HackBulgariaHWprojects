using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerPalindrom
{
    class IntPalindrome
    {
        static bool isIntPalindrome(int Number)
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
        static void Main(string[] args)
        {
            Console.Write("Enter a number to check if it's a palindrome. ");
            int num = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Is the number {0} a palindrome? {1}", num, isIntPalindrome(num));
            Console.Read();
        }
    }
}
