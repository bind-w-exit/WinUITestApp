using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using WinUITestApp.Helpers;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private readonly IThemeSelectorService _themeSelectorService;
    private readonly ILocalizationService _localizationService;

    [ObservableProperty]
    private ElementTheme elementTheme;

    [ObservableProperty]
    private string versionDescription;

    [ObservableProperty]
    private LanguageItem selectedLanguage;

    [ObservableProperty]
    private bool isLocalizationChanged;

    [ObservableProperty]
    private List<LanguageItem> availableLanguages;

    public SettingsViewModel(ILocalizationService localizationService, IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _localizationService = localizationService;
        AvailableLanguages = _localizationService.Languages;
        SelectedLanguage = _localizationService.GetCurrentLanguageItem();
        IsLocalizationChanged = false;

        elementTheme = _themeSelectorService.Theme;
        versionDescription = GetVersionDescription();
    }

    [RelayCommand]
    public async Task SetTheme(ElementTheme param)
    {
        if (ElementTheme != param)
        {
            ElementTheme = param;
            await _themeSelectorService.SetThemeAsync(param);
        }
    }
    private static string GetVersionDescription()
    {
        Version version;

        var packageVersion = Package.Current.Id.Version;

        version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }

    partial void OnSelectedLanguageChanged(LanguageItem value)
    {
        _localizationService.SetLanguageAsync(value);
        IsLocalizationChanged = true;
    }
}
