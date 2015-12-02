using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ExtremeElements
    {
        static int Min(int[] items)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < items.Length; i++)
            {
                numbers.Add(items[i]);
            }
            return numbers.Min();
        } 

        static int Max(int[] item)
        {
            List<int> num = new List<int>();
            for (int i = 0; i < item.Length; i++)
            {
                num.Add(item[i]);
            }
            return num.Max();
        }

        static void Main(string[] args)
        {
            int[] numItem = new int[] { 6, 4, 5, 1, 7, 8 };
            Console.WriteLine(Min(numItem));
            Console.WriteLine(Max(numItem)); 
            Console.Read();
        }
    }
}
