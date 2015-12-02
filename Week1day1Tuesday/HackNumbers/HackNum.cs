using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackNumbers
{
    class HackNum
    {
       static bool isHackNum(int Decimal)
        {
            bool HackNums = false;
            int counter = 0;
            string  BinaryResult = Convert.ToString(Decimal, 2);

            string firstHlf = BinaryResult.Substring(0, BinaryResult.Length / 2);
            char[] arr = BinaryResult.ToCharArray();
            Array.Reverse(arr);
            string holder = new string(arr);
            string secondHlf = holder.Substring(0, holder.Length / 2);

            foreach (char item in BinaryResult)
            {
                if (item == '1')
                {
                    counter++;
                }
            }
            if (counter % 2 != 0 && firstHlf.Equals(secondHlf) == true)
            {
                HackNums = true;
            }

            return HackNums;
        }


        static  int nextHackNum(int NextNum)
        {
            bool nxtNum = true;
            int helper = NextNum + 1;
            while (nxtNum)
            {
                
                int counter = 0;
                string BinaryResult = Convert.ToString(helper, 2);
                string firstHlf = BinaryResult.Substring(0, BinaryResult.Length / 2);
                char[] arr = BinaryResult.ToCharArray();
                Array.Reverse(arr);
                string holder = new string(arr);
                string secondHlf = holder.Substring(0, holder.Length / 2);

                foreach (char item in BinaryResult)
                {
                    if (item == '1')
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0 && firstHlf.Equals(secondHlf) == true)
                {
                    nxtNum = false;
                }
                else
                {
                    helper++;
                }
            }

            return helper;
        }




        static void Main(string[] args)
        {
            Console.Write("Enter an int to check if it's a hacknumber: ");
            int num = Int32.Parse(Console.ReadLine());

            Console.Write("Enter an int to check which is the next hacknumber after that int: ");
            int next = Int32.Parse(Console.ReadLine());


            Console.WriteLine("Is " + num + " a hacknumber? {0}! " , isHackNum(num));
            Console.WriteLine("The next hack num is {0}.", nextHackNum(next));

            Console.Read();
        }
    }
}
