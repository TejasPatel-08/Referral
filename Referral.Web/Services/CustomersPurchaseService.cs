
using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class CustomersPurchaseService : ICustomersPurchaseService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public CustomersPurchaseService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<List<CustomersPurchase>> List()
        {
            var result = await _httpRestClient
              .ClearHeaders()
              .GetAsync<List<CustomersPurchase>>($"{_apiUrl}/CustomersPurchase/List");
            return result.Result;
        }

        public async Task<bool> Create_Post(CustomersPurchaseVM customersPurchaseVM)
        {
            var result = await _httpRestClient
               .ClearHeaders()
               .PostAsync<bool, CustomersPurchaseVM>($"{_apiUrl}/CustomersPurchase/Create_Post", customersPurchaseVM);

            return result.Result;
        }
    }
}
