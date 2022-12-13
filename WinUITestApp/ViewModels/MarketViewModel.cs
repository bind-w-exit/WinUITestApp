using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<Coin> coins;

        private ICryptoApiService _cryptoApiService;

        public MarketViewModel(ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;
            Coins = _cryptoApiService.GetCoins();
        }
    }
}
