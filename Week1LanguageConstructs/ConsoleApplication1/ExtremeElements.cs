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

        static int NthMin(int n,int[] items)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < items.Length; i++)
            {
                numbers.Add(items[i]);
            }
            numbers.Sort();

            return numbers[n];

        }

        static int NthMax(int n, int[] items)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < items.Length; i++)
            {
                numbers.Add(items[i]);
            }
            numbers.Sort();
            numbers.Reverse();    

            return numbers[n];

        }

        static void Main(string[] args)
        {
            int[] numItem = new int[] { 6, 4, 5, 1, 7, 8 , 12, 32, 2, 3, 10, 52, 31, 9, 11, 14};
            int x = 6;
            int y = 2;
            Console.WriteLine("The min number is: " + Min(numItem));
            Console.WriteLine("The max number is: " + Max(numItem));
            Console.WriteLine("The {0} min number is: " + NthMin(x,numItem),x);
            Console.WriteLine("The {0} max number is: " + NthMax(y,numItem),y);
            Console.ReadLine();
        }
    }
}
