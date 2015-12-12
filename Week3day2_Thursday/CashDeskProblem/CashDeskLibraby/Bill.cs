using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDeskLibraby
{
    public class Bill
    {

        private int amount;

        public Bill(int amount)
        {
            this.amount = amount;
        }


        public override string ToString()
        {

            return "A " + amount + "$ bill.";
        }


        public override bool Equals(object obj)
        {
            if (obj is Bill)
            {
                Bill bill1 = this;
                Bill bill2 = (Bill)obj;
                if (bill1.amount == bill2.amount)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public static bool operator ==(Bill bll1,Bill bll2)
        {
            if (bll1.amount == bll2.amount)
            {
                return true;
            }
            return false;

        }


        public static bool operator !=(Bill bll1, Bill bll2)
        {
            return !(bll1 == bll2);
        }


        public static explicit operator int (Bill result)
        {

            return result.Value();
        }



        public int Value()
        {
            return amount;
        }



        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + amount.GetHashCode();
                hash = hash * 23 + amount.GetHashCode();
                return hash;
            }
        }

    }
}
