using Referral.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface ICustomersPointsService
    {
        Task<List<CustomersPoints>> List(Guid userId);
        Task<List<CustomersPointsVM>> CustomersPointList();
    }
}
