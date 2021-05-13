using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Web.Contract;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class CustomersPurchaseController : Controller
    {
        private readonly ICustomersPurchaseService _customersPurchaseService;

        public CustomersPurchaseController(ICustomersPurchaseService customersPurchaseService)
        {
            _customersPurchaseService = customersPurchaseService;
        }

        public async Task<IActionResult> List()
        {
            return View(await _customersPurchaseService.List());
        }

        [HttpGet]
        public IActionResult Create(CustomersPurchaseVM customersPurchaseVM)
        {
            return View(customersPurchaseVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create_Post(CustomersPurchaseVM customersPurchaseVM)
        {
            await _customersPurchaseService.Create_Post(customersPurchaseVM);
            TempData["AlertMessage"] = "Data has been created successfully";
            return RedirectToAction(nameof(List));
        }
    }
}
