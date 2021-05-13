using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class CustomersPurchaseService : ICustomersPurchaseService
    {
        private readonly CustomersPurchaseRepository _customersPurchaseRepository;

        public CustomersPurchaseService(CustomersPurchaseRepository customersPurchaseRepository)
        {
            _customersPurchaseRepository = customersPurchaseRepository;
        }

        public async Task<List<CustomersPurchase>> List()
        {
            var models = await _customersPurchaseRepository.List();

            var customersPurchases = new List<CustomersPurchase>();
            models.ForEach(model => customersPurchases.Add(model));
            return customersPurchases;
        }

        public async Task<bool> Create_Post(CustomersPurchaseVM customersPurchaseVM)
        {
            return await _customersPurchaseRepository.Create_Post(customersPurchaseVM);
        }
    }
}
