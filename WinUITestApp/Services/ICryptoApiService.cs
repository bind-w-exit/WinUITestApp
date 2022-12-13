using System.Collections.Generic;
using WinUITestApp.Models;

namespace WinUITestApp.Services
{
    public interface ICryptoApiService
    {
        public List<Coin> GetCoins();
    }
}
