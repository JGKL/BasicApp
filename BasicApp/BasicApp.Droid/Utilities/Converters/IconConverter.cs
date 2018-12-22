using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;
using Plugin.Iconize.Droid.Controls;
using System;
using System.Globalization;

namespace BasicApp.Droid.Utilities.Converters
{
    public class IconConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            return new IconDrawable(topActivity.Activity, value);
        }
    }
}