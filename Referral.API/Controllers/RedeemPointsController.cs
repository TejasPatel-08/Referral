using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace Referral.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedeemPointsController : ControllerBase
    {
        private readonly IRedeemPointsService _redeemPointsService;

        public RedeemPointsController(IRedeemPointsService redeemPointsService)
        {
            _redeemPointsService = redeemPointsService;
        }

        [HttpGet]
        [Route("RedeemPoints_Get/{CustomerId}")]
        public async Task<RedeemPoints> RedeemPoints_Get(Guid CustomerId)
        {
            RedeemPoints redeemPoints = await _redeemPointsService.RedeemPoints_Get(CustomerId);
            return redeemPoints;
        }

        [HttpGet]
        [Route("RedeemPurchase_Get/{CustomerId}/{PurchaseAmount}")]
        public async Task<RedeemPoints> RedeemPurchase_Get(Guid CustomerId, decimal PurchaseAmount)
        {
            RedeemPoints redeemPoints = await _redeemPointsService.RedeemPurchase_Get(CustomerId, PurchaseAmount);
            return redeemPoints;
        }

        [HttpPost]
        [Route("RedeemPoints_Post")]
        public async Task<bool> RedeemPoints_Post(RedeemPoints redeemPoints)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _redeemPointsService.RedeemPoints_Post(redeemPoints);
            }
            return result;
        }

    }
}
