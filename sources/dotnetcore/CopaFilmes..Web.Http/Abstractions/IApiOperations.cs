using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Web.Http.Abstractions
{
    public interface IApiOperations
    {
        ResponseOperation Get(string endpoint);
        ResponseOperation Get(string endpoint, IDictionary<string, string> headers);
        Task<ResponseOperation> GetAsync(string endpoint);
        Task<ResponseOperation> GetAsync(string endpoint, IDictionary<string, string> headers);
    }
}