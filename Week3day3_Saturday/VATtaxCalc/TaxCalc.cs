using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATtaxCalc
{
    class TaxCalc
    {
        private List<CountryVatTax> VatTax = new List<CountryVatTax>();


        public  TaxCalc(List<CountryVatTax> VatTax)
        {
            this.VatTax = VatTax;
        }



        public double CalculateTax(int price,string country)
        {
            double tax = double.MinValue;
            foreach (var searcher in VatTax)
            {
                if (searcher.CountryID == country)
                {
                    tax = (double)((price) * (double)searcher.TaxPercent / 100);
                }
            }
                if (tax != double.MinValue) {

                    return tax;
                }
                else
                {
                    throw new ArgumentException("The country is not supported.");
                }

            }



        public double CalculateTax(int price)
        {
            double tax = double.MinValue;
            foreach (var searcher in VatTax)
            {
                if (searcher.IsDefault)
                {
                    tax = (double)((price) * (double)searcher.TaxPercent / 100);
                }
            }
            if (tax!= double.MinValue)
            {
                return tax;
            } else
            {
                throw new ArgumentException("Can't find the default country!");
            }
        }
    }
}
