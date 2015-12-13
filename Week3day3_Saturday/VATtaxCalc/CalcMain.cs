using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATtaxCalc
{
    class CalcMain
    {
        static void Main()
        {
            List<CountryVatTax> CountryList = new List<CountryVatTax>
          {
              new CountryVatTax(20,"Bulgaria",true),
              new CountryVatTax(30,"France",false),
              new CountryVatTax(25,"Spain",false),
              new CountryVatTax(15,"Germany",false),
              new CountryVatTax(35,"Greece",false),
              new CountryVatTax(10,"Italy",false)

        };


            TaxCalc taxCalc = new TaxCalc(CountryList);

            Console.Write("Enter a country ");
            string Country = Console.ReadLine();
            Console.Write("Enter a price ");
            string Price = Console.ReadLine();

            if (Country.Length > 0)
            {
                Console.WriteLine("The tax in {0} is {1}",Country,taxCalc.CalculateTax(int.Parse(Price),Country));
            } else
            {
                Console.WriteLine("The tax in {0} is {1}",Country,taxCalc.CalculateTax(int.Parse(Price)));
            }
            Console.Read();
        }
    }
}
