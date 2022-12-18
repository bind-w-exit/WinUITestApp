using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WinUITestApp.ViewModels;

namespace WinUITestApp.Pages;

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
        var id = e.Parameter as string;
        if (id != null)
        {
            ViewModel.UpdateCoinCommand.Execute(id);
        }

        base.OnNavigatedTo(e);
    }
}
