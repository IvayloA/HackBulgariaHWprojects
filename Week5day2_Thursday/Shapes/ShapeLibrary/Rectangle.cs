using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        protected double Width;
        protected double Heigth;
        protected Point Center;


        public Rectangle(double Width,double Heigth,Point Center)
        {
            this.Width = Width;
            this.Heigth = Heigth;
            this.Center = Center;
        }

        public virtual double width { get { return Width; } set { Width = value; } }
        public virtual double heigth { get { return Heigth; } set { Heigth = value; } }
        public Point center { get { return Center; } set { Center = value; } }


        public override double GetPerimeter()
        {
            return (2 * Heigth + 2 * Width);
        }

        public override double GetArea()
        {
            return Heigth * Width;
        }

        public override void Move(double crdX, double crdY)
        {
            Center.Move(crdX, crdY);
        }


        public override string ToString()
        {
            return string.Format("Rectangle.\n Width = {0} and Heigth = {1}.\n Perimeter = {2} and Area = {3}", Width, Heigth, GetPerimeter(), GetArea());
        }
    }
}
