using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using CryptoInfoApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

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
        public ICommand ShowDetailsCommand { get; }

        public MainViewModel()
        {
            _coinGeckoService = new CoinGeckoService();
            LoadData();
            ShowDetailsCommand = new RelayCommand(ShowDetails);
        }

        private async void LoadData()
        {
            var coins = await _coinGeckoService.GetTopCoinsAsync(10);
            Coins = new ObservableCollection<Coin>(coins);
        }

        private void ShowDetails(object parameter)
        {
            if (parameter is Coin selectedCoin)
            {
                var detailWindow = new CoinDetailView
                {
                    DataContext = new CoinDetailViewModel(selectedCoin.Id)
                };
                detailWindow.Show();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
