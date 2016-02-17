using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQlib;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            Program test = new Program();
         //   test.Method1();
         //   test.Method2();
         //   test.Method3();
           test.Method4();
         //   test.Method5();
            Console.Read();

        }

        public void Method1()
        {
            List<Product> prodList = productList();

            //var result = prodList.Where(p => p.ProductID > 5 && p.ProductID < 15);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //} 

            var result = (
               from n in prodList
               where (n.ProductID > 4 && n.ProductID < 15)
               select n).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        public void Method2()
        {
            List<Category> categoryLst = categoryList();

            var categoryResult = categoryLst.Where(c => c.CategoryID >= 3 && c.CategoryID < 8);

            foreach (var item in categoryResult)
            {
                Console.WriteLine(item);
            }
        }

        public void Method3()
        {
            List<Order> orderLst = orderList();
            var orderResult = from ord in orderLst
                              where ord.OrderID < 45
                              orderby ord.OrderName //you can add descending 
                              select ord;

            foreach (var item in orderResult)
            {
                Console.WriteLine(item);
            }
        }
        public void Method4() {
            List<Order> orderLst = orderList();
            var orderByTimeResult = orderLst.Where(p => p.Products.Contains(3)).OrderBy(p => p.OrderDate).Take(3);


            foreach (var item in orderByTimeResult)
            {
                Console.WriteLine(item);
            }
        }

        public void Method5()
        {
            List<Category> categoryLst = categoryList();
            List<Product> productLst = productList();
            var productsCategory = from cat in categoryLst
                                   join produc in productLst on cat.CategoryID equals produc.CategoryID
                                   orderby cat.CategoryName
                                   select new { productName = produc.Name, categoryName = cat.CategoryName };

            foreach (var item in productsCategory)
            {
                Console.WriteLine("productNAME = {0}  categoryNAME = {1}", item.productName, item.categoryName);
            }
        }

        public List<Product> productList()
        {
            List<Product> productList = new List<Product>
            {
              new Product(name:"Water",productID:1,categoryID:1),
              new Product(name:"Chocolate",productID:2,categoryID:2),
              new Product(name:"Meat",productID:3, categoryID:3),
              new Product(name:"Bread",productID:4,categoryID:4),
              new Product(name:"Shampoo",productID:5,categoryID:5),
              new Product(name:"Cheese",productID:6,categoryID:6),
              new Product(name:"Beer",productID:7,categoryID:7),
              new Product(name:"Ham",productID:8,categoryID:8),
              new Product(name:"Bacon",productID:9,categoryID:9),
              new Product(name:"Fanta",productID:10,categoryID:10),
              new Product(name:"Wine",productID:11,categoryID:11),
              new Product(name:"Chips",productID:12,categoryID:12),
              new Product(name:"Bubblegum",productID:6,categoryID:13),
              new Product(name:"Nuts",productID:2,categoryID:14)
          };
            return productList;
        }

        public List<Category> categoryList()
        {
            List<Category> categoryLst = new List<Category>
            {
                new Category(categoryID:9,categoryName:"Garden"),
                new Category(categoryID:4,categoryName:"Tools"),
                new Category(categoryID:8,categoryName:"School"),
                new Category(categoryID:7,categoryName:"Sport"),
                new Category(categoryID:5,categoryName:"Business"),
                new Category(categoryID:6,categoryName:"Casual"),
                new Category(categoryID:3,categoryName:"Drinking"),
                new Category(categoryID:1,categoryName:"Alchohol"),
                new Category(categoryID:2,categoryName:"Soda"),
                new Category(categoryID:10,categoryName:"Diet"),
                new Category(categoryID:11,categoryName:"FastFood"),
                new Category(categoryID:12,categoryName:"Work")
            };
            return categoryLst;
        }


        public List<Order> orderList()
        {
            List<int> OrderIdList1 = new List<int> { 1, 3, 2, 10, 5, 3 };
            List<int> OrderIdList2 = new List<int> { 4, 2, 1, 5, 11, 32 };
            List<int> OrderIdList3 = new List<int> { 98, 56, 34, 2, 1, 22 };
            List<int> OrderIdList4 = new List<int> { 10, 21, 13, 2, 1, 3 };
            List<int> OrderIdList5 = new List<int> { 15, 1, 3, 10, 23, 19 };
            List<int> OrderIdList6 = new List<int> { 15, 10, 3, 54, 40, 32 };
            List<int> OrderIdList7 = new List<int> { 7, 10, 20, 76, 23, 87 };


            List<Order> orderList = new List<Order>
            {
                new Order(orderID: 40, orderName: "Madrid", orderDate: new DateTime(2015,03,21,21,22,04), products: OrderIdList1),
                new Order(orderID: 41, orderName: "Miami", orderDate: new DateTime(2014,02,01,15,12,34), products: OrderIdList2),
                new Order(orderID: 42, orderName: "Sofia", orderDate: new DateTime(2014,01,10,18,46,13), products: OrderIdList3),
                new Order(orderID: 43, orderName: "Barcelona", orderDate: new DateTime(2014,05,20,16,34,01), products: OrderIdList4),
                new Order(orderID: 44, orderName: "LosAngeles", orderDate: DateTime.Now, products: OrderIdList5),
                new Order(orderID: 45, orderName: "Berlin", orderDate: new DateTime(2015,06,18,03,43,15), products: OrderIdList6),
                new Order(orderID: 46, orderName: "Munich", orderDate: new DateTime(2015,10,12,14,55,14), products: OrderIdList7),
                new Order(orderID: 47, orderName: "London", orderDate: new DateTime(2015,12,31,05,45,59), products: OrderIdList5),
                new Order(orderID: 48, orderName: "Moscow", orderDate: new DateTime(2015,11,24,07,09,23), products: OrderIdList4),
                new Order(orderID: 49, orderName: "Manchester", orderDate: new DateTime(2015,07,03,04,14,36), products: OrderIdList3),
                new Order(orderID: 50, orderName: "NewYork", orderDate: new DateTime(2015,09,02,08,03,39), products: OrderIdList2)
            };
            return orderList;
        }
    }
}
