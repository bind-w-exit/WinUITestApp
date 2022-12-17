using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WinUITestApp.Models;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var coin = e.Parameter as string;
            //if (coin != null)
            //{
            //    ViewModel.Coin = coin;
            //}

            base.OnNavigatedTo(e);
        }
    }
}
