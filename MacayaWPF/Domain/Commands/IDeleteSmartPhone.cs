using System.Threading.Tasks;

namespace Domain.Commands
{
    public interface IDeleteSmartPhone
    {
        Task ExecuteAsync(int smartPhoneId);
    }
}
