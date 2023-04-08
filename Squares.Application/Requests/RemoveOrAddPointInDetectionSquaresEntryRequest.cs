using Squares.Application.Dtos;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Requests
{
    public class RemoveOrAddPointInDetectionSquaresEntryRequest : IUseCaseRequest<SquaresDetectionEntryResponse>
    {
        public string EntryId { get; }
        public PointDto Point { get; }
        public RemoveOrAddPointInDetectionSquaresEntryRequest(string entryId, PointDto point)
        {
            EntryId = entryId;
            Point = point;
        }
    }
}
