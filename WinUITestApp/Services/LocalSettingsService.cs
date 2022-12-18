﻿using System.Threading.Tasks;
using Windows.Storage;
using WinUITestApp.Helpers;

namespace WinUITestApp.Services;

public class LocalSettingsService : ILocalSettingsService
{
    public LocalSettingsService() { }

    public async Task<T> ReadSettingAsync<T>(string key)
    {
        if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out var obj))
        {
            return await Json.ToObjectAsync<T>((string)obj);
        }

        return default;
    }

    public async Task SaveSettingAsync<T>(string key, T value)
    {
        ApplicationData.Current.LocalSettings.Values[key] = await Json.StringifyAsync(value);
    }
}
