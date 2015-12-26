using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Circle : Ellipse
    {
        protected double radius;
        protected Point CircleCenter;

        public Circle(double radius,Point Center) : base(radius,radius,Center)
        {
            this.radius = radius;
            CircleCenter = Center;
        }

        public Point CircCenter { get { return  CircleCenter; } set { CircleCenter = value; } }

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                RadX = value;
                RadY = value;
            }
        }


        public override double radiusX
        {
            get
            {
                return base.radiusX;
            }

            set
            {
                base.radiusX = value;
                if (base.radiusX != base.radiusY)
                {
                    base.radiusY = value;
                    radius = value;
                }
            }
        }


        public override double radiusY
        {
            get
            {
                return base.radiusY;
            }

            set
            {
                base.radiusY = value;
                if (base.radiusY != base.radiusX)
                {
                    base.radiusX = value;
                    radius = value;
                }
            }
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }


        public override double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override string ToString()
        {
            return string.Format("Circle \n Radius = {0} \n Perimeter = {1} and Area = {2}", radius, GetPerimeter(), GetArea());
        }
    }
}
