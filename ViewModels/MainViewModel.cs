using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using CryptoInfoApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICryptoService _cryptoService;
        private ObservableCollection<Coin> _coins;
        private ObservableCollection<Coin> _allCoins;
        private string _searchQuery;
        public MainViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            LoadDataCommand = new RelayCommand(async () => await LoadData());
            SearchCommand = new RelayCommand(param => ExecuteSearch());
            ShowDetailsCommand = new RelayCommand(param => ShowDetails(param));

            LoadData();
        }
        public ObservableCollection<Coin> Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                ExecuteSearch();
            }
        }
        public ICommand ShowDetailsCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand SearchCommand { get; }

        private async Task LoadData()
        {
            var coins = await _cryptoService.GetTopCoinsAsync(10);
            _allCoins = new ObservableCollection<Coin>(coins);
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
        private void ExecuteSearch()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                Coins = _allCoins;
            }
            else
            {
                var filteredCoins = _allCoins.Where(c => c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                         c.Symbol.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));
                Coins = new ObservableCollection<Coin>(filteredCoins);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
