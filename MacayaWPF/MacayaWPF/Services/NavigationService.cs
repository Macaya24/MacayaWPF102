using Microsoft.Extensions.DependencyInjection;
using MacayaWPF.Stores;
using MacayaWPF.ViewModels;
using System;

namespace MacayaWPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(NavigationStore navigationStore, IServiceProvider serviceProvider)
        {
            _navigationStore = navigationStore;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
            _navigationStore.CurrentViewModel = viewModel;
        }
    }
}
