using MacayaWPF.ViewModels;

namespace MacayaWPF.Commands
{
    public class DeleteSmartPhoneCommand : BaseCommand
    {
        private readonly AddSmartPhoneViewModel _viewModel;

        public DeleteSmartPhoneCommand(AddSmartPhoneViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is int smartPhoneId)
            {
                await _viewModel.DeleteSmartPhoneAsync(smartPhoneId);
            }
        }
    }
}
