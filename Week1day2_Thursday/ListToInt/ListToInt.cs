using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListToInt
{
    class ListToInt
    {
        static int ListToNumber(string digits){

            string helper = digits.Replace(" ", "");
            int result = int.Parse(string.Join("", helper));

            return result;
        }
        static void Main(string[] args)
        {
           int number = ListToNumber("3 4 2 1");
            Console.WriteLine(number);
            Console.Read();
        }
    }
}
