﻿using Newtonsoft.Json;
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

        public async Task<List<CoinMarket>> GetCoinMarkets()
        {
            List<CoinMarket> markets = null;

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
                            markets = JsonConvert.DeserializeObject<List<CoinMarket>>(responseContent);
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

        public async Task<List<CoinMarket>> GetCoinMarkets(string targetCurrency, int perPage, bool sparkline)
        {
            List <CoinMarket> markets = null;

            //Imitation loading
            Task.Delay(2000).Wait();

            var uri = baseUri + "/coins/markets?vs_currency="
                + targetCurrency.ToLower() + "&order=market_cap_desc&per_page="
                + perPage + "&sparkline=" + sparkline.ToString().ToLower()
                + "&price_change_percentage=1h%2C24h%2C7d";

            try
            {
                using (var response = await _httpClient.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            markets = JsonConvert.DeserializeObject<List<CoinMarket>>(responseContent);
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

        public async Task<CoinByIdFullData> GetCoinById(string id)
        {
            //Imitation loading
            Task.Delay(1000).Wait();

            var coin = new CoinByIdFullData();

            var uri = baseUri + "/coins/" + id
                + "?localization=false&tickers=false&community_data=false&developer_data=false";

            try
            {
                using (var response = await _httpClient.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            coin = JsonConvert.DeserializeObject<CoinByIdFullData>(responseContent);
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

            return coin;
        }
    }
}
