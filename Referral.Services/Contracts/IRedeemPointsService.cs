using Referral.Models;
using System;
using System.Threading.Tasks;

namespace Referral.Services.Contracts
{
    public interface IRedeemPointsService
    {
        //Task<string> SendOTP(string PhoneNumber);
        Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId);
        Task<bool> RedeemPoints_Post(RedeemPoints redeemPoints);
        Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId, decimal PurchaseAmount);
    }
}
