using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day1
{
    class ReverseAString
    {
        static void ReverseString(ref List<int> List)
        {
            string helper = null;
            string reverse = null;

            foreach (var item in List)
            {
                helper = helper + item;
            }
            for (int i = helper.Length - 1; i >= 0; i--)
            {
                reverse = reverse + helper[i];
            }
            Console.WriteLine(reverse);
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 123456 };
            ReverseString(ref list);
            Console.ReadLine();

        }
    }
}
