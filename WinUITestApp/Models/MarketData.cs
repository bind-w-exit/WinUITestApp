using Newtonsoft.Json;
using System.Collections.Generic;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models;

public class MarketData : MarketDataOhlcv
{
    [JsonProperty("current_price")]
    public Dictionary<string, decimal?> CurrentPrice { get; set; }

    [JsonProperty("market_cap")]
    public Dictionary<string, decimal?> MarketCap { get; set; }

    [JsonProperty("total_volume")]
    public Dictionary<string, decimal?> TotalVolume { get; set; }

    [JsonProperty("high_24h")]
    public Dictionary<string, decimal?> High24H { get; set; }

    [JsonProperty("low_24h")]
    public Dictionary<string, decimal?> Low24H { get; set; }

    [JsonProperty("price_change_24h_in_currency")]
    public Dictionary<string, decimal?> PriceChange24HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_7d")]
    public double? PriceChangePercentage7D { get; set; }

    [JsonProperty("price_change_percentage_30d")]
    public double? PriceChangePercentage30D { get; set; }

    [JsonProperty("price_change_percentage_1y")]
    public double? PriceChangePercentage1Y { get; set; }

    [JsonProperty("price_change_percentage_1h_in_currency")]
    public Dictionary<string, double?> PriceChangePercentage1HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_24h_in_currency")]
    public Dictionary<string, double?> PriceChangePercentage24HInCurrency { get; set; }

    [JsonProperty("price_change_percentage_7d_in_currency")]
    public Dictionary<string, double?> PriceChangePercentage7DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_30d_in_currency")]
    public Dictionary<string, double?> PriceChangePercentage30DInCurrency { get; set; }

    [JsonProperty("price_change_percentage_1y_in_currency")]
    public Dictionary<string, double?> PriceChangePercentage1YInCurrency { get; set; }

    [JsonProperty("market_cap_change_24h_in_currency")]
    public Dictionary<string, decimal?> MarketCapChange24HInCurrency { get; set; }

    [JsonProperty("market_cap_change_percentage_24h_in_currency")]
    public Dictionary<string, double?> MarketCapChangePercentage24HInCurrency { get; set; }
}
