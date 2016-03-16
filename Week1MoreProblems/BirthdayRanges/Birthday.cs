using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayRanges
{
    class Birthday
    {
        static List<int> BirthdayRanges(List<int> birthdays, List<KeyValuePair<int, int>> ranges)
        {
            List<int> resultList = new List<int>();
            int counter = 0;

            foreach (var pair in ranges)
            {
                counter = 0;
                foreach (var birthday in birthdays)
                {
                    if (pair.Key <= birthday && pair.Value >= birthday)
                    {
                        counter++;
                    }
                }
                resultList.Add(counter);
            }

            return resultList;
        }


        static void Main()
        {
            List<int> birthdays = new List<int> { 55, 10, 56, 7, 43, 4, 5, 11, 21, 300, 15, 5, 6 };
            List<KeyValuePair<int, int>> ranges = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int> (4, 9),
                new KeyValuePair<int, int> (6, 7),
                new KeyValuePair<int, int> (150, 225),
                new KeyValuePair<int, int> (50, 365)
            };

            List<int> resultList = BirthdayRanges(birthdays, ranges);
            foreach (var item in resultList)
            {
                Console.Write(item + "  ");
            }
            Console.ReadLine();
        }
    }
}