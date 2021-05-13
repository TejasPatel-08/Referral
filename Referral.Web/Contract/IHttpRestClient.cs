using Referral.RestClient;
using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface IHttpRestClient
    {
        IHttpRestClient ClearHeaders();

        IHttpRestClient AddHeaders(string name, string value);

        Task<HttpResult<T>> GetAsync<T>(string url) where T : new();

        Task<HttpResult<T>> PostAsync<T, R>(string url, R content) where T : new();

        Task<HttpResult<bool>> DeleteAsync(string url, string id);
    }
}
