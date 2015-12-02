using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels
{
    class Program
    {
        static void CountVowels(string word)
        {
            int vowelCounter=0;

            word = word.ToLower();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'u' || word[i] == 'i' || word[i] == 'o' || word[i] == 'e' || word[i] == 'y')
                {
                    vowelCounter++;
                }
            }
            Console.WriteLine("The number of vowels is: {0}",vowelCounter);
            Console.ReadLine();
        }
        class Vowels
        {
            static void Main(string[] args)
            {
                Console.Write("Enter a string: ");
                string word = Console.ReadLine();
                CountVowels(word);
            }
        }
    }
}
