using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class MainApplication
    {
        static void Main()
        {
            List<Animal> AnimalList = new List<Animal>
            {
                new Dog(),
                new Cat(),
                new Shark(),
                new Owl(),
                new Crocodile()
            };

            Crocodile croc = new Crocodile();

            croc.ReptileTemperature = 40;

            Shark sharky = new Shark();

            sharky.MyFish = 1;

            Console.WriteLine(sharky.FishSize());
        
            Console.WriteLine(croc.Temperature());
            foreach (var animal in AnimalList)
            {
                animal.Greet();
                animal.Eat();
            }

            Console.Read();

        }
    }
}
