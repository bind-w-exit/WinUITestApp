using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Pages;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels;

public partial class MarketViewModel : BaseViewModel
{
    private readonly ICryptoApiService _cryptoApiService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private List<CoinMarket> markets;
    private List<CoinMarket> notFilteredMarkets;

    [ObservableProperty]
    private CoinMarket selectedMarket;

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

    public readonly List<string> SortBy = new() {"Rank", "Name", "Market Cap", "% Change", "Price" };

    [ObservableProperty]
    private string selectedSort;

    // TODO: implamend timeframes in UI
    public readonly List<string> Timeframes = new() { "1H", "24H", "7D" };

    [ObservableProperty]
    private string selectedTimeframe;

    [ObservableProperty]
    private string searchField;

    [ObservableProperty]
    private bool isUpdateMarketsFailad;

    [ObservableProperty]
    private bool isUpdateMarketsRunning;

    public MarketViewModel(ICryptoApiService cryptoApiService, INavigationService navigationService)
    {
        _cryptoApiService = cryptoApiService;    
        _navigationService = navigationService;

        selectedCurrency = "USD";
        selectedPerPage = PerPage[1];
        selectedSort = SortBy[2];
        selectedTimeframe = Timeframes[1];
        searchField = "";
        isUpdateMarketsFailad = false;

        UpdateMarketsCommand.Execute(null);
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

    [RelayCommand]
    private async Task UpdateMarketsAsync()
    {
        IsUpdateMarketsRunning = true;
        IsUpdateMarketsFailad = false;
        try
        {
            notFilteredMarkets = await Task.Run(() => _cryptoApiService.GetCoinMarkets(selectedCurrency, selectedPerPage, false));
            Markets = FilterAndSortMarkets(notFilteredMarkets, SearchField, SelectedSort);
            IsUpdateMarketsRunning = false;
        }
        catch (Exception)
        {
            IsUpdateMarketsFailad = true;
        }
    }

    partial void OnSelectedSortChanged(string value)
    {
        Markets = SortMarkets(Markets, value);
    }

    partial void OnSearchFieldChanged(string value)
    {
        Markets = FilterAndSortMarkets(notFilteredMarkets, value, SelectedSort);
    }

    partial void OnSelectedMarketChanged(CoinMarket value)
    {
        if (SelectedMarket != null)
        {
            _navigationService.NavigateTo(nameof(CoinPage), value.Id);
            SelectedMarket = null;  // TODO: Item navigation based on tapped 🙈
        }
    }

    static List<CoinMarket> FilterAndSortMarkets(List<CoinMarket> markets, string filter, string sort)
    {
        return SortMarkets(FilterMarkets(markets, filter), sort);
    }

    static List<CoinMarket> FilterMarkets(List<CoinMarket> markets, string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            return markets;             
        }
        else
        {
            return markets?.Where(coin => coin.Name.ToLower().Contains(filter.ToLower())
                || coin.Symbol.ToLower().Contains(filter.ToLower())).ToList();
        }
    }

    static List<CoinMarket> SortMarkets(List<CoinMarket> markets, string sort)
    {
        switch (sort)
        {
            case "Rank":
                return markets.OrderBy(coin => coin.MarketCapRank).ToList();

            case "Name":
                return markets.OrderBy(coin => coin.Name).ToList();

            case "Market Cap":
                return markets.OrderByDescending(coin => coin.MarketCap).ToList();

            case "% Change":
                return markets.OrderByDescending(coin => coin.PriceChangePercentage24H).ToList();
                
            case "Price":
                return markets.OrderByDescending(coin => coin.CurrentPrice).ToList();

            default:
                return markets;
        }
    }
}