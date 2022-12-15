using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WinUITestApp.Models;

namespace WinUITestApp.Services
{
    public class CoinGeckoApiService : ICryptoApiService
    {
        private HttpClient _httpClient;
        private const string baseUri = "https://api.coingecko.com/api/v3";

        public async Task<List<Coin>> GetCoins()
        {
            //Imitation loading
            Task.Delay(5000).Wait();

            var response = await _httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            try
            {
                var res =  JsonConvert.DeserializeObject<List<Coin>>(responseContent);
                return res;
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        public CoinGeckoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
