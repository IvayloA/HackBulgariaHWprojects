using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSpan
{
    class MaxSpan
    {
        static int MaximumSpan(List<int> list)
        {
            if (list.Count < 2)
                return 1;

            int left = 0;
            int right = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[0] == list[list.Count - 1 - i])
                {
                    left = list.Count - i;
                    break;
                }
                else if (list[list.Count - 1] == list[i])
                {
                    right = list.Count - i;
                    break;
                }
            }

            if (left >= right)
                return left;
            else
                return right;
        }

        static void Main()
        {
            List<int> numbers = new List<int> { 2, 3, 2, 1, 4, 2, 2, 6 };
            Console.WriteLine("The max span is: " + MaximumSpan(numbers));
            Console.ReadLine();
        }
    }
}