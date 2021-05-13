using Microsoft.AspNetCore.Identity;
using Referral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class OperatorsRepository
    {
        private readonly UserManager<Customers> _userManager;

        public OperatorsRepository(UserManager<Customers> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Customers>> List()
        {
            var result = await _userManager.GetUsersInRoleAsync("Operators");
            return result.Where(x => x.IsDeleted != true).ToList();
        }

        public async Task<bool> Create_Post(Customers customers)
        {
            customers.UserName = customers.PhoneNumber;
            customers.PhoneNumberConfirmed = true;
            customers.IsActive = true;

            await _userManager.CreateAsync(customers, "Password@123");

            await _userManager.AddToRoleAsync(customers, "Operators");

            return true;
        }

        public async Task<Customers> Update(string userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<bool> Update_Post(Customers customers)
        {
            var oprt = await Update(customers.Id);

            oprt.UserName = customers.PhoneNumber;
            oprt.Email = customers.Email;
            oprt.FirstName = customers.FirstName;
            oprt.LastName = customers.LastName;
            oprt.Address = customers.Address;
            oprt.Area = customers.Area;
            oprt.Dob = customers.Dob;
            oprt.PhoneNumber = customers.PhoneNumber;

            await _userManager.UpdateAsync(oprt);

            return true;
        }

        public async Task<bool> Delete(string userId)
        {
            Customers operators = await Update(userId);
            operators.IsDeleted = true;

            await _userManager.UpdateAsync(operators);

            return true;
        }

        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.IsActive = isActive;

            await _userManager.UpdateAsync(user);

            return true;
        }
    }
}