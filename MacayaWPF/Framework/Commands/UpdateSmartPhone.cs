using Domain.Commands;
using Domain.Models;
using Framework.Extensions;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Framework.Commands
{
    public class UpdateSmartPhone : IUpdateSmartPhone
    {
        private readonly IRepository _repository;

        public UpdateSmartPhone(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(SmartPhoneModel smartPhone)
        {
            await _repository.SaveDataAsync("UpdateSmartPhone", smartPhone.ToSmartPhoneDynamicParameters());
        }
    }
}
