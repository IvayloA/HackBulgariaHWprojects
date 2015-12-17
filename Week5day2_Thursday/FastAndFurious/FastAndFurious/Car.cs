using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious
{
    public abstract class Car
    {
        public abstract bool IsEcoFriendly(bool testing);

        public void Start()
        {
            Console.WriteLine("Vroom");
        } 

    }
    public abstract class GermanCar : Car
    {
        public abstract int MileAge(int mileAge);
    }

    public class Audi : GermanCar
    {
        public override int MileAge(int mileAge)
        {
            return mileAge;
        }

        public override bool IsEcoFriendly(bool testing)
        {
            return true;
        }

    }


    public class BMW : GermanCar
    {
        public override int MileAge(int mileAge)
        {
            return mileAge;
        }
        public override bool IsEcoFriendly(bool testing)
        {
            return true;
        }

    }


    public class Volkswagen : GermanCar
    {
        public override int MileAge(int mileAge)
        {
            return mileAge;
        }

        public override bool IsEcoFriendly(bool testing)
        {
            if (testing == true)
            {
                testing = false;
                return testing;
            } else
            {
                return testing;
            }
        }
    }

    public class Honda : Car
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return true;
        }
    }

    public class Skoda : Car
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return true;
        }
    }

    class MainApplication
    {
        static void Main()
        {
            Audi Audi = new Audi();
            BMW BMW = new BMW();
            Volkswagen Volkswagen = new Volkswagen();
            Skoda Skoda = new Skoda();
            Honda Honda = new Honda();


            bool test = true;

            Console.Write("Enter the mileAge of the Audi.");
            int mileage1 = int.Parse(Console.ReadLine());
            Console.Write("The mileage of Audi is:");
            Console.WriteLine(Audi.MileAge(mileage1));

            Console.Write("Enter the mileAge of the BMW.");
            int mileage2 = int.Parse(Console.ReadLine());
            Console.Write("The mileage of BMW is:");
            Console.WriteLine(BMW.MileAge(mileage2));

            Console.Write("Enter the mileAge of the Volkswagen.");
            int mileage3 = int.Parse(Console.ReadLine());
            Console.Write("The mileage of Volkswagen is:");
            Console.WriteLine(Volkswagen.MileAge(mileage3));

            Console.WriteLine();


            Console.Write("Is Audi eco friendly? ");
            Console.WriteLine(Audi.IsEcoFriendly(test));
            Console.Write("Is BMW eco friendly? ");
            Console.WriteLine(BMW.IsEcoFriendly(test));
            Console.Write("Is Volkswagen eco friendly? ");
            Console.WriteLine(Volkswagen.IsEcoFriendly(test));
            Console.Write("Is Honda eco friendly? ");
            Console.WriteLine(Honda.IsEcoFriendly(test));
            Console.Write("Is Skoda eco friendly ? ");
            Console.WriteLine(Skoda.IsEcoFriendly(test));



            Console.Read();




        }
    }
}
