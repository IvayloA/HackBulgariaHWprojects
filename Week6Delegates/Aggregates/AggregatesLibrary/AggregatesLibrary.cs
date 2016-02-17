using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesLibrary
{
    public delegate decimal AggregationDelegate(decimal sum,decimal currentNum);

    public class AggregatesLib
    {
        public  List<int> Create(List<int> aggList)
        {
            return aggList;
        }

        public decimal AggregateCollection(List<int> originalList,AggregationDelegate aggregate)
        {
            decimal sum = 0;
            foreach (var item in originalList)
            {
                sum = aggregate(sum, item);
            }
            return sum;
        }
        
        public decimal Sum(decimal sum, decimal currentSum)
        {
            return sum + currentSum;
        } 

    }
}
