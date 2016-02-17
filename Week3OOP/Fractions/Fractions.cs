using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Fractions
    {
        private int numerator;
        private int denominator;

        public Fractions()
        {

        }

        public Fractions(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            if (this.denominator == 0)
            {
                throw new ArgumentException("Denominator can't be 0!");
            }
        }
        public int MyNumerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        public int MyDenominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator can't be 0.");
                }
                else
                {
                    denominator = value;
                }
            }

        }
        public override string ToString()
        {
            string result = numerator + "/" + denominator;
            return result;
        }

        /*
        ******************************************************************************************
        * TODO Define the +,-,/,*;
        */

        public static double operator *(Fractions x, Fractions y)
        {
            Console.WriteLine("Overloading the operator '*' for 2 Fractions.");
            return ((double)x.numerator / x.denominator) * ((double)y.numerator / y.denominator);

        }


        public static double operator /(Fractions x, Fractions y)
        {
            Console.WriteLine("Overloading the operator '/' for 2 Fractions.");
            return ((double)x.numerator / x.denominator) * ((double)y.denominator / y.numerator);

        }


        public static double operator +(Fractions x, Fractions y)
        {
            Console.WriteLine("Overloading the operator '+' for 2 Fractions.");
            if (x.denominator == y.denominator)
            {
                return ((double)x.numerator + y.numerator) / (double)x.denominator;
            } else
            {
                
                int  helper1 = x.denominator;
                int   helper2 = y.denominator;

                x.numerator = x.numerator * helper2;
                x.denominator = helper1 * helper2;
                y.numerator = y.numerator * helper1;
                y.denominator = helper2 * helper1;


                return ((double)x.numerator + y.numerator) / (double)x.denominator;
            }
        }


        public static double operator -(Fractions x,Fractions y)
        {
            Console.WriteLine("Overloading the operator '-' for 2 Fractions.");
            if (x.denominator == y.denominator)
            {
                return ((double)x.numerator - y.numerator) / (double)x.denominator;
            }
            else
            {
                int helper1 = x.denominator;
                int helper2 = y.denominator;

                x.numerator = x.numerator * helper2;
                x.denominator = helper1 * helper2;
                y.numerator = y.numerator * helper1;
                y.denominator = helper2 * helper1;


                return ((double)x.numerator - y.numerator) / (double)x.denominator;
            }
        }



        public static double operator *(Fractions x, double y)
        {
            Console.WriteLine("Overloading the operator '*' for a Fraction and a double.");
            return (((double)x.numerator * y) / x.denominator) ;

        }


        public static double operator /(Fractions x, double y)
        {
            Console.WriteLine("Overloading the operator '/' for a Fraction and a double.");
            return ((double)x.numerator / x.denominator) * ((double)1 / y);

        }


        public static double operator +(Fractions x, double y)
        {
            Console.WriteLine("Overloading the operator '+' for a Fraction and a double.");

                y = y * x.denominator;

                return ((double)x.numerator + y) / (double)x.denominator;
            
        }


        public static double operator -(Fractions x, double y)
        {
            Console.WriteLine("Overloading the operator '-' for a Fraction and a double.");
            y = y * x.denominator;

             return ((double)x.numerator - y) / (double)x.denominator;
            
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Fractions fract = obj as Fractions;
            if ((object)fract == null)
            {
                return false;
            }

            return (numerator == fract.numerator) && (denominator == fract.denominator);
        }


        public static bool operator ==(Fractions a, Fractions b)
        {
            if (a.numerator.Equals((object)0) && b.numerator.Equals((object)0))
            {
                return true;
            }
            if ((((double)a.numerator / a.denominator) / ((double)b.numerator / b.denominator)) == 1)
            {
                return true;
            } else
            {
                return false;
            }
            

        }


        public static bool operator !=(Fractions a,Fractions b)
        {
            if (a.numerator.Equals((object)0) && b.numerator.Equals((object)0))
            {
                return false;
            }
            if ((((double)a.numerator / a.denominator) / ((double)b.numerator / b.denominator)) == 1)
            {
                return false;
            }
            else
            {
                return true;
            }



        }

        public static explicit operator double (Fractions result)
        {
            Console.WriteLine("working");
            return ((double)result.numerator / (double)result.denominator);
        }



        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + numerator.GetHashCode();
                hash = hash * 23 + denominator.GetHashCode();
                return hash;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
          
            Fractions fract1 = new Fractions();
            Fractions fract2 = new Fractions();
            double dble = 0.5;

            fract1.MyNumerator = 1;
            fract1.MyDenominator = 2;
            fract2.MyNumerator = 3;
            fract2.MyDenominator = 2;
            double test = (double)fract1;


            Console.WriteLine(test);
            Console.WriteLine(fract1.ToString());
            Console.WriteLine(fract2.ToString());
            Console.WriteLine(fract1 + fract2);
            Console.WriteLine(fract1 - fract2);
            Console.WriteLine(fract1 * fract2);
            Console.WriteLine(fract1 / fract2);
            Console.WriteLine(fract1 + dble);
            Console.WriteLine(fract1 - dble);
            Console.WriteLine(fract1 * dble);
            Console.WriteLine(fract1 / dble);
            Console.WriteLine(fract1 == fract2);
            Console.WriteLine(fract1 != fract2);
            Console.WriteLine(fract1.Equals(fract2));


            Console.Read();



        }
    }
}
