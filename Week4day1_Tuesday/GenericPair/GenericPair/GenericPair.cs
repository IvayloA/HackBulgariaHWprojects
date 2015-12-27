using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericPairLibrary;

namespace GenericPair
{
     class Program
    {
       static void Main()
        {
            Pair<int> p1 = new Pair<int>(12, 21);
            Pair<int> p2 = new Pair<int>(13, 32);

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1 != p2);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString() + "\n\n");



            Pair<string> str1 = new Pair<string>("test", "best");
            Pair<string> str2 = new Pair<string>("test", "best");

            Console.WriteLine(str1.Equals(str1));
            Console.WriteLine(str1 == str2);
            Console.WriteLine(str1 != str2);
            Console.WriteLine(str1.ToString());
            Console.WriteLine(str1.ToString());

            Console.Read();
        }
    }
}
