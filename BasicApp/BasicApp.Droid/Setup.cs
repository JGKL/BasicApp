using Android.Content;
using BasicApp.Business.ViewModels;
using BasicApp.Droid.Utilities.Helpers;
using BasicApp.Droid.Utilities.Presenter;
using BasicApp.Droid.Services;
using BasicApp.Droid.Views.Home;
using BasicApp.Interfaces;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using System.Linq;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.AppCompat;

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
            Mvx.IoCProvider.RegisterSingleton<IFileLocationService>(new FileLocationService());
            Mvx.IoCProvider.RegisterSingleton<ISQLitePlatform>(new SQLitePlatformAndroid());
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = Mvx.IoCProvider.IoCConstruct<CustomPresenter>();
            Mvx.IoCProvider.RegisterSingleton<IMvxAndroidViewPresenter>(presenter);
            return presenter;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
        }

        protected override void InitializeViewLookup()
        {
            var viewModelViewLookup = new Dictionary<Type, Type>();
            var views = typeof(HomeView).Assembly.GetExportedTypes().Where(x => x.Name.EndsWith("View", StringComparison.CurrentCulture)).ToList();
            var viewModels = typeof(HomeViewModel).Assembly.GetExportedTypes().Where(x => x.Name.EndsWith("ViewModel", StringComparison.CurrentCulture)).ToList();

            foreach (var viewModel in viewModels)
            {
                Type view;

                if (ApplicationContext.Resources.GetBoolean(Resource.Boolean.IsTablet))
                {
                    view = views.FirstOrDefault(x => x.Name.Replace("TabletView", "") == viewModel.Name.Replace("ViewModel", ""));
                    if (view != null)
                    {
                        viewModelViewLookup.Add(viewModel, view);
                        continue;
                    }
                }

                view = views.FirstOrDefault(x => x.Name.Replace("View", "") == viewModel.Name.Replace("ViewModel", ""));
                if (view != null)
                    viewModelViewLookup.Add(viewModel, view);
            }

            var container = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
            container.AddAll(viewModelViewLookup);
        }
    }
}