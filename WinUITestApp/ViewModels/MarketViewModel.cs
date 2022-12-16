using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Pages;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        private readonly ICryptoApiService _cryptoApiService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private List<Market> markets;
        private List<Market> notFilteredMarkets;

        [ObservableProperty]
        private Market selectedMarket;

        public readonly List<string> Currencies = new() 
        {
            "AED",
            "ARS",
            "AUD",
            "BCH",
            "BDT",
            "BHD",
            "BMD",
            "BNB",
            "BRL",
            "BTC",
            "CAD",
            "CHF",
            "CLP",
            "CNY",
            "CZK",
            "DKK",
            "DOT",
            "EOS",
            "ETH",
            "EUR",
            "GBP",
            "HKD",
            "HUF",
            "IDR",
            "ILS",
            "INR",
            "JPY",
            "KRW",
            "KWD",
            "LKR",
            "LTC",
            "MMK",
            "MXN",
            "MYR",
            "NGN",
            "NOK",
            "NZD",
            "PHP",
            "PKR",
            "PLN",
            "RUB",
            "SAR",
            "SEK",
            "SGD",
            "THB",
            "TRY",
            "TWD",
            "UAH",
            "USD",
            "VEF",
            "VND",
            "XAG",
            "XAU",
            "XDR",
            "XLM",
            "XRP",
            "YFI",
            "ZAR",
            "BITS",
            "LINK",
            "SATS"
        };

        [ObservableProperty]
        private string selectedCurrency;

        public readonly List<int> PerPage = new() { 10, 50, 100, 250 };

        [ObservableProperty]
        private int selectedPerPage;

        public readonly List<string> SortBy = new() {"Name", "Market Cap", "% Change", "Price" };

        [ObservableProperty]
        private string selectedSort;

        // TODO: implamend timeframes in UI
        public readonly List<string> Timeframes = new() { "1H", "24H", "7D" };

        [ObservableProperty]
        private string selectedTimeframe;

        [ObservableProperty]
        private string searchField;

        public MarketViewModel(ICryptoApiService cryptoApiService, INavigationService navigationService)
        {
            _cryptoApiService = cryptoApiService;    
            _navigationService = navigationService;

            selectedCurrency = "USD";
            selectedPerPage = PerPage[1];
            selectedSort = SortBy[1];
            selectedTimeframe = Timeframes[1];
            searchField = "";

            UpdateMarketsCommand.Execute(null);
        }

        [RelayCommand]
        private async Task UpdateMarketsAsync()
        {
            var res = await Task.Run(() => _cryptoApiService.GetMarkets(selectedCurrency, selectedPerPage, false));

            if (res != null)
            {
                // Default binding mode in GridView is OneTime or what? ＞︿＜
                notFilteredMarkets = res;
                SortMarkets(SearchFilter(SearchField)); // TODO: func refactoring 🥲
            }
        }

        partial void OnSelectedPerPageChanged(int value)
        {
            if (UpdateMarketsCommand.CanExecute(null))
            {
                UpdateMarketsCommand.Execute(null);
            }
        }

        partial void OnSelectedCurrencyChanged(string value)
        {
            if (UpdateMarketsCommand.CanExecute(null))
            {
                UpdateMarketsCommand.Execute(null);
            }
        }

        partial void OnSelectedSortChanged(string value)
        {
            SortMarkets(Markets);
        }

        partial void OnSelectedMarketChanged(Market value)
        {
            if(SelectedMarket != null)
            {
                _navigationService.NavigateTo(nameof(CoinPage), value);
                SelectedMarket = null;  // TODO: Item navigation based on tapped 🙈
            }             
        }

        partial void OnSearchFieldChanged(string value)
        {
            SortMarkets(SearchFilter(value));
        }

        List<Market> SearchFilter(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return notFilteredMarkets;             
            }
            else
            {
                return notFilteredMarkets?.Where(coin => coin.Name.ToLower().Contains(value.ToLower())
                    || coin.Symbol.ToLower().Contains(value.ToLower())).ToList();
            }
        }
            
        void SortMarkets(List<Market> mar)
        {
            switch (SelectedSort)
            {
                case "Name":
                    Markets = mar.OrderBy(coin => coin.Name).ToList();
                    break;

                case "Market Cap":
                    Markets = mar.OrderByDescending(coin => coin.MarketCap).ToList();
                    break;

                case "% Change":
                    Markets = mar.OrderBy(coin => coin.MarketCapRank).ToList();
                    break;

                case "Price":
                    Markets = mar.OrderBy(coin => coin.CurrentPrice).ToList();
                    break;

                default:
                    break;
            }
        }
    }
}