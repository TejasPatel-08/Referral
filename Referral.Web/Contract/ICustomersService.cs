using Referral.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface ICustomersService
    {
        Task<List<Customers>> List();

        Task<bool> Create_Post(Customers customers);

        Task<Customers> Update(string userId);

        Task<bool> Update_Post(Customers customers);

        Task<bool> Delete(string userId);

        Task<bool> Activate_User(Guid userId, bool isActive);

        Task<bool> Create_Modal(CustomerModal customerModal);
    }
}
