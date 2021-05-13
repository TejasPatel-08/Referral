using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Referral.DAL.Context;
using Referral.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class CommonRepository
    {
        private readonly UserManager<Customers> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public CommonRepository(UserManager<Customers> userManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<string>> PhoneList_Get(string Prefix)
        {
            var result = await _userManager.GetUsersInRoleAsync("Customers");
            List<string> PhoneNumberList = result.Where(x => x.IsDeleted != true && x.PhoneNumber.StartsWith(Prefix)).Select(y => y.PhoneNumber).ToList();
            return PhoneNumberList;
        }

        public async Task<Customers> CustomerByPhone_Get(string PhoneNumber)
        {
            var result = await _userManager.GetUsersInRoleAsync("Customers");
            Customers customers = result.SingleOrDefault(x => x.PhoneNumber == PhoneNumber && x.IsDeleted != true);

            if (customers == null)
            {
                return null;
            }
            return customers;
        }

        public async Task<bool> Check_PhoneNumber(string phoneNumber)
        {
            var result = await _applicationDbContext.Users.AnyAsync(x => x.PhoneNumber == phoneNumber);
            return result;
        }
    }
}
