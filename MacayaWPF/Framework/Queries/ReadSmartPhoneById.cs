using Domain.Models;
using Domain.Queries;
using Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Queries
{
    public class ReadSmartPhoneById : IReadSmartPhoneById
    {
        private readonly IRepository _repository;

        public ReadSmartPhoneById(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<SmartPhoneModel> ExecuteAsync(int smartPhoneId)
        {
            var parameters = new { SmartPhoneId = smartPhoneId };
            var result = await _repository.GetDataAsync<SmartPhoneModel>("ReadSmartPhoneById", parameters);
            return result.FirstOrDefault();
        }
    }
}
