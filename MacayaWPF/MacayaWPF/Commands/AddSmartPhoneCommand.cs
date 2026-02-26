using MacayaWPF.ViewModels;
using System;

namespace MacayaWPF.Commands
{
    public class AddSmartPhoneCommand : BaseCommand
    {
        private readonly AddSmartPhoneViewModel _viewModel;

        public AddSmartPhoneCommand(AddSmartPhoneViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            await _viewModel.AddSmartPhoneAsync();
        }
    }
}
