using System;
using Acr.UserDialogs;
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace BasicApp.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen)
        {

        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            UserDialogs.Init(this);

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

            switch (Resources.DisplayMetrics.DensityDpi)
            {
                case Android.Util.DisplayMetricsDensity.Low:
                    Console.WriteLine("LDPI");
                    break;
                case Android.Util.DisplayMetricsDensity.Medium:
                    Console.WriteLine("MDPI");
                    break;
                case Android.Util.DisplayMetricsDensity.High:
                    Console.WriteLine("HDPI");
                    break;
                case Android.Util.DisplayMetricsDensity.Xhigh:
                    Console.WriteLine("XHDPI");
                    break;
                case Android.Util.DisplayMetricsDensity.Xxhigh:
                    Console.WriteLine("XXHDPI");
                    break;
                case Android.Util.DisplayMetricsDensity.Xxxhigh:
                    Console.WriteLine("XXXHDPI");
                    break;
            }
        }
    }
}