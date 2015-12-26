using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Point : IMovable
    {
        protected double coordX;
        protected double coordY;

        public double CoordX { get { return coordX; } set { coordX = value; } }
        public double CoordY { get { return coordY; } set { coordY = value; } }


        public Point(double coordX, double coordY)
        {
            this.coordX = coordX;
            this.coordY = coordY;
        }


        public void Move(double Coordx, double Coordy)
        {
            coordX += Coordx;
            coordY += Coordy;
        }


        public override string ToString()
        {
            return string.Format("Point ({0},{1})",coordX,coordY);
        }

    }
}
