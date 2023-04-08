using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Responses
{
    public abstract class UseCaseResponseMessage
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public string Message { get; }  

        protected UseCaseResponseMessage(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
