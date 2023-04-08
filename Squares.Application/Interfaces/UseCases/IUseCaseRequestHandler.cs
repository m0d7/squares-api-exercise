using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Interfaces.UseCases
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse>
    {
        bool Handle(TUseCaseRequest request, IOutputPort<TUseCaseResponse> outputPort);
    }
}
