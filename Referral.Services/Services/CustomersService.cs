using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly CustomersRepository _customersRepository;

        public CustomersService(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<List<Customers>> List()
        {
            var models = await _customersRepository.List();

            var customers = new List<Customers>();
            models.ForEach(model => customers.Add(model));
            return customers;
        }

        public async Task<bool> Create_Post(Customers customers)
        {
            return await _customersRepository.Create_Post(customers);
        }

        public async Task<Customers> Update(string userId)
        {
            var model = await _customersRepository.Update(userId);
            return model;
        }

        public async Task<bool> Update_Post(Customers customers)
        {
            return await _customersRepository.Update_Post(customers);
        }

        public async Task<bool> Delete(string userId)
        {
            return await _customersRepository.Delete(userId);
        }

        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            return await _customersRepository.Activate_User(userId, isActive);
        }

        public async Task<bool> Create_Modal(CustomerModal customerModal)
        {
            return await _customersRepository.Create_Modal(customerModal);
        }
    }
}
