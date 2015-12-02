using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseEachWord
{
    class ReverseEachWord
    {
        static string ReverseEWord(string text)
        {
            string[] array = text.Split(' ').Reverse().ToArray();
            string reverseWords = string.Join(" ", array);
            string result = new string(reverseWords.Reverse().ToArray()).ToLower();
            return result;
        } 
        static void Main(string[] args)
        {
            string input = "Each word should be reversed";
            Console.WriteLine(ReverseEWord(input));
            Console.Read();
        }
    }
}
