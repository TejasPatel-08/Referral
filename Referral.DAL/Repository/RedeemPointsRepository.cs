using Microsoft.EntityFrameworkCore;
using Referral.DAL.Context;
using Referral.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class RedeemPointsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //private readonly ISmsSenderService _smsSenderService;

        public RedeemPointsRepository(ApplicationDbContext applicationDbContext/*, ISmsSenderService smsSenderService*/)
        {
            _applicationDbContext = applicationDbContext;
            //_smsSenderService = smsSenderService;
        }

        public async Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId)
        {
            var referralConfig = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();

            var customersTotalPoints = _applicationDbContext.CustomersPoints.Where(y => y.CustomerId == CustomerId).Select(p => p.PointEarned).Sum();

            var maxRedeemPoint = (int)Math.Round((referralConfig.RedeemPointPercentage * customersTotalPoints) / 100);

            var redeemAmount = maxRedeemPoint * referralConfig.RedeemPointValue;

            RedeemPoints redeemPoints = new RedeemPoints
            {
                TotalPoint = customersTotalPoints,
                MaxRedeemPoint = maxRedeemPoint,
                RedeemAmount = redeemAmount
            };

            return redeemPoints;
        }

        public async Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId, decimal PurchaseAmount)
        {
            RedeemPoints redeemPoints = new RedeemPoints();
            var referralConfig = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();
            if (referralConfig == null)
            {
                referralConfig = new ReferralConfig();
            }
            if (PurchaseAmount > referralConfig.FMP)
            {
                var purchasePoints = (decimal)Math.Round((referralConfig.PPA.Points * PurchaseAmount) / referralConfig.PPA.PurchaseAmount);

                var customersTotalPoints = _applicationDbContext.CustomersPoints.Where(y => y.CustomerId == CustomerId).Select(p => p.PointEarned).Sum() + purchasePoints;

                var maxRedeemPoint = (int)Math.Round((referralConfig.RedeemPointPercentage * customersTotalPoints) / 100);

                var redeemAmount = maxRedeemPoint * referralConfig.RedeemPointValue;

                redeemPoints = new RedeemPoints
                {
                    PurchaseEarnedPoints = purchasePoints,
                    TotalPoint = customersTotalPoints,
                    MaxRedeemPoint = maxRedeemPoint,
                    RedeemAmount = redeemAmount
                };
            }
            else
            {
                var customersTotalPoints = _applicationDbContext.CustomersPoints.Where(y => y.CustomerId == CustomerId).Select(p => p.PointEarned).Sum();

                var maxRedeemPoint = (int)Math.Round((referralConfig.RedeemPointPercentage * customersTotalPoints) / 100);

                var redeemAmount = maxRedeemPoint * referralConfig.RedeemPointValue;

                redeemPoints = new RedeemPoints
                {
                    PurchaseEarnedPoints = 0,
                    TotalPoint = customersTotalPoints,
                    MaxRedeemPoint = maxRedeemPoint,
                    RedeemAmount = redeemAmount
                };
            }

            return redeemPoints;
        }

        public async Task<bool> RedeemPoints_Post(RedeemPoints redeemPoints)
        {
            var referralConfig = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();

            var redeemAmount = (decimal)Math.Round(redeemPoints.RedeemAmount / referralConfig.RedeemPointValue);

            CustomersPoints customersPoints = new CustomersPoints()
            {
                CustomerId = redeemPoints.CustomerId,
                PointType = PointType.Redeem,
                PointEarned = redeemAmount * -1,
                CreateDate = DateTime.Now
            };

            await _applicationDbContext.CustomersPoints.AddAsync(customersPoints);
            await _applicationDbContext.SaveChangesAsync();

            return true;
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