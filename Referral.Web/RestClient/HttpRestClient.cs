using System.Net.Http;
using System.Threading.Tasks;

namespace Referral.RestClient
{
    using Newtonsoft.Json;
    using Referral.Web.Contract;
    using System.Net.Http.Headers;
    using System.Text;

    public class HttpRestClient : IHttpRestClient
    {
        public readonly string ContentType = "application/json";

        private readonly HttpClient _httpClient;
        public HttpRestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IHttpRestClient ClearHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            return this;
        }

        public IHttpRestClient AddHeaders(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        public async Task<HttpResult<T>> GetAsync<T>(string url) where T : new()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            T result = default(T);
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            _httpClient.DefaultRequestHeaders.Clear();
            return HttpResult<T>.SetResult(result);
        }

        public async Task<HttpResult<T>> PostAsync<T, R>(string url, R content) where T : new()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            T result = default(T);
            var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, ContentType);

            HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            _httpClient.DefaultRequestHeaders.Clear();
            return HttpResult<T>.SetResult(result);
        }


        public async Task<HttpResult<bool>> DeleteAsync(string url, string id)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            bool result = false;

            HttpResponseMessage response = await _httpClient.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }

            _httpClient.DefaultRequestHeaders.Clear();
            return HttpResult<bool>.SetResult(result);
        }


    }
}