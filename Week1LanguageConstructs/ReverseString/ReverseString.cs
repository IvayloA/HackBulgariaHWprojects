using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static string ReverseMe(string text)
        {
            char[] cArray = text.ToCharArray();
            Array.Reverse(cArray);
            return new string(cArray);
        }
        static void Main(string[] args)
        {
            string input = "This string will be reversed.";
            Console.WriteLine(ReverseMe(input));
            Console.Read();
        }
    }
}
