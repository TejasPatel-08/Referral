using Microsoft.EntityFrameworkCore;
using Referral.DAL.Context;
using Referral.Models;
using System.Threading.Tasks;
using System.Linq;

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

            var ppaDATA = from rc in _applicationDbContext.ReferralConfig
                       join ppa in _applicationDbContext.PointPurchaseAmount
                       on rc.PPA.Id equals ppa.Id
                       select new { ppa };

            var result = await _applicationDbContext.ReferralConfig.Include("PPA").SingleOrDefaultAsync();

            result.PPA = ppaDATA.Select(x => x.ppa).FirstOrDefault();

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
