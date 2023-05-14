using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LottieLoading.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;

namespace LottieLoading.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider = null!;
        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider =
                new ServiceCollection()
                    .AddSingleton<IDialogService, DialogService>()
                    .AddTransient<MainViewModel>()
                    .BuildServiceProvider();

            ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            var mainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainViewModel>()
            };
            mainWindow.Show();
        }
    }
}
