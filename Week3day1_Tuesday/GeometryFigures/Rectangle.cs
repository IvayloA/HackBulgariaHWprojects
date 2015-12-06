using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    class Rectangle
    {
        private readonly Point point1;
        private readonly Point point2;
        private readonly Point point3;
        private readonly Point point4;
        private readonly LineSegment line1;
        private readonly LineSegment line2;
        private readonly LineSegment line3;
        private readonly LineSegment line4;


        public Rectangle(Point pt1,Point pt3)
        {
            if (pt1.MyXCoord == pt3.MyXCoord || pt1.MyYCoord == pt3.MyYCoord)
            {
                throw new ArgumentException("The points can't be on the same coordinate axis");
            } else
            {
                Point newPt1 = new Point(pt1.MyXCoord, pt3.MyYCoord);
                Point newPt2 = new Point(pt3.MyXCoord, pt1.MyYCoord);
                this.point1 = pt1;
                this.point2 = newPt1;
                this.point3 = pt3;
                this.point4 = newPt2;


                LineSegment newLine1 = new LineSegment(point1, point2);
                LineSegment newLine2 = new LineSegment(point2, point3);
                LineSegment newLine3 = new LineSegment(point3, point4);
                LineSegment newLine4 = new LineSegment(point4, point1);
                this.line1 = newLine1;
                this.line2 = newLine2;
                this.line3 = newLine3;
                this.line4 = newLine4;
                
            }
        }


        public Rectangle(Rectangle old)
        {
          
            point1 = old.point1;
            point2 = old.point2;
            point3 = old.point3;
            point4 = old.point4;

            line1 = old.line1;
            line2 = old.line2;
            line3 = old.line3;
            line4 = old.line4;
        }


        public Point FirstPoint
        {
            get { return point1; }
        }

        public Point SecondPoint
        {
            get { return point2; }
        }

        public Point ThirdPoint
        {
            get { return point3; }
        }

        public Point FourthPoint
        {
            get { return point4; }
        }



        public LineSegment FirstLine
        {
            get { return line1; }
        }

        public LineSegment SecondLine
        {
            get { return line2; }
        }

        public LineSegment ThirdLine
        {
            get { return line3; }
        }

        public LineSegment FourthLine
        {
            get { return line4; }
        }


        public double Width
        {
            get
            {
                return line1.GetLength();
            }
        }


        public double Height
        {
            get
            {
                return line2.GetLength();
            }
        }

       
        public Point RectangleCenter
        {
            get
            {
                double CenterX =(double)((point1.MyXCoord + point3.MyXCoord) / 2);
                double CenterY = (double)((point1.MyYCoord + point3.MyYCoord) / 2);
                Point CenterCoord = new Point(CenterX, CenterY);
                return CenterCoord;
            }
        }



        public  double GetPerimeter()
        {
            return (2 * line1.GetLength() + 2 * line2.GetLength());
        }


        public double GetArea()
        {
            return (line1.GetLength() * line2.GetLength());
        }


        public override string ToString()
        {
            string helper = "Rectangle(" + point1.ToString()+","+ point3.ToString() + "),Height,Width:(" + this.Height + "," + this.Width + ")";
            return helper;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                Rectangle rect1 = this;
                Rectangle rect2 = (Rectangle)obj;

                if (rect1.GetPerimeter() == rect2.GetPerimeter() && rect1.GetArea() == rect2.GetArea())
                {
                    return true;
                } else
                {
                    return false;
                }

            }
            return false;
        }

        public static bool operator ==(Rectangle rect1,Rectangle rect2)
        {
            if (object.ReferenceEquals(rect1,rect2))
            {
                return true;
            }
            if (((object)rect1 == null && (object)rect2 != null) || ((object)rect1 != null && (object)rect2 == null))
            {
                return false;
            }

            if (rect1.GetArea() == rect2.GetArea() && rect1.GetPerimeter() == rect2.GetPerimeter())
            {
                return true;
            }
            return false;
        }


        public static bool operator !=(Rectangle rect1,Rectangle rect2)
        {
            return !(rect1 == rect2);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + point1.GetHashCode();
                hash = hash * 23 + point3.GetHashCode();
                return hash;
            }
        }
    }
}
