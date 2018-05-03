using Android.Graphics.Drawables;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Droid.Platform;
using Plugin.Iconize.Droid.Controls;
using System;
using System.Globalization;

namespace BasicApp.Droid.Utilities.Converters
{
    public class IconConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            return new IconDrawable(topActivity.Activity, value);
        }
    }
}