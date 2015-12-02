using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharHistogram
{
    class CharHistogram
    {
        static void CharHist(string input)
        {
            input = input.Replace(" ", "");
            Dictionary<char, int> hist = new Dictionary<char, int>();
            if (!String.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];

                    if (hist.ContainsKey(c))
                    {
                        hist[c] = hist[c] + 1;
                    } else
                    {
                        hist.Add(c, 1);
                        
                    }
                }
            }

            foreach (KeyValuePair<char,int> item in hist)
            {
                Console.Write("{0}={1} ",item.Key, item.Value);
            }
            
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            CharHist(str);
            Console.Read();
        }
    }
}
