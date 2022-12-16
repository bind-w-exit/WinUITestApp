using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using WinUITestApp.ViewModels;

namespace WinUITestApp.Pages
{
    public sealed partial class CoinPage : Page
    {
        public CoinViewModel ViewModel { get; }
        public CoinPage()
        {
            InitializeComponent();
            ViewModel = App.Current.Services.GetService<CoinViewModel>();
        }
    }
}
