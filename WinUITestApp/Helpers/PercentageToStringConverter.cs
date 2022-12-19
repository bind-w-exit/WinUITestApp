using Microsoft.UI.Xaml.Data;
using System;

namespace WinUITestApp.Helpers;

public class PercentageToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var percentage = value as double?;
        percentage = percentage / 100;
        var res = percentage?.ToString("P2");

        return res;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
