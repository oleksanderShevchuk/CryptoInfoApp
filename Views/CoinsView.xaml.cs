using CryptoInfoApp.Services;
using CryptoInfoApp.ViewModels;
using System.Windows.Controls;

namespace CryptoInfoApp.Views
{
    /// <summary>
    /// Interaction logic for CoinsView.xaml
    /// </summary>
    public partial class CoinsView : Page
    {
        public CoinsView()
        {
            InitializeComponent();
            DataContext = new CoinsViewModel(new CoinGeckoService());
        }
    }
}
