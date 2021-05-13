using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using Referral.Services.Extension;
using System;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class RedeemPointsService : IRedeemPointsService
    {
        private readonly RedeemPointsRepository _redeemPointsRepository;
        //private readonly ISmsSenderService _smsSenderService;

        public RedeemPointsService(RedeemPointsRepository redeemPointsRepository/*, ISmsSenderService smsSenderService*/)
        {
            _redeemPointsRepository = redeemPointsRepository;
            //_smsSenderService = smsSenderService;
        }

        public async Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId)
        {
            var models = await _redeemPointsRepository.RedeemPoints_Get(CustomerId);
            return models;
        }

        public async Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId,decimal PurchaseAmount)
        {
            var models = await _redeemPointsRepository.RedeemPurchase_Get(CustomerId, PurchaseAmount);
            return models;
        }

        public async Task<bool> RedeemPoints_Post(RedeemPoints redeemPoints)
        {
            return await _redeemPointsRepository.RedeemPoints_Post(redeemPoints);
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
