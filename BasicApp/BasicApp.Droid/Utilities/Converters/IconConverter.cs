using Android.Graphics.Drawables;
using BasicApp.Core.Business.Enum;
using BasicApp.Droid.Utilities.FontAwesome;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;
using System;
using System.Globalization;

namespace BasicApp.Droid.Utilities.Converters
{
    public class IconConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            return new IconDrawable(topActivity.Activity, '\uf2b9', FontAwesomeModule.Regular);
        }
    }
}