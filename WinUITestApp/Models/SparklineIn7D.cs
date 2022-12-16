using Newtonsoft.Json;

namespace WinUITestApp.Models
{
    public class SparklineIn7D
    {
        [JsonProperty("price")]
        public decimal[] Price { get; set; }
    }
}
