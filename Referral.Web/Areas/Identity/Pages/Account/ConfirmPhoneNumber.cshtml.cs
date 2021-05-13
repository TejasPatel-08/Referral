using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Referral.Models;
using System.Threading.Tasks;

namespace Referral.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmPhoneNumberModel : PageModel
    {
        private readonly UserManager<Customers> _userManager;

        public ConfirmPhoneNumberModel(UserManager<Customers> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var identityUser = await _userManager.FindByIdAsync(userId);
            identityUser.PhoneNumberConfirmed = true;
            var result = await _userManager.UpdateAsync(identityUser);

            StatusMessage = result.Succeeded ? "Thank you for confirming your phonenumber." : "Error confirming your phonenumber.";
            return Page();
        }
    }
}
