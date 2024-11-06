using System.Windows;
using MvvmDemo.ViewModels;
using MvvmDemo.Views;

namespace MvvmDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow(new MainViewModel());

            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
