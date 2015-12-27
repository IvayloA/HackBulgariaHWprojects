using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPairLibrary
{
    public class Pair<T>
    {
        private readonly T pair1;
        private readonly T pair2;


        public Pair(T pair1, T pair2)
        {
            this.pair1 = pair1;
            this.pair2 = pair2;
        }

        public T FirstPair { get { return pair1; } }
        public T SecondPair { get { return pair2; } }



        public override bool Equals(object obj)
        {
            Pair<T> p1 = this;
            Pair<T> p2 = (Pair<T>)obj;
            if (p1.pair1.Equals(p2.pair1) && p1.pair2.Equals(p2.pair2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Pair<T> p1, Pair<T> p2)
        {
            if (object.ReferenceEquals(p1, p2))
            {
                return true;
            }
            if ((object)p1 == null && (object)p2 != null || (object)p1 != null && (object)p2 == null)
            {
                return false;
            }
            if (p1.pair1.Equals(p2.pair1) && p1.pair2.Equals(p2.pair2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Pair<T> p1, Pair<T> p2)
        {
            return !(p1 == p2);
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

        public override string ToString()
        {
            return string.Format("Pair [{0},{1}]",pair1,pair2);
        }
    }
}
