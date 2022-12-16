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
        private readonly ICryptoApiService _cryptoApiService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private List<Market> markets;

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

        public MarketViewModel(ICryptoApiService cryptoApiService, INavigationService navigationService)
        {
            _cryptoApiService = cryptoApiService;    
            _navigationService = navigationService;

            selectedCurrency = "USD";
            selectedPerPage = PerPage[1];
            selectedSort = SortBy[1];
        }

        [RelayCommand]
        private async Task UpdateMarketsAsync()
        {
            var res = await Task.Run(() => _cryptoApiService.GetMarkets(selectedCurrency, selectedPerPage, false));

            if(res != null)
            {
                // Default binding mode in GridView is OneTime or what? ＞︿＜
                Markets = res;
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
            // TODO: Sort markets
        }

        [RelayCommand]
        private void ItemClicked(Market selectedItem = null)
        {
            _navigationService.NavigateTo("CoinPage", selectedItem);
        }
    }
}