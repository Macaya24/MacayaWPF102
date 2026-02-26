using Domain.Commands;
using Framework.Extensions;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Framework.Commands
{
    public class DeleteSmartPhone : IDeleteSmartPhone
    {
        private readonly IRepository _repository;

        public DeleteSmartPhone(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int smartPhoneId)
        {
            await _repository.SaveDataAsync("DeleteSmartPhone", SmartPhoneExtension.ToDeleteSmartPhoneDynamicParameters(smartPhoneId));
        }
    }
}
