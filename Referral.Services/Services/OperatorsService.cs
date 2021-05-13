using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class OperatorsService : IOperatorsService
    {
        private readonly OperatorsRepository _operatorsRepository;

        public OperatorsService(OperatorsRepository operatorsRepository)
        {
            _operatorsRepository = operatorsRepository;
        }

        public async Task<List<Customers>> List()
        {
            var models = await _operatorsRepository.List();

            var customers = new List<Customers>();
            models.ForEach(model => customers.Add(model));
            return customers;
        }

        public async Task<bool> Create_Post(Customers customers)
        {
            return await _operatorsRepository.Create_Post(customers);
        }

        public async Task<Customers> Update(string userId)
        {
            var models = await _operatorsRepository.Update(userId);
            return models;
        }

        public async Task<bool> Update_Post(Customers customers)
        {
            return await _operatorsRepository.Update_Post(customers);
        }

        public async Task<bool> Delete(string userId)
        {
            return await _operatorsRepository.Delete(userId);
        }

        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            return await _operatorsRepository.Activate_User(userId, isActive);
        }
    }
}