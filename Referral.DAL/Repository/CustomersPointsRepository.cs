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
    public class CustomersPointsRepository
    {
        private readonly UserManager<Customers> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomersPointsRepository(UserManager<Customers> userManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<CustomersPoints>> List(Guid userId)
        {
            List<string> customers = _userManager.GetUsersInRoleAsync("Customers").Result.Where(c => c.IsDeleted != true && c.Id == userId.ToString()).Select(x => x.Id).ToList();

            //convert string list to guid list
            List<Guid> customerIdList = customers.Select(Guid.Parse).ToList();

            return await _applicationDbContext.CustomersPoints.Where(x => customerIdList.Contains(x.CustomerId)).ToListAsync();
        }

        public async Task<List<CustomersPointsVM>> CustomersPointList()
        {
            List<CustomersPointsVM> customersPointsVMs = new List<CustomersPointsVM>();

            var lst = await _applicationDbContext.CustomersPoints.Select(x => x.CustomerId).Distinct().ToListAsync();
            foreach (var item in lst)
            {
                CustomersPointsVM customersPointsVMs1 = new CustomersPointsVM
                {
                    CustomerId = item,
                    RedeemPoint = await _applicationDbContext.CustomersPoints.Where(x => x.PointType == PointType.Redeem && x.CustomerId == item).SumAsync(x => x.PointEarned),
                    PurchasePoints = await _applicationDbContext.CustomersPoints.Where(x => x.PointType == PointType.Purchase && x.CustomerId == item).SumAsync(x => x.PointEarned),
                    ReferralPoints = await _applicationDbContext.CustomersPoints.Where(x => x.PointType == PointType.Referral && x.CustomerId == item).SumAsync(x => x.PointEarned),
                    TotalPoints = await _applicationDbContext.CustomersPoints.Where(x => x.CustomerId == item).SumAsync(x => x.PointEarned)
                };

                customersPointsVMs.Add(customersPointsVMs1);
            }

            return customersPointsVMs;
        }
    }
}
