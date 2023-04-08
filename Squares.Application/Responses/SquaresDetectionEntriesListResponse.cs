using Squares.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Responses
{
    public class SquaresDetectionEntriesListResponse : UseCaseResponseMessage
    {
        public IList<SquaresDetectionEntryDto> SquaresDetectionEntriesList { get; }
        public SquaresDetectionEntriesListResponse(IList<SquaresDetectionEntryDto> squaresDetectionEntriesList) : base(default, default)
        {
            this.SquaresDetectionEntriesList = squaresDetectionEntriesList;
        }
        public SquaresDetectionEntriesListResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }
    }
}
