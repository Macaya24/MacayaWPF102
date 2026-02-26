using MacayaWPF.Services;
using MacayaWPF.ViewModels;

namespace MacayaWPF.Commands
{
    public class OpenHomeCommand : BaseCommand
    {
        private readonly INavigationService _navigationService;

        public OpenHomeCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateTo<AddSmartPhoneViewModel>();
        }
    }
}
