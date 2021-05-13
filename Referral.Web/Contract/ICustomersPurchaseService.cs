using Referral.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface ICustomersPurchaseService
    {
        Task<List<CustomersPurchase>> List();
        Task<bool> Create_Post(CustomersPurchaseVM customersPurchaseVM);
    }
}
