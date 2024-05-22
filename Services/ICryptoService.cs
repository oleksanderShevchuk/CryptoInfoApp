using CryptoInfoApp.Models;

namespace CryptoInfoApp.Services
{
    public interface ICryptoService
    {
        Task<IEnumerable<Coin>> GetTopCoinsAsync(int count);
        Task<CoinDetail> GetCoinDetailAsync(string coinId);
    }
}
