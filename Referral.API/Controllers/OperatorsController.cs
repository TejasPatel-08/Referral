using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorsController : ControllerBase
    {
        private readonly IOperatorsService _operatorsService;
        public OperatorsController(IOperatorsService operatorsService)
        {
            _operatorsService = operatorsService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<Customers>> List()
        {
            return await _operatorsService.List();
        }

        [HttpPost]
        [Route("Create_Post")]
        public async Task<bool> Create_Post(Customers customers)
        {
            return await _operatorsService.Create_Post(customers);
        }

        [HttpGet]
        [Route("Update/{userId}")]
        public async Task<Customers> Update(Guid userId)
        {
            return await _operatorsService.Update(userId.ToString());
        }

        [HttpPost]
        [Route("Update_Post")]
        public async Task<bool> Update_Post(Customers customers)
        {
            return await _operatorsService.Update_Post(customers);
        }

        [HttpGet]
        [Route("Activate_User/{userId}/{isActive}")]
        public async Task<bool> Activate_User(Guid userId, bool isActive)
        {
            return await _operatorsService.Activate_User(userId, isActive);
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<bool> Delete(Guid userId)
        {
            return await _operatorsService.Delete(userId.ToString());
        }
    }
}
