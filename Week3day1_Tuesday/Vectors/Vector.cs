using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Vector
    {
        private List<double> vector;
        private int vectDim;

        public Vector(double[] VectCoord)
        {
            this.vector = new List<double>();
            for (int i = 0; i < VectCoord.Length; i++)
            {
                this.vector.Add(VectCoord[i]);
            }

        }


        public Vector(Vector copyVect)
        {
            this.vector = new List<double>();
            for (int i = 0; i < copyVect.vector.Count; i++)
            {
                this.vector.Add(copyVect.vector[i]);
            }
        }


        public double this[int i]
        {
            get
            {
                return vector[i];
            }
            set
            {
                vector[i] = value;
            }
             
        }

        public int GetDimensionalty
        {
           get
            {
                return vectDim;
            }
            set
            {
                this.vectDim = vector.Count;
            }
        }


        public double VectorLenght()
        {
            double sqrSum = 0;
            for (int i = 0; i < vector.Count; i++)
            {
                sqrSum = sqrSum + Math.Pow(vector[i], 2);
            }
            return Math.Sqrt(sqrSum);
        }


        public override string ToString()
        {
            string helper = null;
            foreach (double number in vector)
            {
                helper =   helper + " " + number ;
            }
            return "Vect[" + helper + " ]";
        }


        public override bool Equals(object obj)
        {
            int counter = 0;
            if (obj is Vector)
            {
                Vector vect1 = this;
                Vector vect2 = (Vector)obj;
                if (vect1.vector.Count == vect2.vector.Count)
                {
                    for (int i = 0; i < vect1.vector.Count; i++)
                    {
                        if (vect1[i] == vect2[i])
                        {
                            counter++;
                        }
                    }
                    if (counter == vect1.vector.Count)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                return false;
            }
            return false;
        }


        public static bool operator ==(Vector vct1 , Vector vct2)
        {
            int counter = 0;
            if (vct1.vector.Count == vct2.vector.Count)
            {
                for (int i = 0; i < vct1.vector.Count; i++)
                {
                    counter++;
                }
                if (counter == vct1.vector.Count)
                {
                    return true;
                } else
                {
                    return false;
                }
             
            }
            return false;
        }


        public static bool operator !=(Vector vct1, Vector vct2)
        {
            return !(vct1 == vct2);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.GetDimensionalty != v2.GetDimensionalty)
            {
                throw new ArgumentException("Can't add vectors with different dimensions");
            }
            else
            {
                int size = v1.GetDimensionalty;
                double[] ArrHelper = new double[size];
                for (int i = 0; i < ArrHelper.Length; i++)
                {
                    ArrHelper[i] = v1[i] + v2[i];
                }
                Vector VctHelper = new Vector(ArrHelper);
                return VctHelper;
            }
        }


        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.GetDimensionalty != v2.GetDimensionalty)
            {
                throw new ArgumentException("Can't subtract vectors with different dimensions");
            }
            else
            {
                int size = v1.GetDimensionalty;
                double[] ArrHelper = new double[size];
                for (int i = 0; i < ArrHelper.Length; i++)
                {
                    ArrHelper[i] = v1[i] - v2[i];
                }
                Vector VctHelper = new Vector(ArrHelper);
                return VctHelper;
            }
        }



        public static Vector operator +(Vector v1, int index)
        {
            int size = v1.GetDimensionalty;
            double[] ArrHelper = new double[size];
            for (int i = 0; i < ArrHelper.Length; i++)
            {
                ArrHelper[i] = v1[i] + index;
            }
                Vector VctHelper = new Vector(ArrHelper);
                return VctHelper;
            
        }


        public static Vector operator -(Vector v1, int index)
        {          
                int size = v1.GetDimensionalty;
                double[] ArrHelper = new double[size];
                for (int i = 0; i < ArrHelper.Length; i++)
                {
                    ArrHelper[i] = v1[i] - index;
                }
                Vector VctHelper = new Vector(ArrHelper);
                return VctHelper;
            
        }


        public static Vector operator *(Vector v1, int index)
        {
            int size = v1.GetDimensionalty;
            double[] ArrHelper = new double[size];
            for (int i = 0; i < ArrHelper.Length; i++)
            {
                ArrHelper[i] = v1[i] * index;
            }
            Vector VctHelper = new Vector(ArrHelper);
            return VctHelper;

        }


        public static Vector operator /(Vector v1, int index)
        {
            int size = v1.GetDimensionalty;
            double[] ArrHelper = new double[size];
            for (int i = 0; i < ArrHelper.Length; i++)
            {
                ArrHelper[i] = v1[i] / index;
            }
            Vector VctHelper = new Vector(ArrHelper);
            return VctHelper;

        }


        public static Vector operator *(Vector v1, Vector v2)
        {
            if (v1.GetDimensionalty != v2.GetDimensionalty)
            {
                throw new ArgumentException("Can't find the dot product of two vectors with different dimension");
            } else
            {
                int size = v1.GetDimensionalty;
                double[] ArrHelper = new double[size];
                for (int i = 0; i < ArrHelper.Length; i++)
                {
                    ArrHelper[i] = ArrHelper[i] + v1[i] * v2[i];
                }
                Vector VctHelper = new Vector(ArrHelper);
                return VctHelper;
            }


        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 7;
                foreach (var index in vector)
                {
                    hash = hash * 13 + index.GetHashCode();
                }

                return hash;
            }
        }


        static void Main(string[] args)
        {
            
            double[] test1 = new double[] { 3, 2, 1, 5, 6, 7, 8 };
            double[] test2 = new double[] { 5, 3, 2, 6, 8, 2, 1 };
            Vector v1 = new Vector(test1);
            Vector v2 = new Vector(test2);
            int scalar = 2;
            v1.GetDimensionalty = test1.Count();
            v2.GetDimensionalty = test2.Count();

            Console.WriteLine(v1.ToString());
            Console.WriteLine(v2.ToString());
            Console.WriteLine(v1.GetDimensionalty);
            Console.WriteLine(v2.GetDimensionalty);
            Console.WriteLine(v1.VectorLenght());
            Console.WriteLine(v2.VectorLenght());
            Console.WriteLine(v1 + v2);
            Console.WriteLine(v1 * v2);
            Console.WriteLine(v1 - v2);
            Console.WriteLine(v1 + scalar);
            Console.WriteLine(v2 + scalar);
            Console.WriteLine(v1 - scalar);
            Console.WriteLine(v2 - scalar);
            Console.WriteLine(v1 * scalar);
            Console.WriteLine(v2 * scalar);
            Console.WriteLine(v1 / scalar);
            Console.WriteLine(v2 / scalar);

            Console.Read();

        }
    }
}
