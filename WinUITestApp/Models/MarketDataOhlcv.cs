using Newtonsoft.Json;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models;

public class MarketDataOhlcv
{
    [JsonProperty("market_cap_rank")]
    public long? MarketCapRank { get; set; }

    [JsonProperty("price_change_24h")]
    public decimal? PriceChange24H { get; set; }

    [JsonProperty("price_change_percentage_24h")]
    public double? PriceChangePercentage24H { get; set; }

    [JsonProperty("market_cap_change_24h")]
    public decimal? MarketCapChange24H { get; set; }

    [JsonProperty("market_cap_change_percentage_24h")]
    public decimal? MarketCapChangePercentage24H { get; set; }

    [JsonProperty("circulating_supply")]
    public decimal? CirculatingSupply { get; set; }

    [JsonProperty("total_supply")]
    public decimal? TotalSupply { get; set; }
}
