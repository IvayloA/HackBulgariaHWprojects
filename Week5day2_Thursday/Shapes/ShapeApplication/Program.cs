using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;

namespace ShapeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(5, new Point(0, 0));
            Console.WriteLine("Square width = {0}",square.width);
            square.heigth = 10;
            Console.WriteLine("Square new width = {0}",square.width);
            Console.WriteLine(square.GetArea());
            Console.WriteLine(square.GetPerimeter());
            square.Move(5, -2);
            Console.WriteLine("square center = {0}",square.center);


            Circle circle = new Circle(12, new Point(0, 0));
            Console.WriteLine(circle.Radius);
            circle.radiusX = 4;
            Console.WriteLine(circle.Radius);
            Console.WriteLine();


            Rectangle rectangle = new Rectangle(5, 2, new Point(0, 0));
            rectangle.heigth = 20;

            Console.WriteLine(square.ToString()+"\n");
            Console.WriteLine(circle.ToString()+"\n");
            Console.WriteLine(rectangle.ToString()+"\n");


            Console.WriteLine("Circle center = {0} ",circle.CircCenter);
            circle.Move(3, -4);
            Console.WriteLine("Circle new center = {0}",circle.CircCenter);


            Console.Read();
        }
    }
}
