using Microsoft.UI.Xaml.Controls;
using System;

namespace WinUITestApp.Services;

public class NavigationService : INavigationService
{
    public bool CanGoBack => ContentFrame != null && ContentFrame.CanGoBack;

    public Frame ContentFrame { get; set; }

    public bool GoBack()
    {
        if (CanGoBack)
        {
            ContentFrame.GoBack();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool NavigateTo(string pageKey, object parameter = null)
    {
        if (pageKey == null)
            return false;
        else
        {
            ContentFrame.Navigate(Type.GetType($"WinUITestApp.Pages.{pageKey}"), parameter);
            return true;
        }
    }

}
