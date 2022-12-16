using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;

namespace WinUITestApp.Services
{
    public interface ICryptoApiService
    {
        public Task<List<CoinMarket>> GetMarkets();
        public Task<List<CoinMarket>> GetMarkets(string targetCurrency, int perPage, bool sparkline);
    }
}
