using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDequeueLibrary;


namespace GenericDequeue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 1, 3, 5, 7, 9, 12, 16 };
            GenericDequeue<int> dequeue1 = new GenericDequeue<int>(list1);

            Console.WriteLine(dequeue1.PeekFromFront());
            Console.WriteLine(dequeue1.PeekFromEnd() + "\n -----");
            dequeue1.RemoveFromFront();
            dequeue1.RemoveFromEnd();
            Console.WriteLine(dequeue1.PeekFromFront());
            Console.WriteLine(dequeue1.PeekFromEnd() + "\n -----");
            dequeue1.AddToFront(15);
            dequeue1.AddToEnd(100);
            Console.WriteLine(dequeue1.PeekFromFront());
            Console.WriteLine(dequeue1.PeekFromEnd() + "\n -----");

            List<string> list2 = new List<string>() {"this","earth","word","apple","desktop"};
            GenericDequeue<string> dequeue2 = new GenericDequeue<string>(list2);


            Console.WriteLine(dequeue2.PeekFromFront());
            Console.WriteLine(dequeue2.PeekFromEnd() + "\n -----");
            dequeue2.RemoveFromFront();
            dequeue2.RemoveFromEnd();
            Console.WriteLine(dequeue2.PeekFromFront());
            Console.WriteLine(dequeue2.PeekFromEnd() + "\n -----");
            dequeue2.AddToFront("best");
            dequeue2.AddToEnd("west");
            Console.WriteLine(dequeue2.PeekFromFront());
            Console.WriteLine(dequeue2.PeekFromEnd() + "\n -----");

            Console.Read();
        }
    }
}
