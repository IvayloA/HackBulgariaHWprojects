using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartialEmployeeLibrary;

namespace PartialEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee test = new Employee(FirstName: "Jim", LastName: "Smith", Position: "UX Designer", Salary: 5000, Bonus: 1500);
          
            Console.WriteLine(test.CalculateAllIncome());
            Console.WriteLine(test.CalculateBalanced());
            test.Info();
            Console.ReadLine();
        }
    }
}
