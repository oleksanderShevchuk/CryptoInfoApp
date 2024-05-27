using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class CoinImages
    {
        [JsonProperty("thumb")]
        public string ThumbUrl { get; set; } = string.Empty;

        [JsonProperty("small")]
        public string SmallUrl { get; set; } = string.Empty;

        [JsonProperty("large")]
        public string LargeUrl { get; set; } = string.Empty;
    }
}
