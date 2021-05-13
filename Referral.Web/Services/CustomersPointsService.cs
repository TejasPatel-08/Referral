using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class CustomersPointsService : ICustomersPointsService
    {

        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public CustomersPointsService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<List<CustomersPoints>> List(Guid userId)
        {
            var result = await _httpRestClient
               .ClearHeaders()
               .GetAsync<List<CustomersPoints>>($"{_apiUrl}/CustomersPoints/List/{userId}");
            return result.Result;
        }

        public async Task<List<CustomersPointsVM>> CustomersPointList()
        {
            var result = await _httpRestClient
               .ClearHeaders()
               .GetAsync<List<CustomersPointsVM>>($"{_apiUrl}/CustomersPoints/CustomersPointList");
            return result.Result;
        }        
    }
}
