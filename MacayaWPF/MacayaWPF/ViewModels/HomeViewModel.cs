using MacayaWPF.Commands;
using MacayaWPF.Services;
using System.Windows.Input;

namespace MacayaWPF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateToSmartPhoneManagementCommand { get; }

        public HomeViewModel(INavigationService navigationService)
        {
            NavigateToSmartPhoneManagementCommand = new OpenHomeCommand(navigationService);
        }

        public void NavigateToSmartPhoneManagement()
        {
            // This will be handled by command
        }
    }
}
