using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using System.Globalization;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class ConvertViewModel : BaseViewModel
    {
        private readonly CoinGeckoService _coinGeckoService;
        private IEnumerable<Coin> _availableCoins;
        private Coin _selectedFromCurrency;
        private Coin _selectedToCurrency;
        private string _amountToExchange;
        private string _exchangeResult;

        public IEnumerable<Coin> AvailableCoins
        {
            get { return _availableCoins; }
            set
            {
                _availableCoins = value;
                OnPropertyChanged(nameof(AvailableCoins));
            }
        }
        public Coin SelectedFromCurrency
        {
            get { return _selectedFromCurrency; }
            set
            {
                _selectedFromCurrency = value;
                OnPropertyChanged(nameof(SelectedFromCurrency));
                CalculateExchangeResult();
            }
        }
        public Coin SelectedToCurrency
        {
            get { return _selectedToCurrency; }
            set
            {
                _selectedToCurrency = value;
                OnPropertyChanged(nameof(SelectedToCurrency));
                CalculateExchangeResult();
            }
        }
        public string AmountToExchange
        {
            get { return _amountToExchange; }
            set
            {
                _amountToExchange = value;
                OnPropertyChanged(nameof(AmountToExchange));
                CalculateExchangeResult();
            }
        }

        public string ExchangeResult
        {
            get { return $"Result:  {_exchangeResult}"; }
            set
            {
                _exchangeResult = value;
                OnPropertyChanged(nameof(ExchangeResult));
            }
        }
        private string _selectedToCurrencySymbol;
        public string SelectedToCurrencySymbol
        {
            get { return _selectedToCurrencySymbol; }
            set
            {
                _selectedToCurrencySymbol = value;
                OnPropertyChanged(nameof(SelectedToCurrencySymbol));
            }
        }
        public ICommand ConvertCommand { get; }
        public ICommand ClearCommand { get; }
        public ConvertViewModel(CoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
            LoadAvailableCoins();
            ConvertCommand = new RelayCommand(CalculateExchangeResult);
            ClearCommand = new RelayCommand(Clear);
        }
        private async Task LoadAvailableCoins()
        {
            AvailableCoins = await _coinGeckoService.GetAllCoinsAsync();
        }
        private void CalculateExchangeResult()
        {
            if (SelectedFromCurrency != null && SelectedToCurrency != null && AmountToExchange != null && AmountToExchange != string.Empty)
            {
                ExchangeResult = (Decimal.Parse(AmountToExchange) * SelectedFromCurrency.CurrentPrice / SelectedToCurrency.CurrentPrice).ToString("#,0.#####", CultureInfo.InvariantCulture);
                SelectedToCurrencySymbol = SelectedToCurrency.Symbol;
            }
            else
            {
                ExchangeResult = string.Empty;
            }
        }
        private void Clear(object parameter)
        {
            SelectedFromCurrency = null!;
            SelectedToCurrency = null!;
            AmountToExchange = string.Empty;
            ExchangeResult = string.Empty;
            SelectedToCurrencySymbol = string.Empty;
        }
    }
}
