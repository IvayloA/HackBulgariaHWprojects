using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibrary
{
    public delegate bool FilterDelegate(int FilterLists);

    public class FilterClassLibrary
    {
       public List<int> Creator(List<int> list)
        {
            return list;
        }

        public List<int> Filter(List<int> list,FilterDelegate filterList)
        {
            List<int> result = new List<int>();

            foreach (var value in list)
            {
                if (filterList(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public bool IsEven(int value)
        {
            return value % 2 != 0;
        }

    }
}
