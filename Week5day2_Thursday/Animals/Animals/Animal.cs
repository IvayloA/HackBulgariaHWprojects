using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
   public abstract class Animal
    {
       public virtual void Move()
        {
            Console.WriteLine("Moving");
        }
        public virtual void Greet()
        {
            Console.WriteLine("I'm a land animal");
        }

        public virtual void Eat()
        {
            Console.WriteLine("Nom nom nom !");
        }

        public virtual void GiveBirth()
        {
            Console.WriteLine("Congrats it's a boy/girl !");
        }
    }
}
