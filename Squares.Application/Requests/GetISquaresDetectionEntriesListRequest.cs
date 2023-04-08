using Squares.Application.Dtos;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Requests
{
    public class GetISquaresDetectionEntriesListRequest : IUseCaseRequest<SquaresDetectionEntriesListResponse>
    {
        public GetISquaresDetectionEntriesListRequest()
        {
           
        }
    }
}
