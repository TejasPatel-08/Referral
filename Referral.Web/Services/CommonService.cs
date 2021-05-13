using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class CommonService : ICommonService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public CommonService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<List<string>> PhoneList_Get(string Prefix)
        {
            var result = await _httpRestClient
             .ClearHeaders()
             .GetAsync<List<string>>($"{_apiUrl}/Common/PhoneList_Get/{Prefix}");

            return result.Result;
        }

        public async Task<Customers> CustomerByPhone_Get(string PhoneNumber)
        {
            var result = await _httpRestClient
             .ClearHeaders()
             .GetAsync<Customers>($"{_apiUrl}/Common/CustomerByPhone_Get/{PhoneNumber}");

            return result.Result;
        }

        public async Task<bool> Check_PhoneNumber(string PhoneNumber)
        {
            var result = await _httpRestClient
            .ClearHeaders()
            .GetAsync<bool>($"{_apiUrl}/Common/Check_PhoneNumber/{PhoneNumber}");

            return result.Result;
        }
    }
}
