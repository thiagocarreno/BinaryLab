using System;
using System.Net;

namespace CopaFilmes.Web.Http
{
    public class ResponseOperation
    {
        public bool Sucesso => ((int)StatusCode >= 200) && ((int)StatusCode <= 299);
        public string Endpoint { get; }
        public string RequestBody { get; }
        public string ResponseBody { get; }
        public HttpStatusCode StatusCode { get; }
        public DateTime DataResponse { get; }
        public Exception Erro { get; }

        public ResponseOperation(string request, string response, string endpoint, HttpStatusCode statusCode)
        {
            RequestBody = request;
            ResponseBody = response;
            Endpoint = endpoint;
            StatusCode = statusCode;
            DataResponse = DateTime.Now;
        }

        public ResponseOperation(string endpoint, string request, Exception exception)
        {
            Endpoint = endpoint;
            RequestBody = request;
            Erro = exception;
            DataResponse = DateTime.Now;
        }
    }
}