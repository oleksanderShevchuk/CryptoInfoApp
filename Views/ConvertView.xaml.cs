using CryptoInfoApp.Services;
using CryptoInfoApp.ViewModels;
using System.Windows.Controls;

namespace CryptoInfoApp.Views
{
    /// <summary>
    /// Interaction logic for ConvertView.xaml
    /// </summary>
    public partial class ConvertView : Page
    {
        public ConvertView()
        {
            InitializeComponent();
            DataContext = new ConvertViewModel(new CoinGeckoService());
        }
    }
}
