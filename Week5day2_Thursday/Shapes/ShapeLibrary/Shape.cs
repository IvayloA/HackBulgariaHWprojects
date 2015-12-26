using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShapeLibrary
{
    public abstract class Shape : IMovable
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();

        public abstract void Move(double coordX, double coordY);

    }
}
