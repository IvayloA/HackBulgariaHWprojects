using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAnagram
{
    class Anagram
    {
        static bool IsAnagram(string string1, string string2)
        {
            string firstHolder = null;
            string secondHolder = null;
            char[] test1 = null;
            char[] test2 = null;
            test1 = string1.Replace(" ", "").ToLower().ToCharArray();
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
                return true;
            }
            else return false;

        }

        static bool HasAnagramOf(string string1, string string2)
        {
            bool hasAnagram = false;

            string1 = string1.Replace(" ", "");
            StringBuilder currentSequence = new StringBuilder();

            for (int i = 0; i <= string2.Length - string1.Length; i++)
            {
                for (int j = i; j < i + string1.Length; j++)
                {
                    currentSequence.Append(string2[j]);
                }

                if (IsAnagram(string1, currentSequence.ToString()))
                {
                    hasAnagram = true;
                    break;
                }
                else
                    currentSequence.Clear();
            }

            return hasAnagram;
        }


        static void Main(string[] args)
        {
            string firstWord = "William Shakespeare";
            string secondWord = "I am a weakish speller";
            string thirdString = "weak spell";

            Console.WriteLine(IsAnagram(firstWord, secondWord));
            Console.WriteLine(HasAnagramOf(thirdString, secondWord));

            Console.ReadLine();
        }
    }
}