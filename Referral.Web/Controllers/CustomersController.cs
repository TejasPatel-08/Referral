using Microsoft.AspNetCore.Mvc;
using Referral.Models;
using Referral.Web.Contract;
using System;
using System.Threading.Tasks;

namespace Referral.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task<IActionResult> List()
        {
            return View(await _customersService.List());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customers customers = new Customers();
            return View(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create_Post(Customers customers)
        {
            await _customersService.Create_Post(customers);
            TempData["AlertMessage"] = "Data has been created successfully";
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            return View(await _customersService.Update(userId.ToString()));
        }

        [HttpPost]
        public async Task<IActionResult> Update_Post(Customers customers)
        {
            await _customersService.Update_Post(customers);
            TempData["AlertMessage"] = "Data has been updated successfully";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public async Task<IActionResult> Activate_User(Guid userId, bool isActive)
        {
            await _customersService.Activate_User(userId, isActive);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await _customersService.Delete(userId.ToString());
            TempData["AlertMessage"] = "Data has been deleted successfully";
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public async Task<JsonResult> Create_Modal(CustomerModal customerModal)
        {
            await _customersService.Create_Modal(customerModal);
            return Json("Success");
        }
    }
}
