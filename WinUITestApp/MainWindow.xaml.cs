// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
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
            this.InitializeComponent();

            MainNavigationView.Loaded += MainNavigationView_Loaded;
            MainNavigationView.ItemInvoked += MainNavigationView_ItemInvoked;
        }

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
    }
}
