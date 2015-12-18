using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
   public abstract  class Fish : Animal
    {

        protected int fishSize;


        public int MyFish
        {
            get { return fishSize; }
            set { fishSize = value; }
        }


        public override void Move()
        {
            Console.WriteLine("Swimming");
        }

        public override void Greet()
        {
            Console.WriteLine("I'm a fish I can't greet you.");
        }


        public string FishSize()
        {
            string helper;
            if (fishSize >= 10)
            {
                helper = "We have a " + fishSize + " ton whale";
                return helper;
            } else if (fishSize <= 10 && fishSize >= 4)
            {
                helper = "We have a " + fishSize + " ton shark";
                return helper;
            }
            else
            {
                helper = "We have a " + fishSize + " kilo fish";
                return helper;
            }
        }
    }
}
