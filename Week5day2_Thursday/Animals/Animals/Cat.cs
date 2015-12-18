using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
   public class Cat : Mammals
    {
        public override void Greet()
        {
            Console.WriteLine("Meow");
        }
    }
}
