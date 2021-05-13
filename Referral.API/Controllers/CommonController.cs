using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        [Route("CustomerByPhone_Get/{PhoneNumber}")]
        public async Task<Customers> CustomerByPhone_Get(string PhoneNumber)
        {
            return await _commonService.CustomerByPhone_Get(PhoneNumber);
        }

        [HttpGet]
        [Route("PhoneList_Get/{Prefix}")]
        public async Task<List<string>> PhoneList_Get(string Prefix)
        {
            return await _commonService.PhoneList_Get(Prefix);
        }

        [HttpGet]
        [Route("Check_PhoneNumber/{PhoneNumber}")]
        public async Task<bool> Check_PhoneNumber(string PhoneNumber)
        {
            var result = await _commonService.Check_PhoneNumber(PhoneNumber);
            return result;
        }
    }
}
