using Domain.Models;
using MacayaWPF.ViewModels;

namespace MacayaWPF.Commands
{
    public class EditSmartPhoneCommand : BaseCommand
    {
        private readonly AddSmartPhoneViewModel _viewModel;

        public EditSmartPhoneCommand(AddSmartPhoneViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is SmartPhoneModel smartPhone)
            {
                _viewModel.LoadSmartPhoneForEdit(smartPhone);
            }
        }
    }
}
