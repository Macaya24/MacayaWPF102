using Domain.Models;
using Domain.Queries;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Queries
{
    public class GetAllSmartPhones : IGetAllSmartPhones
    {
        private readonly IRepository _repository;

        public GetAllSmartPhones(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SmartPhoneModel>> ExecuteAsync()
        {
            return await _repository.GetDataAsync<SmartPhoneModel>("GetAllSmartPhones");
        }
    }
}
