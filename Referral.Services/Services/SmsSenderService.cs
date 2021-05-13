//using Microsoft.Extensions.Options;
//using Referral.Models;
//using Referral.Services.Contracts;
//using System.Threading.Tasks;

//namespace Referral.Services.Services
//{
//    public class SmsSenderService : ISmsSenderService
//    {
//        private readonly TwilioOptions _twilioOptions;
//        private readonly BulkSmsOptions _bulkSmsOptions;
//        private FunctionalService _functionalService { get; }

//        public SmsSenderService(IOptions<TwilioOptions> twilioOptions, IOptions<BulkSmsOptions> bulkSmsOptions, FunctionalService functionalService)
//        {
//            _twilioOptions = twilioOptions.Value;
//            _bulkSmsOptions = bulkSmsOptions.Value;
//            _functionalService = functionalService;
//        }

//        public async Task<Task> SendSmsAsync(string number, string message)
//        {
//            if (_twilioOptions.IsDefault)
//            {
//                await _functionalService.SendSmsByTwillioAsync(_twilioOptions.Sid, _twilioOptions.Token, _twilioOptions.From, message, number);
//            }
//            if (_bulkSmsOptions.IsDefault)
//            {
//                await _functionalService.SendSmsByBulkSmsAsync(_bulkSmsOptions.User, _bulkSmsOptions.Password, _bulkSmsOptions.Sender, _bulkSmsOptions.Type, _bulkSmsOptions.Url, message, number);
//            }
//            return Task.CompletedTask;
//        }
//    }
//}


