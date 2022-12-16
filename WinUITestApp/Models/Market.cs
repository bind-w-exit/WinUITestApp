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

        [JsonProperty("price_change_percentage_1h_in_currency")]
        public decimal? PriceChangePercentage1h { get; set; }

        [JsonProperty("price_change_percentage_24h_in_currency")]
        public decimal? PriceChangePercentage24h { get; set; }

        [JsonProperty("price_change_percentage_7d_in_currency")]
        public decimal? PriceChangePercentage7d { get; set; }
    }
}
