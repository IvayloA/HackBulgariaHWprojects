using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
   public class Adult : Person
    {
        private List<Children> ListOfKids;


        public Adult(string name, string gender)
        {
            this.Name = name;
            this.Gender = gender;
            ListOfKids = new List<Children>();
        }

        public bool IsBoring { get; set; }

        public void Work()
        {
            Console.WriteLine("{0} is at work.",Name);
        }

        public int KidsInFamily()
        {
            return ListOfKids.Count;
        }

        public void HaveKids(Children child)
        {
            ListOfKids.Add(child);
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine("Name:" + Name);
            strb.AppendLine("Gender:" + Gender);
            strb.Append("Number of kids: " + ListOfKids.Count);
            return strb.ToString();
        }

    }
}
