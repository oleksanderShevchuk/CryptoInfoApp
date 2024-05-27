using Newtonsoft.Json;

namespace CryptoInfoApp.Models
{
    public class CoinImages
    {
        [JsonProperty("thumb")]
        public string ThumbUrl { get; set; }

        [JsonProperty("small")]
        public string SmallUrl { get; set; }

        [JsonProperty("large")]
        public string LargeUrl { get; set; }
    }
}
