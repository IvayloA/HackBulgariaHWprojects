using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace week3day1
{
  
    class Program
    {

        public DateTime Today()
        {
            DateTime result = DateTime.Now;
            return result;
        }
        static void Main(string[] args)
        {
            Time time1 = new Time(2015, 12, 21, 14, 22, 23);
            Time time2 = new Time(2016, 4, 2, 7, 13, 11);
            Time time3 = new Time();
            
            
            Console.WriteLine(time1.ToString());
            Console.WriteLine(time2.ToString());
            Console.WriteLine(time3.Today());
            Console.Read();
        }
    }
}
