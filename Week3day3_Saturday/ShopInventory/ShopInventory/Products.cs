using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATTaxLibrary;

namespace ShopInventory
{
    class Products
    {
        private double ProductBeforeTax;
        private double ProductAfterTax;
        private string ProductCountry;
        private string ProductName;
        private int ProductQuantity;
        private int ProductID;


        public Products(int price, string ProductCountry,string ProductName,int ProductQuantity,int ProductID)
        {
            ProductBeforeTax = price;
            ProductAfterTax = PriceAfterTax(price, ProductCountry);
            this.ProductCountry = ProductCountry;
            this.ProductName = ProductName;
            this.ProductQuantity = ProductQuantity;
            this.ProductID = ProductID;

        }



        public double ProductsBeforeTax
        {
            get { return ProductBeforeTax; }

        }

        public double ProductsAfterTax
        {
            get { return ProductAfterTax; }
        }

        public string ProductsCountry
        {
            get { return ProductCountry; }
        }


        public string ProductsName
        {
            get { return ProductName; }
        }

        public int ProducstQuantity
        {
            get { return ProductQuantity; }
        }


        public int ProductIDs
        {
            get { return ProductID; }
        }


        public double PriceAfterTax(int price,string country)
        {
            List<CountryVatTax> CountryList = new List<CountryVatTax>
          {
              new CountryVatTax(20,"Bulgaria",true),
              new CountryVatTax(30,"France",false),
              new CountryVatTax(25,"Spain",false),
              new CountryVatTax(15,"Germany",false),
              new CountryVatTax(35,"Greece",false),
              new CountryVatTax(10,"Italy",false),
              new CountryVatTax(40,"Poland",false)

        };
            double helper;
            TaxCalculator calc = new TaxCalculator(CountryList);
            helper = (double)(price + calc.CalculateTax(price,country));

            return helper;
        }

    }
}
