using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Ellipse : Shape
    {
        protected double RadX;
        protected double RadY;
        protected Point EllipseCenter;

        public Ellipse(double RadX, double RadY, Point Center)
        {
            this.RadX = RadX;
            this.RadY = RadY;
            EllipseCenter = Center;
        }

        public virtual double radiusX { get; set; }
        public virtual double radiusY { get; set; }
        public Point Center { get; set; }



        public override double GetPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(RadX, 2) + Math.Pow(RadY, 2)) / 2);

        }


        public override double GetArea()
        {
            return Math.PI * RadX * RadY;
        }


        public override void Move(double coordX, double coordY)
        {
            EllipseCenter.Move(coordX, coordY);
        }


        public override string ToString()
        {
            return string.Format("Ellipse\n semi-axisX = {0} and semi-axisY = {1}.\n Perimeter = {2} and Area = {3}", RadX, RadY, GetPerimeter(), GetArea());
        }
    }
}
