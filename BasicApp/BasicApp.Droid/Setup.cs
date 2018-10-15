using Android.Content;
using Android.Widget;
using BasicApp.Business.ViewModels;
using BasicApp.Droid.Services;
using BasicApp.Droid.Utilities.Helpers;
using BasicApp.Droid.Utilities.Presenter;
using BasicApp.Droid.Views.Home;
using BasicApp.Interfaces;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.RegisterSingleton<IFragmentTypeLookup>(new FragmentTypeLookup());
            //Mvx.RegisterSingleton<IMessageService>(new MessageService());
            //Mvx.RegisterSingleton<IPlatformInfo>(new PlatformInfo());
            Mvx.RegisterSingleton<IFileLocationService>(new FileLocationService());
            Mvx.RegisterSingleton<ISQLitePlatform>(new SQLitePlatformAndroid());
            //Mvx.RegisterSingleton<IFileLocation>(new FileLocation());
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = Mvx.IocConstruct<CustomPresenter>();
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(presenter);
            return presenter;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            //registry.RegisterFactory(new MvxCustomBindingFactory<RadioGroup>("SelectedIndex", (radioGroup) => new CustomRadioGroupSelectedIndexBinding(radioGroup)));
        }

        protected override void InitializeViewLookup()
        {
            var viewModelViewLookup = new Dictionary<Type, Type>();
            var views = typeof(HomeView).Assembly.GetExportedTypes().Where(x => x.Name.EndsWith("View", StringComparison.CurrentCulture)).ToList();
            var viewModels = typeof(LoginViewModel).Assembly.GetExportedTypes().Where(x => x.Name.EndsWith("ViewModel", StringComparison.CurrentCulture)).ToList();

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

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(viewModelViewLookup);
        }
    }
}