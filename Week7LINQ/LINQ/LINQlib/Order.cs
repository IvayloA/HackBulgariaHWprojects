using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQlib
{
    public class Order
    {

        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<int> Products { get; set; }

        public Order(int orderID,string orderName,DateTime orderDate,List<int> products)
        {
            OrderID = orderID;
            OrderName = orderName;
            OrderDate = orderDate;
            Products = products;
        }

        public override string ToString()
        {
            return string.Format("OrderID = {0}  OrderName = {1}  OrderDate = {2} ", OrderID,OrderName,OrderDate); 
        }
    }
}
