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
    public class CustomersPointsController : ControllerBase
    {
        private readonly ICustomersPointsService _customersPointsService;

        public CustomersPointsController(ICustomersPointsService customersPointsService)
        {
            _customersPointsService = customersPointsService;
        }

        [HttpGet]
        [Route("List/{userId}")]

        public async Task<List<CustomersPoints>> List(Guid userId)
        {
            return await _customersPointsService.List(userId);
        }

        [HttpGet]
        [Route("CustomersPointList")]
        public async Task<List<CustomersPointsVM>> CustomersPointList()
        {
            return await _customersPointsService.CustomersPointList();
        }
    }
}
