using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Referral.Models;
//using Referral.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<Customers> _userManager;
        //private readonly ISmsSenderService _smsSenderService;

        public RegisterConfirmationModel(UserManager<Customers> userManager/*, ISmsSenderService smsSenderService*/)
        {
            _userManager = userManager;
            // _smsSenderService = smsSenderService;
        }

        public string PhoneNumber { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IActionResult> OnGetAsync(string phonenumber, string returnUrl = null)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            if (phonenumber == null)
            {
                return RedirectToPage("/Index");
            }

            var user = _userManager.Users.ToList().SingleOrDefault(x => x.PhoneNumber == phonenumber);

            PhoneNumber = phonenumber;

            if (user == null)
            {
                return NotFound($"Unable to load user with phonenumber '{phonenumber}'.");
            }
            //else
            //{
            //    PhoneNumber = phonenumber;
            //    var userId = await _userManager.GetUserIdAsync(user);

            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //    var callbackUrl = Url.Page(
            //           "/Account/ConfirmPhoneNumber",
            //           pageHandler: null,
            //           values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
            //           protocol: Request.Scheme);

            //    var message = $"Please confirm your PhoneNumber by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
            //    await _smsSenderService.SendSmsAsync(PhoneNumber, message);
            //}
            return Page();
        }
    }
}
