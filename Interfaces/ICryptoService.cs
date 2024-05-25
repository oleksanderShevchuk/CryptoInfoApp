using CryptoInfoApp.Models;

namespace CryptoInfoApp.Interfaces
{
    public interface ICryptoService
    {
        Task<IEnumerable<Coin>> GetTopCoinsAsync(int count);
        Task<CoinDetail> GetCoinDetailAsync(string coinId);
        Task<IEnumerable<Coin>> GetAllCoinsAsync();
        Task<Dictionary<DateTimeOffset, double>> GetCoinMarketChartDataAsync(string coinId, string vsCurrency, long from, long to);
    }
}
