using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3day1
{
    class Time
    {


        private short year;
        private short month;
        private short day;
        private short hour;
        private short minute;
        private short second;

        public Time()
        {

        }
        public Time(short year, short month, short day, short hour, short minute, short second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public override string ToString()
        {
            string result = (hour + ":" + minute + ":" + second + "  " + day + "." + month + "." + year);
            return result;
        }

        public DateTime Today()
        {
            DateTime result = DateTime.Now;
            return result;
        }
    }
}
