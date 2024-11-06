using System.Windows;
using MvvmDemo.ViewModels;

namespace MvvmDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        public MainWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            InitializeComponent();

            DataContext = _mainViewModel;

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.LoadAsync();
        }
    }
}
