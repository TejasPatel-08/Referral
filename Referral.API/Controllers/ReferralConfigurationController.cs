using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferralConfigurationController : ControllerBase
    {
        private readonly IReferralConfigurationService _referralConfigurationService;

        public ReferralConfigurationController(IReferralConfigurationService referralConfigurationService)
        {
            _referralConfigurationService = referralConfigurationService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<ReferralConfig> Index()
        {
            return await _referralConfigurationService.GetReferralConfiguration();
        }


        [HttpPost]
        [Route("Update_Post")]
        public async Task<bool> Update_Post(ReferralConfig referralConfig)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _referralConfigurationService.Update_Post(referralConfig);
            }
            return result;
        }
    }
}
