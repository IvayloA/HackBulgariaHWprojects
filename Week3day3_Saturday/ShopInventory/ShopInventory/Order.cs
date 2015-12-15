using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopInventory
{
    class Order
    {
        private List<int> ProductIDs;
        private List<int> Quantities;

        public Order(List<int> ProductIDs,List<int> Quantities)
        {
            this.ProductIDs = ProductIDs;
            this.Quantities = Quantities;
            if (this.ProductIDs.Count != ProductIDs.Count)
            {
                throw new ArgumentException("ProcuntIDs count must be the same");
            }
        }

        public List<int> OrderProductID
        {
            get { return ProductIDs; }
        }

        public List<int> OrderQuantity
        {
            get { return Quantities; }
        }
    }
}
