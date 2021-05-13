using Microsoft.EntityFrameworkCore;
using Referral.DAL.Context;
using Referral.Models;
using System.Threading.Tasks;

namespace Referral.DAL.Repository
{
    public class ReferralConfigurationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReferralConfigurationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ReferralConfig> GetReferralConfiguration()
        {
            ReferralConfig referralConfig = new ReferralConfig
            {
                PPA = new PointPurchaseAmount()
            };

            var result = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();

            if (result != null)
                referralConfig = result;

            return referralConfig;
        }

        public async Task<bool> Update_Post(ReferralConfig referralConfig)
        {
            _applicationDbContext.Update(referralConfig);
            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
