using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Increasing
{
   
    class Increasing
    { 
       static bool IsIncreasing(int[] sequence)
        {       
            for (int i = 1; i < sequence.Length ; i++)
            {
                if (sequence[i-1] > sequence[i])
                {
                    return false;
                }  
            }

            return true;   
        }
        static void Main(string[] args)
        {
          
            int[] array = { 1, 3, 4, 5, 6 };
            bool result =  IsIncreasing(array);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
