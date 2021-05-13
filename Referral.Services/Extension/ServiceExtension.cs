using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Referral.DAL.Extension;
using Referral.Services.Contracts;
using Referral.Services.Services;

namespace Referral.Services.Extension
{
    public static class ServiceExtension
    {
        public static void AddServiceResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<IOperatorsService, OperatorsService>();
            services.AddTransient<ICustomersPurchaseService, CustomersPurchaseService>();
            services.AddTransient<ICustomersPointsService, CustomersPointsService>();
            services.AddTransient<IRedeemPointsService, RedeemPointsService>();
            services.AddTransient<IReferralConfigurationService, ReferralConfigurationService>();
            services.AddTransient<ICommonService, CommonSerive>();

            //services.AddTransient<Customers>();
            //services.AddScoped<UserManager<Customers>>();
            //services.AddScoped<SignInManager<Customers>>();
            //services.AddIdentity<Customers, IdentityRole>();
            //services.AddIdentity<IdentityUser, IdentityRole>();
            //services.AddTransient<IdentityUser, Customers>();
            //services.AddScoped<IUserValidator<Customers>, UserValidator<Customers>>();
            //services.AddScoped<IPasswordValidator<Customers>, PasswordValidator<Customers>>();
            //services.AddScoped<IPasswordHasher<Customers>, PasswordHasher<Customers>>();
            //services.AddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            //services.AddScoped<IRoleValidator<Customers>, RoleValidator<Customers>>();
            //// No interface for the error describer so we can add errors without rev'ing the interface
            //services.AddScoped<IdentityErrorDescriber>();
            //services.AddScoped<ISecurityStampValidator, SecurityStampValidator<Customers>>();
            //services.AddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<Customers>>();
            //services.AddScoped<IUserClaimsPrincipalFactory<Customers>, UserClaimsPrincipalFactory<Customers, Customers>>();
            //services.AddScoped<RoleManager<Customers>>();

            //services.AddTransient<ISmsSenderService, SmsSenderService>();
            //services.AddTransient<FunctionalService, FunctionalService>();
            //services.AddTransient<EmailSenderService, EmailSenderService>();
            //services.AddTransient<IEmailSender, EmailSenderService>();

            //services.Configure<SendGridOptions>(configuration.GetSection("SendGridOptions"));
            //services.Configure<SmtpOptions>(configuration.GetSection("SmtpOptions"));
            //services.Configure<TwilioOptions>(configuration.GetSection("TwilioOptions"));
            //services.Configure<BulkSmsOptions>(configuration.GetSection("BulkSmsOptions"));

            services.AddDALResolver(configuration);
        }
    }
}
