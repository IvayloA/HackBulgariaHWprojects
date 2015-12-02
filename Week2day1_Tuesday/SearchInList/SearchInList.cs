using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInList
{
    class SearchInList
    {
        static bool IsThereASubString(List<string> List, string searchWord, out int foundWord)
        {
            foundWord = 0;
            string stringHolder = List.ToString();
            string wordHolder = searchWord;
          
            stringHolder.ToLower();
            searchWord.ToLower();

            foreach(var index in List)
            {
                stringHolder = stringHolder + index;
              
            }
            foreach (var item in stringHolder)
            {
                Console.WriteLine(stringHolder[item]);
            }
            return false;
        }

        static void Main(string[] args)
        {
            List<string> strList = new List<string>() {"Random list of words"};
            string normalstr = "list";
            int here = 0;

            IsThereASubString(strList, normalstr, out here);
            Console.Read();
        }
    }
}
