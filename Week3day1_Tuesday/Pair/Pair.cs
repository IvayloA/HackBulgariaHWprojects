using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair
{
    class Pair
    {
        private readonly int pair1;
        private readonly int pair2;

        public  Pair(int pair1, int pair2)
        {
            this.pair1 = pair1;
            this.pair2 = pair2;
        }

        public override string ToString()
        {
            string repre = "This is a miningful representaion of the class";

            return repre;
        }

        public override bool Equals(object obj)
        { 
            if (obj == null)
            {
                return false;
            }
            Pair p = obj as Pair;
            if ((object)p==null)
            {
                return false;
            }
            if (((object)pair1 == null && (object)pair2 != null) || ((object)pair1 != null && (object)pair2 == null))
            {
                return false;
            }
            return (pair1 == p.pair1) && (pair2 == p.pair2);
            
        }

        public static bool operator ==(Pair x,Pair y)
        {
            if (x.Equals((object)y))
            {
                return true;
            }
            else
            {
                return false;
            }
          

        }

        public static bool operator !=(Pair a,Pair b)
        {
            if (a.Equals((object)b))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + pair1.GetHashCode();
                hash = hash * 23 + pair2.GetHashCode();
                return hash;
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Pair pair1 = new Pair(6, 2);
            Pair pair2 = new Pair(6, 2);

            Console.WriteLine(pair1.Equals(pair2));
            Console.WriteLine(pair1 == pair2);
            Console.WriteLine(pair1 != pair2);
            Console.WriteLine(pair1.ToString());
            Console.Read();

        }
    }
}
