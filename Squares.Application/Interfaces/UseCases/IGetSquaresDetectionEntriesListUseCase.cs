using Squares.Application.Requests;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Interfaces.UseCases
{
    public interface IGetSquaresDetectionEntriesListUseCase : IUseCaseRequestHandler<GetISquaresDetectionEntriesListRequest, SquaresDetectionEntriesListResponse>
    {
    }
}
