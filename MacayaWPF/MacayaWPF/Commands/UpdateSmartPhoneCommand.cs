using MacayaWPF.ViewModels;

namespace MacayaWPF.Commands
{
    public class UpdateSmartPhoneCommand : BaseCommand
    {
        private readonly AddSmartPhoneViewModel _viewModel;

        public UpdateSmartPhoneCommand(AddSmartPhoneViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            await _viewModel.UpdateSmartPhoneAsync();
        }
    }
}
