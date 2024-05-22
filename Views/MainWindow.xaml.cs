using CryptoInfoApp.Services;
using CryptoInfoApp.ViewModels;
using System.Windows;

namespace CryptoInfoApp.Views
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
        }
    }
}