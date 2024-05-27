using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class MarketData
    {
        [JsonProperty("current_price")]
        public Dictionary<string, decimal>? CurrentPrice { get; set; }

        [JsonProperty("total_volume")]
        public Dictionary<string, decimal>? TotalVolume { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public decimal PriceChangePercentage24h { get; set; }
    }
}
