using Squares.Application.Dtos;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Requests
{
    public class CreateSquaresDetectionEntryRequest : IUseCaseRequest<SquaresDetectionEntryResponse>
    {
        public List<PointDto> Points { get;}
        public CreateSquaresDetectionEntryRequest(List<PointDto> points) 
        {
            Points = points;
        }
    }
}
