using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Mammals : Animal
    {
        public override void Greet()
        {
            Console.WriteLine("Mammal greetings.");
        }

        public override void Move()
        {
            Console.WriteLine("Walking");
        }

    }
}
