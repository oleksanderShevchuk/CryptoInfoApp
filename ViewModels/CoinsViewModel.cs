using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using CryptoInfoApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class CoinsViewModel : INotifyPropertyChanged
    {
        private readonly ICryptoService _cryptoService;
        private ObservableCollection<Coin> _coins;
        private ObservableCollection<Coin> _allCoins;
        private string _searchQuery;
        public CoinsViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            LoadDataCommand = new RelayCommand(async () => await LoadAllCoins());
            ShowDetailsCommand = new RelayCommand(param => ShowDetails(param));
            SearchCommand = new RelayCommand(param => ExecuteSearch());
            LoadAllCoins();
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
        public ICommand LoadDataCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand SearchCommand { get; }

        private async Task LoadAllCoins()
        {
            var coins = await _cryptoService.GetAllCoinsAsync();
            _allCoins = new ObservableCollection<Coin>(coins);
            Coins = new ObservableCollection<Coin>(coins);
        }
        private void ShowDetails(object parameter)
        {
            if (parameter is Coin selectedCoin)
            {
                var detailView = new CoinDetailView
                {
                    DataContext = new CoinDetailViewModel(selectedCoin.Id)
                };
                // Navigate to the detail view
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainView.Navigate(detailView);
            }
        }
        private void ExecuteSearch()
        {
            Coins = SearchService.SearchCoins(_allCoins, SearchQuery);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
