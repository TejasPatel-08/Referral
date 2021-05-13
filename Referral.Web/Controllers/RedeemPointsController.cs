using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Web.Contract;
using System;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class RedeemPointsController : Controller
    {
        private readonly IRedeemPointsService _redeemPointsService;

        public RedeemPointsController(IRedeemPointsService redeemPointsService)
        {
            _redeemPointsService = redeemPointsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool SendOTP(string PhoneNumber)
        {
            TempData["OTPValue"] = 123;
            //TempData["OTPValue"] = await _redeemPointsService.SendOTP(PhoneNumber);
            return true;
        }

        [HttpPost]
        public bool VerifyOTP(string OTP)
        {
            string temp = TempData["OTPValue"].ToString();
            TempData.Keep("OTPValue");
            if (temp == OTP)
                return true;
            else
                return false;
        }

        [HttpPost]
        public async Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId)
        {
            RedeemPoints redeemPoints = await _redeemPointsService.RedeemPoints_Get(CustomerId);
            return redeemPoints;
        }

        [HttpPost]
        public async Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId, decimal PurchaseAmount)
        {
            RedeemPoints redeemPoints = await _redeemPointsService.RedeemPurchase_Get(CustomerId, PurchaseAmount);
            return redeemPoints;
        }

        [HttpPost]
        public async Task<IActionResult> RedeemPoints_Post(RedeemPoints redeemPoints)
        {
            await _redeemPointsService.RedeemPoints_Post(redeemPoints);
            TempData["AlertMessage"] = "Redeem points successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
