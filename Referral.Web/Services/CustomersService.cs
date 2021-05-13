using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public CustomersService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<List<Customers>> List()
        {
            var result = await _httpRestClient
              .ClearHeaders()
              .GetAsync<List<Customers>>($"{_apiUrl}/Customers/List");

            return result.Result;
        }

        public async Task<bool> Create_Post(Customers customers)
        {
            var result = await _httpRestClient
              .ClearHeaders()
              .PostAsync<bool, Customers>($"{_apiUrl}/Customers/Create_Post", customers);

            return result.Result;
        }

        public async Task<Customers> Update(string userId)
        {
            var result = await _httpRestClient
            .ClearHeaders()
            .GetAsync<Customers>($"{_apiUrl}/Customers/Update/{userId}");

            return result.Result;
        }

        public async Task<bool> Update_Post(Customers customers)
        {
            var result = await _httpRestClient
               .ClearHeaders()
               .PostAsync<bool, Customers>($"{_apiUrl}/Customers/Update_Post", customers);

            return result.Result;
        }

        public async Task<bool> Delete(string userId)
        {
            var result = await _httpRestClient
                 .ClearHeaders()
                 .DeleteAsync($"{_apiUrl}/Customers/Delete", userId);

            return result.Result;
        }

        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            var result = await _httpRestClient
             .ClearHeaders()
             .GetAsync<bool>($"{_apiUrl}/Customers/Activate_User/{userId}/{isActive}");

            return result.Result;
        }

        public async Task<bool> Create_Modal(CustomerModal customerModal)
        {
            var result = await _httpRestClient
               .ClearHeaders()
               .PostAsync<bool, CustomerModal>($"{_apiUrl}/Customers/Create_Modal", customerModal);

            return result.Result;
        }
    }
}
