using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialEmployeeLibrary
{
    public partial class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }

        public Employee(string FirstName,string LastName,string Position,decimal Salary,decimal Bonus)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Position = Position;
            this.Salary = Salary;
            this.Bonus = Bonus;
        }

        partial void Print();
    }
}
