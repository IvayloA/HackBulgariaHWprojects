using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDeskLibraby
{
   public class CashDesk
    {
        private Dictionary<Bill, int> billDesk = new Dictionary<Bill, int>();


        public void TakeMoney(Bill bill)
        {
            if (billDesk.ContainsKey(bill))
            {
                billDesk[bill]++;
            }
            else
            {
                billDesk.Add(bill, 1);
            }
        }
        public void TakeMoney(BatchBill batchbill)
        {
            foreach (Bill bill in batchbill)
            {
                if (billDesk.ContainsKey(bill)) {
                    billDesk[bill]++;
                }
                else
                {
                    billDesk.Add(bill, 1);
                }
            }            
        }

        public int Total()
        {
          int  total = 0;
            foreach (var bill in billDesk)
            {
                total = total + bill.Key.Value() * bill.Value;
            }
            return total;
        }

        public void Inspect()
        {
            var HaveBills = from pair in billDesk orderby pair.Key.Value() ascending select pair;

            foreach (var pair in HaveBills)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
