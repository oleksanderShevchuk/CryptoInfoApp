using CryptoInfoApp.Interfaces;
using CryptoInfoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows;

namespace CryptoInfoApp.Services
{
    public class CoinGeckoService : ICryptoService
    {
        private static readonly HttpClient client = new HttpClient();

        public CoinGeckoService()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "CryptoInfoApp/1.0");
        }

        public async Task<IEnumerable<Coin>> GetTopCoinsAsync(int numberOfCoins)
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={numberOfCoins}&page=1&sparkline=false");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Coin>>(responseBody);
        }
        public async Task<CoinDetail> GetCoinDetailAsync(string coinId)
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/{coinId}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CoinDetail>(responseBody);
        }
        public async Task<IEnumerable<Coin>> GetAllCoinsAsync() 
        {
            var response = await client.GetAsync($"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Coin>>(responseBody);
        }
        public async Task<Dictionary<DateTimeOffset, double>> GetCoinMarketChartDataAsync(string coinId, string vsCurrency, long from, long to)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart/range?vs_currency={vsCurrency}&from={from}&to={to}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(json);
                var pricesArray = jsonObject["prices"] as JArray;
                var prices = new Dictionary<DateTimeOffset, double>();

                foreach (var item in pricesArray)
                {
                    var priceArray = item as JArray;
                    var timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)priceArray[0]);
                    var price = (double)priceArray[1];
                    prices.Add(timestamp, price);
                }

                return prices;
            }
            else
            {
                MessageBox.Show($"Error fetching data from CoinGecko API: {response.StatusCode}");
                return null;
            }
        }
    }
}
