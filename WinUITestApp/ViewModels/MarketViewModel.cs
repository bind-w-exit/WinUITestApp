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

        public MarketViewModel()
        {
            Coins = CoinGeckoApiService.GetMarkets();
        }
    }
}
