using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStackLibrary;


namespace GenericStackApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() {1,3,5,7,9,12,14,15};          

            GenericStack<int> stack1 = new GenericStack<int>(list1);

            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Peek());
            stack1.Push(42);
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Contains(23));
            Console.WriteLine("\n");

            List<string> list2 = new List<string>() { "test", "beta", "delta", "out", "of ideas", " JK" };

            GenericStack<string> stack2 = new GenericStack<string>(list2);

            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Peek());
            stack2.Push("Hola");
            Console.WriteLine(stack2.Peek());
            Console.WriteLine(stack2.Contains("beta"));
            Console.Read();
        }
    }
}
