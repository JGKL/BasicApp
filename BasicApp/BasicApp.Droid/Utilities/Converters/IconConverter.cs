using Android.Graphics.Drawables;
using Android.Support.V4.Content;
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

            var charValue = default(char);
            var size = 0;
            switch (value)
            {
                case "running":
                    charValue = '\xf70c';
                    size = 30;
                    break;
                case "distance":
                    charValue = '\xf018';
                    size = 10;
                    break;
                case "time":
                    size = 10;
                    charValue = '\xf2f2';
                    break;
            }

            var drawable = new IconDrawable(topActivity.Activity, charValue, FontModule.FontAwesomeSolid)?.Color(ContextCompat.GetColor(topActivity.Activity, Resource.Color.black)).SizeDp(size);
            return drawable;
        }
    }
}