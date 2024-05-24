using CryptoInfoApp.Helpers;
using CryptoInfoApp.Services;
using CryptoInfoApp.ViewModels;
using CryptoInfoApp.Views;
using System.Windows;

namespace CryptoInfoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var cryptoService = new CoinGeckoService();
            DataContext = new MainViewModel(cryptoService);

            MainView.Navigate(new MainView { DataContext = DataContext });
        }
        private void LightThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri($"Themes/Light.xaml", UriKind.Relative));
        }
        private void DarkThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri($"Themes/Dark.xaml", UriKind.Relative));
        }
    }
}