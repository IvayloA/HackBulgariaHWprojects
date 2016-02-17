using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
   public abstract class Reptiles : Animal
    {
        protected int temperature;

        public int ReptileTemperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public override void Greet()
        {
            Console.WriteLine("Reptile greetings");
        }

        public string Temperature()
        {
            string helper;
            if (temperature >= 20)
            {
                helper = "Happy reptile ";
                return helper + temperature;
            }
            else
            {
                helper = "Sad reptile ";
                return helper + temperature;
            }
        }

    }
}
