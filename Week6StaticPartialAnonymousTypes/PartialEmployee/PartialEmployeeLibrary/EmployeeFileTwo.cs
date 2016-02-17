using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialEmployeeLibrary
{
    public partial  class Employee
    {
        private decimal Taxes = 250;

        partial void Print()
        {
            Console.WriteLine("FirstName: "+ FirstName + "\nLastName: " + LastName);
        }

        public decimal CalculateAllIncome()
        {
            return Salary + Bonus;
        }

        public decimal CalculateBalanced()
        {
            return Salary + Bonus - Taxes;
        }

        public void Info()
        {
            Print();
        }
    }
}
