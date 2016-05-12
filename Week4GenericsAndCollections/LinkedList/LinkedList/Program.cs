using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();

            list.Add("best");
            list.Add("west");
            list.Add("door");
            list.Add("house");
            list.Add("park");
            list.Add("dog");

            Console.WriteLine("Number of items in the list =" + list.Count + "\n");

            list.InsertAfter("west", "blue");
            list.InsertAt(1, "tree");
           // list.Remove("tree");
            list[4] = "red";

            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
            Console.Read();
        }
    }
}
