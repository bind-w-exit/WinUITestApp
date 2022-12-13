using System.Collections.Generic;
using WinUITestApp.Models;

namespace WinUITestApp.Services
{
    public static class CoinGeckoApiService
    {
        public static List<Coin> GetMarkets()
        {
            var coins = new List<Coin>
            {
                new Coin { Id = "bitcoin", Symbol = "btc", Name = "Bitcoin", Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1547033579", CurrentPrice = 17840, MarketCap = 343144440684 },
                new Coin { Id = "ethereum", Symbol = "eth", Name = "Ethereum", Image = "https://assets.coingecko.com/coins/images/279/large/ethereum.png?1595348880", CurrentPrice = 1333, MarketCap = 160712582342 },
                new Coin { Id = "tether", Symbol = "usdt", Name = "Tether", Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1668148663", CurrentPrice = 1, MarketCap = 65745622287 },
                new Coin { Id = "binancecoin", Symbol = "bnb", Name = "BNB", Image = "https://assets.coingecko.com/coins/images/825/large/bnb-icon2_2x.png?1644979850", CurrentPrice = 277, MarketCap = 45293892416 },
                new Coin { Id = "usd-coin", Symbol = "usdc", Name = "USD Coin", Image = "https://assets.coingecko.com/coins/images/6319/large/USD_Coin_icon.png?1547042389", CurrentPrice = 1, MarketCap = 42516855166 }
            };

            return coins;
        }
    }
}
