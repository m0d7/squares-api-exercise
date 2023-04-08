using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Interfaces
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        string ErrorMessage { get; set; }
        HttpStatusCode StatusCode { get; set; }
        void Handle(TUseCaseResponse response);
    }
}
