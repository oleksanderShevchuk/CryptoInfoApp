using CryptoInfoApp.Data;
using CryptoInfoApp.Helpers;
using CryptoInfoApp.Interfaces;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using CryptoInfoApp.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly int COUNT_COINS = 10;
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
            NavigateCommand = new RelayCommand(param => ExecuteNavigate(param));
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
        public ICommand NavigateCommand { get; }

        private async Task LoadData()
        {
            var coins = await _cryptoService.GetTopCoinsAsync(COUNT_COINS);
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
                ClearSearch();
            }
        }
        private void ExecuteSearch()
        {
            if (_allCoins != null)
            {
                Coins = new ObservableCollection<Coin>(SearchService.SearchCoins(_allCoins, SearchQuery));
            }
        }

        public void ClearSearch()
        {
            SearchQuery = string.Empty;
        }

        private void ExecuteNavigate(object parameter)
        {
            if (parameter is string pageName)
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;

                switch (pageName)
                {
                    case Titles.MainView:
                        mainWindow.MainView.Navigate(new MainView { DataContext = this });
                        break;
                    case Titles.CoinsView:
                        mainWindow.MainView.Navigate(new CoinsView());
                        break;
                    case Titles.ConvertView:
                        mainWindow.MainView.Navigate(new ConvertView());
                        break;

                }
                ClearSearch();
            }
        }
    }
}
