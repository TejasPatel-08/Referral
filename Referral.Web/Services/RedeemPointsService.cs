using Microsoft.Extensions.Configuration;
using Referral.Models;
using Referral.Web.Contract;
using System;
using System.Threading.Tasks;

namespace Referral.Web.Services
{
    public class RedeemPointsService : IRedeemPointsService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;
        public RedeemPointsService(IHttpRestClient httpRestClient, IConfiguration configuration)
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId)
        {
            var result = await _httpRestClient
            .ClearHeaders()
            .GetAsync<RedeemPoints>($"{_apiUrl}/RedeemPoints/RedeemPoints_Get/{CustomerId}");

            return result.Result;
        }

        public async Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId, decimal PurchaseAmount)
        {
            var result = await _httpRestClient
            .ClearHeaders()
            .GetAsync<RedeemPoints>($"{_apiUrl}/RedeemPoints/RedeemPurchase_Get/{CustomerId}/{PurchaseAmount}");

            return result.Result;
        }

        public async Task<bool> RedeemPoints_Post(RedeemPoints redeemPoints)
        {
            var result = await _httpRestClient
              .ClearHeaders()
              .PostAsync<bool, RedeemPoints>($"{_apiUrl}/RedeemPoints/RedeemPoints_Post", redeemPoints);

            return result.Result;
        }

        //public async Task<string> SendOTP(string PhoneNumber)
        //{
        //    Random r = new Random();

        //    string OTP = r.Next(1000, 9999).ToString();
        //    string Message = "Your OTP code is - " + OTP;

        //    var result = await _smsSenderService.SendSmsAsync(PhoneNumber, Message);

        //    if (result.IsCompleted)
        //    {
        //        return OTP;
        //    };

        //    return OTP;
        //}
    }
}
