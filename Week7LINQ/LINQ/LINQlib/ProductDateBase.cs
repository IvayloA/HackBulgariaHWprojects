using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQlib
{
     static class ProductDateBase
    {
        private static List<Product> productList;
        private static List<Category> categoryList;
        private static List<Order> orderList;


        public static List<Product> productListInstance { get { return productList; }set { productList = value; } }
        public static List<Category> categoryListInstance { get { return categoryList; } set { categoryList = value; } }
        public static List<Order> orderListInstance { get { return orderList; } set { orderList = value; } }

        public static List<Product> GetProduct()
        {
           
            return productList;
        }

        public static List<Category> GetCategories()
        {
            return categoryList;
        }

        public static List<Order> GetOrders()
        {
            return orderList;
        }
    }
}
