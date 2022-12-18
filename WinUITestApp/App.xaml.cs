using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Net.Http;
using WinUITestApp.Services;
using WinUITestApp.ViewModels;

namespace WinUITestApp;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    public static Window MainWindow { get; private set; }

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider Services { get; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        Services = ConfigureServices();

        InitializeComponent();
    }

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        MainWindow = new MainWindow();
        MainWindow.Activate();
    }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Viewmodels
        services.AddScoped<MarketViewModel>();
        services.AddScoped<SettingsViewModel>();
        services.AddTransient<CoinViewModel>();

        // Services
        HttpClient httpClient = new HttpClient();
        services.AddSingleton<ICryptoApiService>(new CoinGeckoApiService(httpClient));
        services.AddSingleton<INavigationService>(new NavigationService());
        services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
        services.AddSingleton<ILocalizationService, LocalizationService>();
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();

        return services.BuildServiceProvider();
    }

}
