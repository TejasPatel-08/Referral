using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Web.Contract;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<Customers> CustomerByPhone_Get(string PhoneNumber)
        {
            return await _commonService.CustomerByPhone_Get(PhoneNumber);
        }

        [HttpGet]
        public async Task<JsonResult> PhoneList_Get(string Prefix)
        {
            var data = await _commonService.PhoneList_Get(Prefix);
            return Json(data);
        }

        [HttpGet]
        public async Task<bool> Check_PhoneNumber(string PhoneNumber)
        {
            var result = await _commonService.Check_PhoneNumber(PhoneNumber);
            return result;
        }
    }
}
