using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using WinUITestApp.Services;

// References:
// 1. https://github.com/goh-chunlin/Lunar.WinUI3Playground.

namespace WinUITestApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var navigationService = App.Current.Services.GetService<INavigationService>();
            navigationService.ContentFrame = ContentFrame;

            MainNavigationView.Loaded += MainNavigationView_Loaded;
            MainNavigationView.ItemInvoked += MainNavigationView_ItemInvoked;
        }

        // TODO: MVVM Navigation
        #region Navigation

        public void SetCurrentNavigationViewItem(string menuItemTag, object parameter)
        {
            var selectedMenuItem = MainNavigationView.MenuItems
                .Cast<NavigationViewItem>()
                .FirstOrDefault(i => (string)i.Tag == menuItemTag);

            if (selectedMenuItem != null)
            {
                SetCurrentNavigationViewItem(selectedMenuItem, parameter);
            }
        }

        public void SetCurrentNavigationViewItem(NavigationViewItem item, object parameter)
        {
            if (item == null || item.Tag == null) return;

            ContentFrame.Navigate(Type.GetType($"WinUITestApp.Pages.{item.Tag}Page"), parameter);
            MainNavigationView.Header = item.Content;
            MainNavigationView.SelectedItem = item;
        }

        void MainNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            SetCurrentNavigationViewItem((NavigationViewItem)sender.SelectedItem, null);
        }

        void MainNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            SetCurrentNavigationViewItem("Market", null);
        }

        void MainNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }

        #endregion Navigation
    }
}
