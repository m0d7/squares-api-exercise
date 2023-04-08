using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Dtos
{
    public class SquaresDetectionEntryDto
    {
        public string Id { get; set; }
        public IList<PointDto> InputPoints { get; set; }

        public IList<SquareDto> DetectedSquares { get; set; }

        public int DetectedSquaresCount { get; set; }
    }
}
