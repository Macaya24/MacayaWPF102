using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public interface IReadSmartPhoneById
    {
        Task<SmartPhoneModel> ExecuteAsync(int smartPhoneId);
    }
}
