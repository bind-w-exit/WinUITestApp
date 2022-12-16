using Newtonsoft.Json;

namespace WinUITestApp.Models
{
    public class Market : Coin
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("current_price")]
        public decimal? CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }
    }
}
