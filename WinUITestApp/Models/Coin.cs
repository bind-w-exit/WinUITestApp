using Newtonsoft.Json;

namespace WinUITestApp.Models
{
    public class Coin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty ("name")]
        public string Name { get; set; }
    }
}
