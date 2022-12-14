using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        TaskFactory uiFactory;
        ICryptoApiService _cryptoApiService;

        [ObservableProperty]
        bool isUpdating;

        [ObservableProperty]
        private List<Coin> coins;

        [ObservableProperty]
        private string selectedCurrency;

        public readonly List<string> Currencies = new List<string> { "USD", "ETH", "EUR", "JPY" };

        [ObservableProperty]
        private int selectedFilter;

        public readonly List<int> Filters = new List<int> { 10, 50, 100, 250 };

        [ObservableProperty]
        private string selectedTimeframe;

        public readonly List<string> Timeframes = new List<string> { "1H", "24H", "7D", "1Y" };

        [ObservableProperty]
        private string selectedSort;

        public readonly List<string> SortBy = new List<string> { "Rank", "Market Cap", "% Change", "Price" };

        public MarketViewModel(ICryptoApiService cryptoApiService)
        {
            //var s = Environment.CurrentManagedThreadId;
            _cryptoApiService = cryptoApiService;    
            uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
            IsUpdating = true;
            Task.Run(UpdateCoinsAsync);    
            
            SelectedCurrency = Currencies[0];
            SelectedFilter = Filters[1];
            SelectedTimeframe = Timeframes[2];
            SelectedSort = SortBy[1];
        }

        async Task UpdateCoinsAsync()
        {
            //var s = Environment.CurrentManagedThreadId;
            var res = await _cryptoApiService.GetCoins();

            // Update property in UI Theard (*>﹏<*)
            // Default binding mode in GridView is OneTime or what? ＞︿＜
            await uiFactory.StartNew(() => {
                Coins = res;
                IsUpdating = false;
                //var s = Environment.CurrentManagedThreadId;
            });
        }
    }
}
