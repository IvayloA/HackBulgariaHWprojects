using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
   public  class Square : Rectangle
    {
        protected double Side;


        public Square(double Side,Point Center) : base(Side,Side,Center)
        {
            this.Side = Side;
            this.Center = Center;
        }



        public double side
        {
            get
            {
                return Side;
            }
            set
            {
                Side = value;
                Width = value;
                Heigth = value;            
            }
        }


        public override double width
        {
            get
            {
                return base.width;
            }

            set
            {
                base.width = value;
                if (base.width != base.heigth)
                {
                    base.heigth = value;
                    Side = value;
                }
            }
        }

        public override double heigth
        {
            get
            {
                return base.heigth;
            }

            set
            {
                base.heigth = value;
                if (base.heigth != base.width)
                {
                    base.width = value;
                    Side = value;
                }
            }
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return string.Format("Square\n Side = {0} ,\n Perimeter = {1} and Area = {2}", Side, GetPerimeter(), GetArea());
        }

    }
}
