using FileDownloader.Stores;
using FileDownloader.ViewModels;
using FileDownloader.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new();

            navigationStore.CurrentViewModel = new HomeVM(navigationStore);

            MainWindow mainWindow = new()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
