using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    class LineSegment
    {
        private readonly Point point1;
        private readonly Point point2;

        public LineSegment(Point point1 , Point point2)
        {
            if ((point1.MyXCoord == point2.MyXCoord) && (point1.MyYCoord == point2.MyYCoord))
            {
                throw new ArgumentException("Cannot create a line segment with zero length");
            }
            else
            {
                this.point1 = point1;
                this.point2 = point2;
            }
        }



        public LineSegment(LineSegment old)
        {
            point1 = old.point1;
            point2 = old.point2;
        }


        public Point StartPoint
        {
            get
            {
                return point1;
            }
        }
        
        public Point EndPoint
        {
            get
            {
                return point2;
            }
        }

        public  double GetLength()
        {
            return Math.Sqrt(Math.Pow(( point2.MyYCoord - point1.MyYCoord ), 2) + Math.Pow((point2.MyXCoord - point1.MyXCoord), 2));
        }


        public override string ToString()
        {
           string helper = "Line[(" + point1.MyXCoord + "," + point1.MyYCoord + "),(" + point2.MyXCoord + "," + point2.MyYCoord + ")],with length=" + this.GetLength();

            return helper;
        }


        public override bool Equals(object obj)
        {
            if (obj is LineSegment)
            {
                LineSegment line1 = this;
                LineSegment line2 = (LineSegment)obj;
                if (line1.GetLength() == line2.GetLength())
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

        public static bool operator ==(LineSegment Line1,LineSegment Line2)
        {
            if (Line1.GetLength() == Line2.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(LineSegment Line1,LineSegment Line2)
        {
            if (Line1.GetLength() == Line2.GetLength())
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public static bool operator >(LineSegment line1,LineSegment line2)
        {
            if (line1.GetLength() > line2.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool operator <(LineSegment line1,LineSegment line2)
        {
            if (line1.GetLength() < line2.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator >=(LineSegment line1, LineSegment line2)
        {
            if (line1.GetLength() >= line2.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator <=(LineSegment line1, LineSegment line2)
        {
            if (line1.GetLength() <= line2.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator >(LineSegment line1, int length)
        {
            if (line1.GetLength() > length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool operator <(LineSegment line1, int length)
        {
            if (line1.GetLength() < length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator >=(LineSegment line1, int lenght)
        {
            if (line1.GetLength() >= lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator <=(LineSegment line1, int length)
        {
            if (line1.GetLength() <= length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + point1.GetHashCode();
                hash = hash * 23 + point2.GetHashCode();
                return hash;
            }
        }
    }
}
