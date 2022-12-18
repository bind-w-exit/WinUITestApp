using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels;

public partial class CoinViewModel : BaseViewModel
{
    private readonly ICryptoApiService _cryptoApiService;

    [ObservableProperty]
    private CoinByIdFullData coin;

    [ObservableProperty]
    private string nameAndSymbol;

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    private bool isErrorMessageOpen;

    public CoinViewModel(ICryptoApiService cryptoApiService)
    {
        _cryptoApiService = cryptoApiService;
    }

    [RelayCommand]
    private async Task UpdateCoinAsync(string id)
    {
        IsErrorMessageOpen = false;
        try
        {
            Coin = await Task.Run(() => _cryptoApiService.GetCoinById(id));

        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            IsErrorMessageOpen = true;
        }
    }

    partial void OnCoinChanged(CoinByIdFullData value)
    {
        NameAndSymbol = string.Format("{0} ({1})", value.Name, value.Symbol.ToUpper());
    }
}
