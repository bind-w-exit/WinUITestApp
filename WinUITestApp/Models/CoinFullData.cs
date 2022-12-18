using Newtonsoft.Json;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models;

public class CoinFullData : Coin
{
    [JsonProperty("image")]
    public Image Image { get; set; }

    [JsonProperty("market_data", NullValueHandling = NullValueHandling.Ignore)]
    public CoinByIdMarketData MarketData { get; set; }
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

public class CoinByIdMarketData : MarketData
{
    [JsonProperty("sparkline_7d", NullValueHandling = NullValueHandling.Ignore)]
    public SparklineIn7D Sparkline7D { get; set; }
}
