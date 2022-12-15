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
        private readonly HttpClient _httpClient;
        private const string baseUri = "https://api.coingecko.com/api/v3";

        public async Task<List<Market>> GetMarkets()
        {
            //Imitation loading
            Task.Delay(3000).Wait();

            using (var response = await _httpClient.GetAsync(baseUri + "/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=50"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var markets = JsonConvert.DeserializeObject<List<Market>>(responseContent);
                        return markets;
                    }
                    catch (Exception e)
                    {
                        throw new HttpRequestException(e.Message);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public CoinGeckoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
