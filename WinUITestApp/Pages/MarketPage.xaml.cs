using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using WinUITestApp.ViewModels;

namespace WinUITestApp.Pages;

public sealed partial class MarketPage : Page
{
    public MarketViewModel ViewModel { get; }
    public MarketPage()
    {
        InitializeComponent();
        ViewModel = App.Current.Services.GetService<MarketViewModel>();           
    }
}
