using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<Customers>> List()
        {
            return await _customersService.List();
        }

        [HttpPost]
        [Route("Create_Post")]
        public async Task<bool> Create_Post(Customers customers)
        {
            return await _customersService.Create_Post(customers);
        }

        [HttpGet]
        [Route("Update/{userId}")]
        public async Task<Customers> Update(Guid userId)
        {
            return await _customersService.Update(userId.ToString());
        }

        [HttpPost]
        [Route("Update_Post")]
        public async Task<bool> Update_Post(Customers customers)
        {
            return await _customersService.Update_Post(customers);
        }

        [HttpGet]
        [Route("Activate_User/{userId}/{isActive}")]
        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            return await _customersService.Activate_User(userId, isActive);
        }

        [HttpDelete]
        [Route("Delete/{userId}")]
        public async Task<bool> Delete(Guid userId)
        {
            return await _customersService.Delete(userId.ToString());
        }

        [HttpPost]
        [Route("Create_Modal")]
        public async Task<bool> Create_Modal(CustomerModal customerModal)
        {
            return await _customersService.Create_Modal(customerModal);
        }
    }
}
