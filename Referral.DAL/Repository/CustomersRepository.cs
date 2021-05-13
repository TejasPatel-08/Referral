using Microsoft.AspNetCore.Identity;
using Referral.DAL.Context;
using Referral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class CustomersRepository
    {
        private readonly UserManager<Customers> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomersRepository(UserManager<Customers> userManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Customers>> List()
        {
            var result = await _userManager.GetUsersInRoleAsync("Customers");
            return result.Where(x => x.IsDeleted != true).ToList();
        }

        public async Task<bool> Create_Post(Customers customers)
        {
            customers.UserName = customers.PhoneNumber;
            customers.PhoneNumberConfirmed = true;
            customers.IsActive = true;
            customers.CreatedDate = DateTime.Now;

            await _userManager.CreateAsync(customers, "Password@123");

            if (customers.ReferralId != null)
            {
                CustomersPoints customersPoints = new CustomersPoints()
                {
                    CustomerId = Guid.Parse(customers.ReferralId),
                    PointType = PointType.Referral,
                    PointEarned = _applicationDbContext.ReferralConfig.SingleOrDefault().ReferralPoints,
                    CreateDate = DateTime.Now
                };
                await _applicationDbContext.CustomersPoints.AddAsync(customersPoints);
            }
            await _userManager.AddToRoleAsync(customers, "Customers");

            return true;
        }

        public async Task<Customers> Update(string userId)
        {
            var customers = await _userManager.FindByIdAsync(userId.ToString());

            if (customers == null || customers.IsDeleted)
            {
                return null;
            }

            return customers;
        }

        public async Task<bool> Update_Post(Customers customers)
        {
            var cst = await Update(customers.Id);

            cst.UserName = customers.PhoneNumber;
            cst.Email = customers.Email;
            cst.FirstName = customers.FirstName;
            cst.LastName = customers.LastName;
            cst.Address = customers.Address;
            cst.Area = customers.Area;
            cst.City = customers.City;
            cst.Dob = customers.Dob;
            cst.PhoneNumber = customers.PhoneNumber;

            await _userManager.UpdateAsync(cst);

            return true;
        }

        public async Task<bool> Delete(string userId)
        {
            Customers customers = await Update(userId);
            customers.IsDeleted = true;

            await _userManager.UpdateAsync(customers);

            return true;
        }

        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.IsActive = isActive;

            await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<bool> Create_Modal(CustomerModal customerModal)
        {
            Customers customers = new Customers
            {
                UserName = customerModal.CustomerModalPhoneNumber,
                PhoneNumberConfirmed = true,
                IsActive = true,
                Area = customerModal.CustomerModalArea,
                FirstName = customerModal.CustomerModalFirstName,
                LastName = customerModal.CustomerModalLastName,
                PhoneNumber = customerModal.CustomerModalPhoneNumber,
                Dob = DateTime.Now
            };

            await _userManager.CreateAsync(customers, "Password@123");

            await _userManager.AddToRoleAsync(customers, "Customers");

            return true;
        }
    }
}

