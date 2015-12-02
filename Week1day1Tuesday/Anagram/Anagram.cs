using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Anagram
    {
     static void  IsAnagram(string string1,string string2)
        {
            bool wordsAreAnagrams = false;
            string firstHolder = null;
            string secondHolder = null;
            char[] test1 = null;
            char[] test2 = null;
            test1 = string1.Replace(" ","").ToLower().ToCharArray();
            Array.Sort(test1);
            test2 = string2.Replace(" ", "").ToLower().ToCharArray();
            Array.Sort(test2);

            foreach (char item in test1)
            {
                firstHolder = firstHolder + item;
            }
            foreach (char index in test2)
            {
                secondHolder = secondHolder + index;
            }
            if (string.Compare(firstHolder, secondHolder) == 0)
            {
                wordsAreAnagrams = true;
                Console.WriteLine(wordsAreAnagrams);
            } else
            {
                Console.WriteLine(wordsAreAnagrams);
            }
             
        }

        static void Main(string[] args)
        {
            string firstWord = "William Shakespeare";
            string secondWord = "I am a weakish speller";
            IsAnagram(firstWord, secondWord);
            Console.ReadLine();
        }
    }
}
