using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorScalar
{
    class VectorScalar
    {
        static void MaxScalarVect(List<int> vect1, List<int> vect2)
        {
            int firIndex = 0;
            int secIndex = 0;
            int VectScal = 0;
            while(firIndex < vect1.Count && secIndex < vect2.Count)
            {
                VectScal = VectScal + vect1[firIndex] * vect2[secIndex];
                firIndex++;
                secIndex++;
            }
            Console.WriteLine("VectScal = {0}", VectScal);

            int firItem = 0;
            int secItem = 0;
            int MaxVectScal = 0;
            vect1.Sort();
            vect2.Sort();
            while (firItem < vect1.Count && secItem < vect2.Count)
            {
                MaxVectScal = MaxVectScal + vect1[firItem] * vect2[secItem];
                firItem++;
                secItem++;
            }
            Console.WriteLine("VectSum = {0}", MaxVectScal);

        }
        static void Main(string[] args)
        {
            List<int> test = new List<int>(new int[] {  1,2,3 }) ;
            List<int> testv2 = new List<int>(new int[] { 2, 5, 1 });
            MaxScalarVect(test,testv2);
            Console.Read();
        }
    }
}
