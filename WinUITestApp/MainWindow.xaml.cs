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
        private readonly ILocalizationService _localizationService;
        private readonly IThemeSelectorService _themeSelectorService;

        public MainWindow()
        {
            InitializeComponent();

            _localizationService = App.Current.Services.GetService<ILocalizationService>();
            _localizationService.InitializeAsync().ConfigureAwait(false);

            _themeSelectorService = App.Current.Services.GetService<IThemeSelectorService>();

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

        async void MainNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            SetCurrentNavigationViewItem("Market", null);

            await _themeSelectorService.InitializeAsync();
            await _themeSelectorService.SetRequestedThemeAsync();
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
