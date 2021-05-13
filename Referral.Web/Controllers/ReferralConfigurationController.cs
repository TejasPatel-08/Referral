using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Web.Contract;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class ReferralConfigurationController : Controller
    {
        private readonly IReferralConfigurationService _referralConfigurationService;

        public ReferralConfigurationController(IReferralConfigurationService referralConfigurationService)
        {
            _referralConfigurationService = referralConfigurationService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _referralConfigurationService.GetReferralConfiguration());
        }

        [HttpPost]
        public async Task<IActionResult> Update_Post(ReferralConfig referralConfig)
        {
            await _referralConfigurationService.Update_Post(referralConfig);
            TempData["AlertMessage"] = "Data has been updated successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
