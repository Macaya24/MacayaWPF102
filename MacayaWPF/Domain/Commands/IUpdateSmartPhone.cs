using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public interface IUpdateSmartPhone
    {
        Task ExecuteAsync(SmartPhoneModel smartPhone);
    }
}
