using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decreasing
{
    class Decreasing
    {
        static bool IsDecreasing(int [] sequence)
        {
            for (int i = 1; i < sequence.Length; i++)
            {
                if(sequence[i-1] < sequence[i])
                {
                    return false;
                } 
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[] array = { 6, 5, 4, 3, 1 };
            bool result = IsDecreasing(array);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
