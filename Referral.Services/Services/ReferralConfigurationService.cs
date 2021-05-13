using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using Referral.Services.Extension;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class ReferralConfigurationService : IReferralConfigurationService
    {
        private readonly ReferralConfigurationRepository _referralConfigurationRepository;

        public ReferralConfigurationService(ReferralConfigurationRepository referralConfigurationRepository)
        {
            _referralConfigurationRepository = referralConfigurationRepository;
        }

        public async Task<ReferralConfig> GetReferralConfiguration()
        {
            var models = await _referralConfigurationRepository.GetReferralConfiguration();
            return models;
        }

        public async Task<bool> Update_Post(ReferralConfig referralConfig)
        {
            return await _referralConfigurationRepository.Update_Post(referralConfig);
        }
    }
}
