using Newtonsoft.Json;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models
{
    public class SparklineIn7D
    {
        [JsonProperty("price")]
        public decimal[] Price { get; set; }
    }
}
