using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersPurchaseController : ControllerBase
    {
        private readonly ICustomersPurchaseService _customersPurchaseService;

        public CustomersPurchaseController(ICustomersPurchaseService customersPurchaseService)
        {
            _customersPurchaseService = customersPurchaseService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<CustomersPurchase>> List()
        {
            return await _customersPurchaseService.List();
        }


        [HttpPost]
        [Route("Create_Post")]
        public async Task<bool> Create_Post(CustomersPurchaseVM customersPurchaseVM)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _customersPurchaseService.Create_Post(customersPurchaseVM);
            }
            return result;
        }
    }
}
