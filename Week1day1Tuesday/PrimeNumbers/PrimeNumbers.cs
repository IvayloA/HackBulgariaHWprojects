using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
       static bool isPrime(int number)
        {

            if (number == 1) return false;
            if (number == 2) return true;

            if (number % 2 == 0) return false;

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;

        }

        public static void firstNthPrimes(int number)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < number)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }

            foreach (int item in primes)
            {
                Console.Write(item + " "); ;
            }


        }

        static void Main(string[] args)
        {
            Console.Write("Enter an int to check if it's a prime number: ");
            int num = Int32.Parse(Console.ReadLine());
            Console.Write("Enter an int to check the first Nth prime numbers of that int: ");
            int index = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Is {0} a prime number? {1}",num,isPrime(num));
            Console.Write("The first {0}-th prime numbers are: ", index);
            firstNthPrimes(index);
            Console.Read();

        }
    }
}
