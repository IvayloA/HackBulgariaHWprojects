using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
   public class Toy
    {
        private string Color;
        private int Size;

        public Toy(string color,int size)
        {
            this.Color = color;
            this.Size = size;
        }
       
        public string ToyColor { get { return Color; } }
        public int ToySize { get { return Size; } }
    }
}
