using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoInfoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CoinGeckoService _coinGeckoService;
        private ObservableCollection<Coin> _coins;

        public ObservableCollection<Coin> Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }

        public MainViewModel()
        {
            _coinGeckoService = new CoinGeckoService();
            LoadData();
        }

        private async void LoadData()
        {
            var coins = await _coinGeckoService.GetTopCoinsAsync(10);
            Coins = new ObservableCollection<Coin>(coins);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
