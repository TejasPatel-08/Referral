using Referral.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Services.Contracts
{
    public interface IOperatorsService
    {
        Task<List<Customers>> List();

        Task<Customers> Update(string userId);

        Task<bool> Create_Post(Customers customers);

        Task<bool> Update_Post(Customers customers);

        Task<bool> Delete(string userId);

        Task<bool> Activate_User(Guid userId, bool isActive);
    }
}
