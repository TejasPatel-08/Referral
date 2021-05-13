using Microsoft.AspNetCore.Mvc;
using Referral.Web.Contract;
using System;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class CustomersPointsController : Controller
    {
        private readonly ICustomersPointsService _customersPointsService;

        public CustomersPointsController(ICustomersPointsService customersPointsService)
        {
            _customersPointsService = customersPointsService;
        }

        public async Task<IActionResult> List(Guid userId)
        {
            return View(await _customersPointsService.List(userId));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _customersPointsService.CustomersPointList());
        }
    }
}
