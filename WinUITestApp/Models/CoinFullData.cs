using Newtonsoft.Json;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models
{
    public class CoinFullData : Coin
    {
        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("market_data", NullValueHandling = NullValueHandling.Ignore)]
        public MarketData MarketData { get; set; }
    }

    public class Image
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }
}
