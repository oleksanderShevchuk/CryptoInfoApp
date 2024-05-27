using CryptoInfoApp.Helpers;
using CryptoInfoApp.Models;
using CryptoInfoApp.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Diagnostics;
using System.Windows.Input;

namespace CryptoInfoApp.ViewModels
{
    public class CoinDetailViewModel : BaseViewModel
    {
        private readonly CoinGeckoService _coinGeckoService;
        private CoinDetail _coinDetail;
        private PlotModel _plotModel;
        private string _selectedChartRange;
        public CoinDetail CoinDetail
        { get { return _coinDetail; } 
            set {
                _coinDetail = value;
                OnPropertyChanged(nameof(CoinDetail));
                if (CoinDetail != null )
                    LoadChartData(_selectedChartRange);
            }
        }
        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set
            {
                _plotModel = value;
                OnPropertyChanged(nameof(PlotModel));
            }
        }
        public List<string> ChartRanges { get; } = new List<string> { "1d", "7d", "1m", "1y" };
        public string SelectedChartRange
        {
            get { return _selectedChartRange; }
            set
            {
                _selectedChartRange = value;
                if(CoinDetail != null)
                    ChangeChartRange(_selectedChartRange);
                OnPropertyChanged(nameof(SelectedChartRange));
            }
        }
        public ICommand NavigateCommand { get; }
        public ICommand ChangeChartRangeCommand { get; }
        public CoinDetailViewModel(string coinId)
        {
            PlotModel = new PlotModel { Title = "Crypto Price Chart" };
            _coinGeckoService = new CoinGeckoService();
            LoadCoinDetail(coinId);
            NavigateCommand = new RelayCommand(NavigateToUrl);
            SelectedChartRange = "1d"; // by default 
            ChangeChartRangeCommand = new RelayCommand(ChangeChartRange);
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
        private async void LoadChartData(string range)
        {
            long from, to;
            switch (range)
            {
                case "1d":
                    from = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeSeconds();
                    to = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    break;
                case "7d":
                    from = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds();
                    to = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    break;
                case "1m":
                    from = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeSeconds();
                    to = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    break;
                case "1y":
                    from = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds();
                    to = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    break;
                default:
                    from = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeSeconds();
                    to = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    break;
            }
            var coinData = await _coinGeckoService.GetCoinMarketChartDataAsync(CoinDetail.Id, "usd", from, to);
            var plotModel = new PlotModel { Title = $"{CoinDetail.Name} to USD" };
            var series = new LineSeries();

            if (coinData != null)
            {
                foreach (var dataPoint in coinData)
                {
                    series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dataPoint.Key.UtcDateTime), dataPoint.Value));
                }
            }
            plotModel.Series.Add(series);
            PlotModel = plotModel;
        }
        private void ChangeChartRange(string range)
        {
            LoadChartData(range);
        }
        private void ChangeChartRange(object parameter)
        {
            if (parameter is string range)
            {
                LoadChartData(range);
            }
        }
    }
}
