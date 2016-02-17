using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayExtensionLibrary;

namespace ArrayExtension
{
    class ArrayExtensionApplication
    {
        static void Main(string[] args)
        {
            List<int> first = new List<int>() { 6, 5, 4, 2, 1, 3, 53 };
            List<int> second = new List<int>() { 6, 32, 4, 21, 1, 9 };

            List<int> result1 = ArrayExtensionLib<int>.Intersect(first, second);
            List<int> result2 = ArrayExtensionLib<int>.UnionAll(first, second);
            List<int> result3 = ArrayExtensionLib<int>.Union(first, second);

            foreach (var item in result1)
            {
                Console.Write(item +" ");
            }
            Console.WriteLine("\n");

            foreach (var item in result2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            foreach (var numb in result3)
            {
                Console.Write(numb + " ");
            }
            Console.Read();
        }
    }
}
