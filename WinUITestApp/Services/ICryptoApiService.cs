using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;

namespace WinUITestApp.Services
{
    public interface ICryptoApiService
    {
        public Task<List<Market>> GetMarkets();
    }
}
