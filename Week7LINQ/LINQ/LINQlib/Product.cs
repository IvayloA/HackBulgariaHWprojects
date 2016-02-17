using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQlib
{
    public class Product
    {
                   
        public string Name { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
 
        public Product(string name,int productID,int categoryID)
        {
            Name = name;
            ProductID = productID;
            CategoryID = categoryID;
        }

        public override string ToString()
        {
            return string.Format("Name = '{0}'  ProductID = '{1}'  CategoryID = '{2}'", Name, ProductID, CategoryID);
        }
    }

    
}
