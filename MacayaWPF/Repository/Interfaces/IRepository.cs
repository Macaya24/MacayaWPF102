using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        Task SaveDataAsync(string storedProcedure, object parameters);
        Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedure, object? parameters = null);
    }
}
