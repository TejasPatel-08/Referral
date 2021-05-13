//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Options;
//using Referral.Models;
//using System.Threading.Tasks;


//namespace Referral.Services.Services
//{
//    public class EmailSenderService : IEmailSender
//    {
//        private SendGridOptions SendGridOptions { get; }
//        private FunctionalService FunctionalService { get; }
//        private SmtpOptions SmtpOptions { get; }

//        public EmailSenderService(IOptions<SendGridOptions> sendGridOptions, FunctionalService functionalService, IOptions<SmtpOptions> smtpOptions)
//        {
//            SendGridOptions = sendGridOptions.Value;
//            FunctionalService = functionalService;
//            SmtpOptions = smtpOptions.Value;
//        }

//        public Task SendEmailAsync(string email, string subject, string message)
//        {
//            //sendgrid is become default
//            if (SendGridOptions.IsDefault)
//            {
//                FunctionalService.SendEmailBySendGridAsync(SendGridOptions.SendGridKey, SendGridOptions.FromEmail, SendGridOptions.FromFullName, subject, message, email).Wait();
//            }

//            //smtp is become default
//            if (SmtpOptions.IsDefault)
//            {
//                FunctionalService.SendEmailByGmailAsync(SmtpOptions.FromEmail, SmtpOptions.FromFullName, subject, message, email, email, SmtpOptions.SmtpUserName, SmtpOptions.SmtpPassword, SmtpOptions.SmtpHost, SmtpOptions.SmtpPort, SmtpOptions.SmtpSSL).Wait();
//            }
//            return Task.CompletedTask;
//        }
//    }
//}
