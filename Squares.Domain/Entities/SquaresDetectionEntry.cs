using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Domain.Entities
{
    public class SquaresDetectionEntry
    {
        public string Id { get; set; }
        public IList<Point> InputPoints { get; set; }

        public IList<Square> DetectedSquares { get; private set; }

        public int DetectedSquaresCount
        {
            get { return DetectedSquares.Count; }
        }

        public SquaresDetectionEntry(string id, IList<Point> inputPoints)
        {
            this.Id = id;
            this.InputPoints = inputPoints;  
            this.DetectedSquares = new List<Square>();  
        }

        public void IdentifySquares()
        {
            var inputPointsCount = InputPoints.Count;
            for (int i = 0; i < inputPointsCount; i++)
            {
                for (int j = i  + 1; j < inputPointsCount; j++)
                {
                    for (int k = j + 1; k < inputPointsCount; k++)
                    {
                        for (int l = k + 1; l < inputPointsCount; l++)
                        {
                            if (ValidSquare(InputPoints[i], InputPoints[j], InputPoints[k], InputPoints[l]))
                                DetectedSquares.Add(new Square(InputPoints[i], InputPoints[j], InputPoints[k], InputPoints[l]));
                        }
                    }
                }
            }

        }

        public bool ValidSquare(Point p1, Point p2, Point p3, Point p4)
        {
            HashSet<int> distinct = new HashSet<int>
            {
                Dist(p1, p2),
                Dist(p1, p3),
                Dist(p1, p4),
                Dist(p2, p3),
                Dist(p2, p4),
                Dist(p3, p4)
            };

            return distinct.Count == 2 && !distinct.Contains(0);
        }

        public static int Dist(Point p1, Point p2) => (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
    }
}
