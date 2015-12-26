using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    class Triangle : Shape
    {
        protected Point Vertex1;
        protected Point Vertex2;
        protected Point Vertex3;
        protected Point TriangleCenter;

        public Triangle(Point Vertex1,Point Vertex2,Point Vertex3,Point Center)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Vertex3 = Vertex3;
            TriangleCenter = Center;
        }

        public Point vertex1 { get; set; }
        public Point vertex2 { get; set; }
        public Point vertex3 { get; set; }
        public Point triangleCenter { get; set; }

        public override double GetPerimeter()
        {
            double LineOne =  Math.Sqrt(Math.Pow((Vertex2.CoordY - Vertex1.CoordY), 2) + Math.Pow((Vertex2.CoordX - Vertex1.CoordX), 2));
            double LineTwo = Math.Sqrt(Math.Pow((Vertex3.CoordY - Vertex2.CoordY), 2) + Math.Pow((Vertex3.CoordX - Vertex2.CoordX), 2));
            double LineThree = Math.Sqrt(Math.Pow((Vertex1.CoordY - Vertex3.CoordY), 2) + Math.Pow((Vertex1.CoordX - Vertex3.CoordX), 2));

            return LineOne + LineTwo + LineThree;
        }

        public override double GetArea()
        {
            double LineOne = Math.Sqrt(Math.Pow((Vertex2.CoordY - Vertex1.CoordY), 2) + Math.Pow((Vertex2.CoordX - Vertex1.CoordX), 2));
            double LineTwo = Math.Sqrt(Math.Pow((Vertex3.CoordY - Vertex2.CoordY), 2) + Math.Pow((Vertex3.CoordX - Vertex2.CoordX), 2));
            double LineThree = Math.Sqrt(Math.Pow((Vertex1.CoordY - Vertex3.CoordY), 2) + Math.Pow((Vertex1.CoordX - Vertex3.CoordX), 2));

            double SemiPerimeter = (LineOne + LineTwo + LineThree) / 2;

            double AreaResult = Math.Sqrt(SemiPerimeter * (SemiPerimeter - LineOne) * (SemiPerimeter - LineTwo) * (SemiPerimeter - LineThree));

            return AreaResult;
        }

        public override void Move(double coordX, double coordY)
        {
            TriangleCenter.Move(coordX, coordY);
        }
    }
}
