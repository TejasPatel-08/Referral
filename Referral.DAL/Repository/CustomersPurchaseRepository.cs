using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Referral.DAL.Context;
using Referral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class CustomersPurchaseRepository
    {
        private readonly UserManager<Customers> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomersPurchaseRepository(UserManager<Customers> userManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<CustomersPurchase>> List()
        {
            List<string> customers = _userManager.GetUsersInRoleAsync("Customers").Result.Where(c => c.IsDeleted != true).Select(x => x.Id).ToList();

            //convert string list to guid list
            List<Guid> customersIdList = customers.Select(Guid.Parse).ToList();

            var customersPurchaseList = await _applicationDbContext.CustomersPurchase.Where(x => customersIdList.Contains(x.CustomerId)).ToListAsync();

            return customersPurchaseList;
        }

        public async Task<bool> Create_Post(CustomersPurchaseVM customersPurchaseVM)
        {
            var referralConfig = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();
            if (referralConfig == null)
            {
                referralConfig = new ReferralConfig();
            }

            if (customersPurchaseVM.CustomersPurchase.Amount > referralConfig.FMP)
            {
                var redeemAmount = (decimal)Math.Round((referralConfig.PPA.Points * customersPurchaseVM.CustomersPurchase.Amount) / referralConfig.PPA.PurchaseAmount);

                CustomersPoints customersPoints = new CustomersPoints()
                {
                    CustomerId = customersPurchaseVM.CustomersPurchase.CustomerId,
                    PointType = PointType.Purchase,
                    PointEarned = redeemAmount,
                    CreateDate = DateTime.Now
                };

                await _applicationDbContext.CustomersPoints.AddAsync(customersPoints);
                await _applicationDbContext.SaveChangesAsync();
            }

            await _applicationDbContext.AddAsync(customersPurchaseVM.CustomersPurchase);
            await _applicationDbContext.SaveChangesAsync();

            if (customersPurchaseVM.redeemPoints.RedeemAmount > 0)
            {
                var redeemAmount = (decimal)Math.Round(customersPurchaseVM.redeemPoints.RedeemAmount / referralConfig.RedeemPointValue);

                CustomersPoints customersPoints = new CustomersPoints()
                {
                    CustomerId = customersPurchaseVM.redeemPoints.CustomerId,
                    PointType = PointType.Redeem,
                    PointEarned = redeemAmount * -1,
                    CreateDate = DateTime.Now
                };

                await _applicationDbContext.CustomersPoints.AddAsync(customersPoints);
                await _applicationDbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
