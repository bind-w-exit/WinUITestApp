using Microsoft.UI.Xaml.Controls;

namespace WinUITestApp.Services;

public interface INavigationService
{
    bool CanGoBack { get; }
    Frame ContentFrame { get; set; }

    bool NavigateTo(string pageKey, object parameter = null);
    bool GoBack();
}
