using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class CoinViewModel : BaseViewModel
    {
        private readonly ICryptoApiService _cryptoApiService;

        [ObservableProperty]
        private CoinByIdFullData coin;

        public CoinViewModel(ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;
        }

        [RelayCommand]
        private async Task UpdateCoinAsync(string id)
        {
            Coin = await Task.Run(() => _cryptoApiService.GetCoinById(id));
        }
    }
}
