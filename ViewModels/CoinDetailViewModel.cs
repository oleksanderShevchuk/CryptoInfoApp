using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class CoinDetailViewModel : INotifyPropertyChanged
    {
        private readonly CoinGeckoService _coinGeckoService;
        private CoinDetail _coinDetail;
        public CoinDetail CoinDetail
        { get { return _coinDetail; } 
            set {
                _coinDetail = value;
                OnPropertyChanged(nameof(CoinDetail));
            }
        }
        public ICommand NavigateCommand { get; }
        public CoinDetailViewModel(string coinId)
        {
            _coinGeckoService = new CoinGeckoService();
            LoadCoinDetail(coinId);
            NavigateCommand = new RelayCommand(NavigateToUrl);
        }

        private async void LoadCoinDetail(string coinId)
        {
            CoinDetail = await _coinGeckoService.GetCoinDetailAsync(coinId);
        }

        private void NavigateToUrl(object url)
        {
            if (url is string uri && !string.IsNullOrEmpty(uri))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = uri,
                    UseShellExecute = true
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
