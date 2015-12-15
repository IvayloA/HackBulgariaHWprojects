using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATTaxLibrary;


namespace ShopInventory
{
    class Inventory
    {
        private  List<Products> InventoryList;

        public Inventory(List<Products> List)
        {
            InventoryList = List;
        }

        public double Audit()
        {
            double total = 0;
            foreach (var item in InventoryList)
            {
                total = total + item.ProductsAfterTax * item.ProducstQuantity;
            }
            return total;
        }
      public double RequestedOrder(Order order)
        {
            double amount = 0;
            for (int i = 0; i < order.OrderProductID.Count; i++)
            {
                for (int j = 0; j < InventoryList.Count; j++)
                {
                    if (order.OrderProductID[i] == InventoryList[j].ProductIDs)
                    {
                        if (order.OrderQuantity[i] <= InventoryList[j].ProducstQuantity)
                        {
                            amount = amount + InventoryList[j].ProductsAfterTax * order.OrderQuantity[i];
                        }
                        else
                        {
                            throw new ArgumentException("Not enough product quantities");
                        }
                    }
                    //else if (j == order.OrderProductID.Count - 1)
                    //{
                    //    throw new ArgumentException("The product is out of stock");
                    //}
                }
            }
            return amount;
        }
    }
}
