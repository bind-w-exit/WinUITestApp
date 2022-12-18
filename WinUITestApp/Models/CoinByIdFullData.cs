using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// References: https://github.com/tosunthex/CoinGecko

namespace WinUITestApp.Models;

public class CoinByIdFullData : CoinFullData
{
    [JsonProperty("categories")] 
    public string[] Categories { get; set; }

    [JsonProperty("description")] 
    public Dictionary<string, string> Description { get; set; }

    [JsonProperty("links")] 
    public Links Links { get; set; }

    [JsonProperty("genesis_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? GenesisDate { get; set; }

    [JsonProperty("market_cap_rank")] 
    public long? MarketCapRank { get; set; }

    [JsonProperty("coingecko_rank")] 
    public long? CoinGeckoRank { get; set; }

    [JsonProperty("coingecko_score")] 
    public double? CoinGeckoScore { get; set; }

    [JsonProperty("developer_score")] 
    public double? DeveloperScore { get; set; }

    [JsonProperty("community_score")] 
    public double? CommunityScore { get; set; }

    [JsonProperty("liquidity_score")] 
    public double? LiquidityScore { get; set; }
}

public class Links
{
    [JsonProperty("homepage")]
    public string[] Homepage { get; set; }

    [JsonProperty("blockchain_site")]
    public string[] BlockchainSite { get; set; }
}
