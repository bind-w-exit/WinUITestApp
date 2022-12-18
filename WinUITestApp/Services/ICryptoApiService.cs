using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;

namespace WinUITestApp.Services;

public interface ICryptoApiService
{
    public Task<List<CoinMarket>> GetCoinMarkets();
    public Task<List<CoinMarket>> GetCoinMarkets(string targetCurrency, int perPage, bool sparkline);
    public Task<CoinByIdFullData> GetCoinById(string id);
}
