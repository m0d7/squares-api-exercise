using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Domain.Entities
{
    public class Square
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public Point PointD { get; set; }

        public Square(Point pointA, Point pointB, Point pointC, Point pointD)
        {
            this.PointA = pointA;
            this.PointB = pointB;
            this.PointC = pointC;
            this.PointD = pointD;
        }
    }
}
