using MacayaWPF.ViewModels;

namespace MacayaWPF.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
    }
}
