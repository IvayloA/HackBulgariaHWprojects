using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    class Point
    {
        public static readonly Point Origin = new Point(0, 0);
        private readonly  double  x;
        private readonly double y;
       
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(Point old)
        {
            x = old.x;
            y = old.y;
        }
        public double MyXCoord
        {
            get
            {
                return x;
            }
        }
        public double MyYCoord
        {
            get
            {
                return y;
            }
        }
        public override string ToString()
        {
            string helper = "Point coords are (" + this.x + "," + this.y + ")";
            return helper;
        }
        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point point1 = this;
                Point point2 = (Point)obj;
                if (point1.x == point2.x && point1.y == point2.y)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }


        public static bool operator ==(Point p1, Point p2)
        {
            if ((p1.x == p2.x) && ((p1.y == p2.y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            public static bool operator !=(Point p1, Point p2)
        {
            if ((p1.x == p2.x) && (p1.y == p2.y)) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                return hash;
            }
        }


        public static LineSegment operator +(Point pt1,Point pt2)
        {
            LineSegment LineSegm = new LineSegment(pt1, pt2);
            return LineSegm;
        }


        static void Main(string[] args)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(1, 3);
            Point pt3 = new Point(4, 2);
            Point pt4 = new Point(2.5, 1);

            LineSegment ls1 = new LineSegment(pt1, pt2);
            LineSegment ls2 = new LineSegment(pt3, pt4);


            Rectangle rect1 = new Rectangle(pt1, pt3);
            Rectangle rect2 = new Rectangle(pt2, pt4);

            Console.WriteLine("-----Point class test-----");
            Console.WriteLine(pt1.Equals(pt3));
            Console.WriteLine(pt1 == pt3);
            Console.WriteLine(pt1 != pt3);
            Console.WriteLine(pt1.ToString());
            Console.WriteLine(pt3.ToString());
            Console.WriteLine();

            Console.WriteLine("-----LineSegment class test-----");
            Console.WriteLine(ls1.StartPoint);
            Console.WriteLine(ls1.EndPoint);
            Console.WriteLine((pt1 + pt3).ToString());
            Console.WriteLine(ls2.GetLength());
            Console.WriteLine();

            Console.WriteLine("-----Rectangle class test-----");
            Console.WriteLine(rect1.FirstLine);
            Console.WriteLine(rect1.SecondLine);
            Console.WriteLine(rect1.ThirdLine);
            Console.WriteLine(rect1.FourthLine);
            Console.WriteLine(rect2.FirstLine);
            Console.WriteLine(rect2.SecondLine);
            Console.WriteLine(rect2.ThirdLine);
            Console.WriteLine(rect2.FourthLine);

            Console.WriteLine(rect1.Width);
            Console.WriteLine(rect1.Height);
            Console.WriteLine(rect1.ToString());
            Console.WriteLine(rect2.ToString());
            Console.WriteLine(rect1.GetArea());
            Console.WriteLine(rect1.GetPerimeter());

            Console.Read();

        }
    }
}
