using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CashDeskLibraby
{
    public class BatchBill: IEnumerator, IEnumerable
    {
        private List<Bill> BatchBll;

        private int index = -1;

        public object Current      
        {
            get
            {
                return BatchBll[index];
            }
        }

        public BatchBill(List<Bill> BatchBll)
        {
            this.BatchBll = BatchBll;

        }
        
        public  int Count()
        {
            return BatchBll.Count;
        }

        public int Total()
        {
            int total = 0;
            foreach (var item in BatchBll)
            {
                total = total + item.Value();
            }
            return total;
        }


        public override string ToString()
        {
            return string.Format("Number of bills: {0} Total value: ${1}", Count(), Total());
        }

        public bool MoveNext()
        {
            index++;
            return (index < BatchBll.Count);
        }

        public void Reset()
        {
            index = 0;
        }


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)BatchBll).GetEnumerator();
        }


    }
}
