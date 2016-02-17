using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Bird : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Flying");
        }

        public override void Greet()
        {
            Console.WriteLine("Bird greetings");
        }

        public void Nesting()
        {
            Console.WriteLine("Making a nest.");
        }
    }
}
