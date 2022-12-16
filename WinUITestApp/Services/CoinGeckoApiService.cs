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

        public CoinGeckoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Market>> GetMarkets()
        {
            List<Market> markets = null;

            //Imitation loading
            Task.Delay(3000).Wait();

            var uri = baseUri +
                "/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=50";

            try
            {
                using (var response = await _httpClient.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            markets = JsonConvert.DeserializeObject<List<Market>>(responseContent);
                        }
                        //TODO: catch exception
                        catch (Exception)
                        {
                            //throw new HttpRequestException(e.Message);
                        }
                    }
                    //TODO: catch exception
                    else
                    {
                        //throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            //TODO: catch exception
            catch (Exception)
            {
                //throw;
            }

            return markets;
        }

        public async Task<List<Market>> GetMarkets(string targetCurrency, int perPage, bool sparkline)
        {
            List <Market> markets = null;

            //Imitation loading
            Task.Delay(2000).Wait();

            var uri = baseUri + "/coins/markets?vs_currency="
                + targetCurrency.ToLower() + "&order=market_cap_desc&per_page="
                + perPage + "&sparkline=" + sparkline.ToString().ToLower();

            try
            {
                using (var response = await _httpClient.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            markets = JsonConvert.DeserializeObject<List<Market>>(responseContent);
                        }
                        //TODO: catch exception
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        //TODO: catch exception
                        //throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            //TODO: catch exception
            catch (Exception)
            {
                //throw;
            }

            return markets;
        }
    }
}
