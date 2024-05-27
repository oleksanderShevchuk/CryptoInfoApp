using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class CoinDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }

        [JsonProperty("tickers")]
        public IEnumerable<Ticker> Tickers { get; set; }
        [JsonProperty("image")]
        public CoinImages Image { get; set; }
    }
}
