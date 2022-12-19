using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WinUITestApp.Models;

namespace WinUITestApp.Services;

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

        var uri = baseUri +
            "/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=50";

        using (var response = await _httpClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    markets = JsonConvert.DeserializeObject<List<CoinMarket>>(responseContent);
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException(ex.Message);
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        return markets;
    }

    public async Task<List<CoinMarket>> GetCoinMarkets(string targetCurrency, int perPage, bool sparkline)
    {
        List <CoinMarket> markets = null;

        var uri = baseUri + "/coins/markets?vs_currency="
            + targetCurrency.ToLower() + "&order=market_cap_desc&per_page="
            + perPage + "&sparkline=" + sparkline.ToString().ToLower()
            + "&price_change_percentage=1h%2C24h%2C7d";

        using (var response = await _httpClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    markets = JsonConvert.DeserializeObject<List<CoinMarket>>(responseContent);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        return markets;
    }

    public async Task<CoinByIdFullData> GetCoinById(string id)
    {
        var coin = new CoinByIdFullData();

        var uri = baseUri + "/coins/" + id
            + "?localization=false&tickers=false&community_data=false&developer_data=false&sparkline=true";

        using (var response = await _httpClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    coin = JsonConvert.DeserializeObject<CoinByIdFullData>(responseContent);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        return coin;
    }
}
