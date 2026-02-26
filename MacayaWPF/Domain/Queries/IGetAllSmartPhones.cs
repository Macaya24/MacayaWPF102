using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public interface IGetAllSmartPhones
    {
        Task<IEnumerable<SmartPhoneModel>> ExecuteAsync();
    }
}
