using System.Threading.Tasks;

namespace Referral.Web.Contract
{
    public interface ISmsSenderService
    {
        Task<Task> SendSmsAsync(string number, string message);
    }
}
