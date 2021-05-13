using Referral.DAL.Repository;
using Referral.Models;
using Referral.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Services
{
    public class CommonSerive : ICommonService
    {
        private readonly CommonRepository _commonRepository;

        public CommonSerive(CommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<List<string>> PhoneList_Get(string Prefix)
        {
            return await _commonRepository.PhoneList_Get(Prefix);
        }

        public async Task<Customers> CustomerByPhone_Get(string PhoneNumber)
        {
            var model = await _commonRepository.CustomerByPhone_Get(PhoneNumber);
            return model;
        }

        public async Task<bool> Check_PhoneNumber(string PhoneNumber)
        {
            var reult = await _commonRepository.Check_PhoneNumber(PhoneNumber);
            return reult;
        }
    }
}
