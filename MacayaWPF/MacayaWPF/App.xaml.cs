using Domain.Commands;
using Domain.Queries;
using Framework;
using Framework.Commands;
using Framework.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Interfaces;
using MacayaWPF.Services;
using MacayaWPF.Stores;
using MacayaWPF.ViewModels;
using MacayaWPF.Views;
using System;
using System.IO;
using System.Windows;

namespace MacayaWPF
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Configuration
                    services.AddSingleton<IConfiguration>(context.Configuration);

                    // Repository
                    services.AddSingleton<IRepository, Framework.Repository>();

                    // Database Initializer
                    services.AddSingleton<DatabaseInitializer>();

                    // Commands
                    services.AddTransient<ICreateSmartPhone, CreateSmartPhone>();
                    services.AddTransient<IUpdateSmartPhone, UpdateSmartPhone>();
                    services.AddTransient<IDeleteSmartPhone, DeleteSmartPhone>();

                    // Queries
                    services.AddTransient<IGetAllSmartPhones, GetAllSmartPhones>();
                    services.AddTransient<IReadSmartPhoneById, ReadSmartPhoneById>();

                    // Stores
                    services.AddSingleton<NavigationStore>();

                    // Services
                    services.AddSingleton<INavigationService, NavigationService>();

                    // ViewModels
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<HomeViewModel>();
                    services.AddTransient<AddSmartPhoneViewModel>();

                    // MainWindow
                    services.AddSingleton<MainWindow>(s => new MainWindow
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            // Initialize database automatically
            var dbInitializer = _host.Services.GetRequiredService<DatabaseInitializer>();
            try
            {
                await dbInitializer.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization failed: {ex.Message}\n\nPlease check your connection string.", 
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            var navigationService = _host.Services.GetRequiredService<INavigationService>();
            navigationService.NavigateTo<HomeViewModel>();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
