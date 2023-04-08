using Squares.Application.Dtos;
using Squares.Application.Interfaces;
using Squares.Application.Responses;
using System.Net;

namespace Squares.Api.Presenters
{
    public class SquaresDetectionEntryPresenter : IOutputPort<SquaresDetectionEntryResponse>
    {
        public SquaresDetectionEntryDto SquaresDetectionEntry { get; private set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void Handle(SquaresDetectionEntryResponse response)
        {
            this.ErrorMessage = response.Message;
            this.StatusCode = response.StatusCode;
            this.SquaresDetectionEntry = response.SquaresDetectionEntry;
        }
    }
}
