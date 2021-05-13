using Referral.Models;
using System.Threading.Tasks;

namespace Referral.Services.Contracts
{
    public interface IReferralConfigurationService
    {
        Task<ReferralConfig> GetReferralConfiguration();
        Task<bool> Update_Post(ReferralConfig referralConfig);
    }
}
