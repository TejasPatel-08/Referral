using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Referral.RestClient;
using Referral.Web.Contract;
using Referral.Web.Services;
using System.Net.Http;

namespace Referral.Web.Extension
{
    public static class WebExtension
    {
        public static IServiceCollection BindingAppServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<IOperatorsService, OperatorsService>();
            services.AddTransient<ICustomersPurchaseService, CustomersPurchaseService>();
            services.AddTransient<ICustomersPointsService, CustomersPointsService>();
            services.AddTransient<IRedeemPointsService, RedeemPointsService>();
            services.AddTransient<IReferralConfigurationService, ReferralConfigurationService>();
            services.AddTransient<ICommonService, CommonService>();

            services.AddTransient<IHttpRestClient, HttpRestClient>();
            services.AddTransient<HttpClient>();

            services.AddMvc(o =>
            {
                //Add Authentication to all Controllers by default.
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });

            //services.AddTransient<ISmsSenderService, SmsSenderService>();
            //services.AddTransient<FunctionalService, FunctionalService>();
            //services.AddTransient<EmailSenderService, EmailSenderService>();
            //services.AddTransient<IEmailSender, EmailSenderService>();

            //services.Configure<SendGridOptions>(configuration.GetSection("SendGridOptions"));
            //services.Configure<SmtpOptions>(configuration.GetSection("SmtpOptions"));
            //services.Configure<TwilioOptions>(configuration.GetSection("TwilioOptions"));
            //services.Configure<BulkSmsOptions>(configuration.GetSection("BulkSmsOptions"));       

            return services;
        }
    }
}
