using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Children : Person
    {

        private List<Toy> toyList;

        public Children(string name,string gender)
        {
            Name = name;
            Gender = gender;
            toyList = new List<Toy>();
        }


        public void Play()
        {
            Console.WriteLine("{0} is playing",Name);
        }

        public int ToyNum()
        {
            return toyList.Count;
        }


        public void GetToys(Toy toy)
        {
            toyList.Add(toy);
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine("Name:" + Name);
            strb.AppendLine("Gender:" + Gender);
            strb.Append("NumberOfToys:" + toyList.Count);
            return strb.ToString();
        }       
    }
}
