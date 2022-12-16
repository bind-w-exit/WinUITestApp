using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WinUITestApp.Models
{
    public class CoinFullData : Coin
    {
        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("market_data", NullValueHandling = NullValueHandling.Ignore)]
        public MarketData MarketData { get; set; }
    }

    public class MarketData : MarketDataOhlcv
    {
        [JsonProperty("roi")] 
        public Roi Roi { get; set; }

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

        [JsonProperty("price_change_percentage_7d")]
        public string PriceChangePercentage7D { get; set; }

        [JsonProperty("price_change_percentage_14d")]
        public string PriceChangePercentage14D { get; set; }

        [JsonProperty("price_change_percentage_30d")]
        public string PriceChangePercentage30D { get; set; }

        [JsonProperty("price_change_percentage_60d")]
        public string PriceChangePercentage60D { get; set; }

        [JsonProperty("price_change_percentage_200d")]
        public string PriceChangePercentage200D { get; set; }

        [JsonProperty("price_change_percentage_1y")]
        public string PriceChangePercentage1Y { get; set; }

        [JsonProperty("price_change_24h_in_currency")]
        public Dictionary<string, decimal> PriceChange24HInCurrency { get; set; }

        [JsonProperty("price_change_percentage_1h_in_currency")]
        public Dictionary<string, double> PriceChangePercentage1HInCurrency { get; set; }

        [JsonProperty("price_change_percentage_24h_in_currency")]
        public Dictionary<string, double> PriceChangePercentage24HInCurrency { get; set; }

        [JsonProperty("price_change_percentage_7d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage7DInCurrency { get; set; }

        [JsonProperty("price_change_percentage_14d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage14DInCurrency { get; set; }

        [JsonProperty("price_change_percentage_30d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage30DInCurrency { get; set; }

        [JsonProperty("price_change_percentage_60d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage60DInCurrency { get; set; }

        [JsonProperty("price_change_percentage_200d_in_currency")]
        public Dictionary<string, double> PriceChangePercentage200DInCurrency { get; set; }

        [JsonProperty("price_change_percentage_1y_in_currency")]
        public Dictionary<string, double> PriceChangePercentage1YInCurrency { get; set; }

        [JsonProperty("market_cap_change_24h_in_currency")]
        public Dictionary<string, decimal> MarketCapChange24HInCurrency { get; set; }

        [JsonProperty("market_cap_change_percentage_24h_in_currency")]
        public Dictionary<string, decimal> MarketCapChangePercentage24HInCurrency { get; set; }
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

    public class Roi
    {
        [JsonProperty("times")]
        public decimal? Times { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("percentage")]
        public decimal? Percentage { get; set; }
    }
}
