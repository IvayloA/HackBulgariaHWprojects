using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATtaxCalc
{
    class CountryVatTax
    {
        private readonly int CountryTax;
        private readonly string Country;
        private readonly bool DefaultCounrty;

        public CountryVatTax(int countryTax,string country, bool defaultcountry = false)
        {
            CountryTax = countryTax;
            Country = country;
            DefaultCounrty = defaultcountry;
        }


        public string CountryID
        {
            get
            {
                return Country;
            }
        }


        public int TaxPercent
        {
            get
            {
                return CountryTax;
            }
        }

        public bool IsDefault
        {
            get
            {
                return DefaultCounrty;
            }
        }


    }
}
