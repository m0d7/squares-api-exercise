using Squares.Application.Dtos;
using Squares.Application.Interfaces;
using Squares.Application.Responses;
using System.Net;

namespace Squares.Api.Presenters
{
    public class SquaresDetectionEntriesListPresenter : IOutputPort<SquaresDetectionEntriesListResponse>
    {
        public IList<SquaresDetectionEntryDto> SquaresDetectionEntriesList { get; private set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void Handle(SquaresDetectionEntriesListResponse response)
        {
            this.ErrorMessage = response.Message;
            this.StatusCode = response.StatusCode;
            this.SquaresDetectionEntriesList = response.SquaresDetectionEntriesList;
        }
    }
}
