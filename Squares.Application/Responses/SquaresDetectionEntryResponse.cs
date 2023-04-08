using Squares.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Responses
{
    public class SquaresDetectionEntryResponse : UseCaseResponseMessage
    {
        public SquaresDetectionEntryDto SquaresDetectionEntry { get; }
        public SquaresDetectionEntryResponse(SquaresDetectionEntryDto squaresDetectionEntry) : base(default, default)
        {
            this.SquaresDetectionEntry = squaresDetectionEntry;
        }
        public SquaresDetectionEntryResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }
    }
}
