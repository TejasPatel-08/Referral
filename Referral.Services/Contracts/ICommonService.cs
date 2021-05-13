using Referral.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Contracts
{
    public interface ICommonService
    {
        Task<Customers> CustomerByPhone_Get(string PhoneNumber);
        Task<List<string>> PhoneList_Get(string Prefix);
        Task<bool> Check_PhoneNumber(string PhoneNumber);
    }
}
