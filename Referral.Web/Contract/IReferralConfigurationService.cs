using Referral.Models;
using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface IReferralConfigurationService
    {
        Task<ReferralConfig> GetReferralConfiguration();
        Task<bool> Update_Post(ReferralConfig referralConfig);
    }
}
