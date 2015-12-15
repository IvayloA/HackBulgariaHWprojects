using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopInventory
{
    class ShopInventoryMain
    {


        static void Main()
        {
            List<Products> productList = new List<Products>()
            {
                new Products(10,"Bulgaria","banica",2,1001),
                new Products(100,"Germany","beer",1,1002),
                new Products(10,"Poland","apple",2,1003),
                new Products(50,"Spain","chocolate",3,1004)
            };

            Inventory shopInventory = new Inventory(productList);
            Console.WriteLine("If you sell all of the producs your profit will be {0} $",shopInventory.Audit());

            List<int> ProductId = new List<int>() {1001, 1002, 1003, 1004 };
            List<int> ProductQuantity = new List<int>() { 1, 1, 1, 2 };

            Order order = new Order(ProductId, ProductQuantity);
            Console.WriteLine("You have to pay {0} $ for your order.",shopInventory.RequestedOrder(order));
            Console.Read();
        }
    }
}
