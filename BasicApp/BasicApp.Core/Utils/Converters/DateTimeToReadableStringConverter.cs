using System;
using System.Linq;
using System.Globalization;
using MvvmCross.Converters;

namespace BasicApp.Core.Utils.Converters
{
    public class DateTimeToReadableStringConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: use parameter instead
            culture = new CultureInfo("nl-NL");

            var readableDate = value.ToString("dddd, dd MMMM yyyy", culture);
            return readableDate.First().ToString().ToUpper() + readableDate.Substring(1);
        }
    }
}
