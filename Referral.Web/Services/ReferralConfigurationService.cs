using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class ReferralConfigurationService : IReferralConfigurationService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public ReferralConfigurationService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<ReferralConfig> GetReferralConfiguration()
        {
            var result = await _httpRestClient
             .ClearHeaders()
             .GetAsync<ReferralConfig>($"{_apiUrl}/ReferralConfiguration/Index");

            return result.Result;
        }

        public async Task<bool> Update_Post(ReferralConfig referralConfig)
        {
            var result = await _httpRestClient
             .ClearHeaders()
             .PostAsync<bool, ReferralConfig>($"{_apiUrl}/ReferralConfiguration/Update_Post", referralConfig);

            return result.Result;
        }
    }
}
