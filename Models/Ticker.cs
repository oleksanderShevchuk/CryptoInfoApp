using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class Ticker
    {
        [JsonProperty("market")]
        public Market? Market { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("trade_url")]
        public string TradeUrl { get; set; } = string.Empty;
    }
}
