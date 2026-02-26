using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public interface ICreateSmartPhone
    {
        Task ExecuteAsync(SmartPhoneModel smartPhone);
    }
}
