using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using Referral.Services.Extension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class CustomersPointsService : ICustomersPointsService
    {
        private readonly CustomersPointsRepository _customersPointsRepository;

        public CustomersPointsService(CustomersPointsRepository customersPointsRepository)
        {
            _customersPointsRepository = customersPointsRepository;
        }

        public async Task<List<CustomersPoints>> List(Guid userId)
        {
            var models = await _customersPointsRepository.List(userId);

            var customersPoints = new List<CustomersPoints>();
            models.ForEach(model => customersPoints.Add(model));

            return customersPoints;
        }

        public async Task<List<CustomersPointsVM>> CustomersPointList()
        {
            var models = await _customersPointsRepository.CustomersPointList();

            var customersPoints = new List<CustomersPointsVM>();
            models.ForEach(model => customersPoints.Add(model));

            return customersPoints;
        }
        
    }
}
