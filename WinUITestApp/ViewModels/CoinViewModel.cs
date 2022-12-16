using CommunityToolkit.Mvvm.ComponentModel;
using WinUITestApp.Models;

namespace WinUITestApp.ViewModels
{
    public partial class CoinViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Coin coin;
    }
}
