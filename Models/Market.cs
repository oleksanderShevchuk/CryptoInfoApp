using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
