using Domain.Commands;
using Domain.Models;
using Framework.Extensions;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Framework.Commands
{
    public class CreateSmartPhone : ICreateSmartPhone
    {
        private readonly IRepository _repository;

        public CreateSmartPhone(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(SmartPhoneModel smartPhone)
        {
            await _repository.SaveDataAsync("CreateSmartPhone", smartPhone.ToCreateSmartPhoneDynamicParameters());
        }
    }
}
