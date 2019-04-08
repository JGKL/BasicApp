using System;
using System.Globalization;
using MvvmCross.Converters;

namespace BasicApp.Droid.Utilities.Converters
{
    public class DateTimeToDayNumberConverter : MvxValueConverter<DateTime, int>
    {
        protected override int Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Day;
        }
    }
}