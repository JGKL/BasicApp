using BasicApp.Droid.Utilities.Helpers;
using BasicApp.Droid.Services;
using BasicApp.Interfaces;
using MvvmCross;
using MvvmCross.ViewModels;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using MvvmCross.Droid.Support.V7.AppCompat;
using BasicApp.Core.Interfaces;

namespace BasicApp.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.RegisterSingleton<IFragmentTypeLookup>(new FragmentTypeLookup());
            Mvx.IoCProvider.RegisterSingleton<ISQLitePlatform>(new SQLitePlatformAndroid());
            Mvx.IoCProvider.RegisterSingleton<IFileLocationService>(new FileLocationService());
            Mvx.IoCProvider.RegisterSingleton<IPlatformInformation>(new PlatformInformation());
        }
    }
}