using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Referral.Models;

namespace Referral.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersPoints> CustomersPoints { get; set; }
        public DbSet<CustomersPurchase> CustomersPurchase { get; set; }
        public DbSet<ReferralConfig> ReferralConfig { get; set; }
        public DbSet<PointPurchaseAmount> PointPurchaseAmount { get; set; }
    }
}
