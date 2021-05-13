using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Referral.DAL.Context;
using Referral.Models;
using Referral.DAL.Repository;

namespace Referral.DAL.Extension
{
    public static class DALExtension
    {
        public static void AddDALResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<Customers, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddTransient<CustomersPointsRepository>();
            services.AddTransient<CustomersPurchaseRepository>();
            services.AddTransient<CustomersRepository>();
            services.AddTransient<OperatorsRepository>();
            services.AddTransient<RedeemPointsRepository>();
            services.AddTransient<ReferralConfigurationRepository>();
            services.AddTransient<CommonRepository>();           
        }
    }
}
