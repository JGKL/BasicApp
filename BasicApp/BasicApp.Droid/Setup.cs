using BasicApp.Droid.Utilities.Helpers;
using BasicApp.Droid.Services;
using BasicApp.Interfaces;
using MvvmCross;
using MvvmCross.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.IoC;

namespace BasicApp.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IFragmentTypeLookup>(new FragmentTypeLookup());
            Mvx.IoCProvider.RegisterSingleton<IFileLocationService>(new FileLocationService());
        }

        /**
         * See: https://github.com/MvvmCross/MvvmCross/issues/3572
         */
        protected override void RegisterDefaultSetupDependencies(IMvxIoCProvider iocProvider)
        {
            var nameMappingStrategy = CreateViewToViewModelNaming();
            Mvx.IoCProvider.RegisterSingleton(nameMappingStrategy);

            base.RegisterDefaultSetupDependencies(iocProvider);
        }
    }
}