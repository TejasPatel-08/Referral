using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Referral.Models;
//using Referral.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Referral.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<Customers> _userManager;
        private readonly IEmailSender _emailSender;
        //private readonly ISmsSenderService _smsSenderService;

        public ForgotPasswordModel(UserManager<Customers> userManager, IEmailSender emailSender/*, ISmsSenderService smsSenderService*/)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            //_smsSenderService = smsSenderService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "PhoneNumber is required")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            public string PhoneNumber { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == Input.PhoneNumber);
                if (user != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                        ////var callbackUrl = Url.Page(
                        ////    "/Account/ResetPassword",
                        ////    pageHandler: null,
                        ////    values: new { area = "Identity", code },
                        ////    protocol: Request.Scheme);

                        //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Scheme);

                        //var message = $"Please reset your password by clicking here <a href=\"" + HtmlEncoder.Default.Encode(callbackUrl) + "\"></a>.";
                        //await _smsSenderService.SendSmsAsync(Input.PhoneNumber, message);

                        return RedirectToPage("ResetPassword", "Account", new { userId = user.Id, phoneNumber = Input.PhoneNumber, code = code }, Request.Scheme);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "User not found!!!");
                        Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found!!!");
                    Page();
                }
            }

            return Page();
        }
    }
}
