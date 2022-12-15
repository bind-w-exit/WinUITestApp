using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        readonly ICryptoApiService _cryptoApiService;

        [ObservableProperty]
        private List<Coin> coins;

        [ObservableProperty]
        private string selectedCurrency;

        public readonly List<string> Currencies = new() { "USD", "ETH", "EUR", "JPY" };

        [ObservableProperty]
        private int selectedFilter;

        public readonly List<int> Filters = new() { 10, 50, 100, 250 };

        [ObservableProperty]
        private string selectedTimeframe;

        public readonly List<string> Timeframes = new() { "1H", "24H", "7D", "1Y" };

        [ObservableProperty]
        private string selectedSort;

        public readonly List<string> SortBy = new() { "Rank", "Market Cap", "% Change", "Price" };

        public MarketViewModel(ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;    
            
            SelectedCurrency = Currencies[0];
            SelectedFilter = Filters[1];
            SelectedTimeframe = Timeframes[2];
            SelectedSort = SortBy[1];
        }

        [RelayCommand]
        private async Task UpdateCoinsAsync()
        {
            var res = await Task.Run(_cryptoApiService.GetCoins);

            // Default binding mode in GridView is OneTime or what? ＞︿＜
            Coins = res;
        }
    }
}
