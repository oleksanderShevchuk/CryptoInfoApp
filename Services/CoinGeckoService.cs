using CryptoInfoApp.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace CryptoInfoApp.Services
{
    public class CoinGeckoService
    {
        private static readonly HttpClient client = new HttpClient();

        public CoinGeckoService()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "CryptoInfoApp/1.0");
        }

        public async Task<List<Coin>> GetTopCoinsAsync(int numberOfCoins)
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={numberOfCoins}&page=1&sparkline=false");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Coin>>(responseBody);
        }
        public async Task<CoinDetail> GetCoinDetailAsync(string coinId)
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinId}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CoinDetail>(responseBody);
        }
    }
}
