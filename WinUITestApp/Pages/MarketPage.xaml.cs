using Microsoft.UI.Xaml.Controls;
using WinUITestApp.ViewModels;

namespace WinUITestApp.Pages
{
    public sealed partial class MarketPage : Page
    {
        public MarketViewModel ViewModel { get; }
        public MarketPage()
        {
            //TODO: ViewModel = App.GetService<MainViewModel>();
            ViewModel = new MarketViewModel();
            InitializeComponent();
        }
    }
}
