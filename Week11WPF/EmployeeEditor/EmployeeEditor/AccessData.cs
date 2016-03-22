using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEditor
{
    static class AccessData
    {
        static HackCompanyEntities context = new HackCompanyEntities();

       public static HackCompanyEntities Context { get {return context; } }

        public static void SaveChanges()
        {
            context.SaveChanges();
        }

        public static void AddEmployee()
        {
            context.Employees.Create();
        }

        public static List<Employee> GetEmployeesWithNonNullManagerID()
        {
            return context.Employees.Where(x => x.ManagerID > 0 ).ToList();
        }
    }


}
