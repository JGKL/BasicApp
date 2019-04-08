using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Android.Support.Transitions;
using BasicApp.Droid.Utilities.Helpers;
using BasicApp.Droid.Views.Historie;
using BasicApp.Droid.Views.Training;
using MvvmCross;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;

namespace BasicApp.Droid.Utilities.Presenter
{
    public class CustomPresenter : MvxAndroidViewPresenter
    {
        private readonly IFragmentTypeLookup _fragmentTypeLookup;
        private Android.Support.V4.App.FragmentManager _fragmentManager;

        public CustomPresenter() : base(new List<Assembly>())
        {
            _fragmentTypeLookup = Mvx.IoCProvider.Resolve<IFragmentTypeLookup>();
        }

        private IMvxViewModelLoader _viewModelLoader;
        private IMvxViewModelLoader ViewModelLoader
        {
            get
            {
                if (_viewModelLoader == null)
                    _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();

                return _viewModelLoader;
            }
        }

        public void RegisterFragmentManager(Android.Support.V4.App.FragmentManager fragmentManager, Type viewModelType)
        {
            _fragmentManager = fragmentManager;

            _fragmentTypeLookup.TryGetFragmentType(viewModelType, out Type fragmentType);
            var viewModelRequest = new MvxViewModelRequest(viewModelType, null, null);
            ShowFragment(fragmentType, viewModelRequest, false);
        }

        public override Task<bool> Show(MvxViewModelRequest request)
        {
            if (IsFragmentManagerLoaded() && !IsViewModelTypeAnActivity(request, out Type fragmentType))
            {
                ShowFragment(fragmentType, request, true);
                return Task.FromResult(true);
            }

            return base.Show(request);
        }

        private bool IsFragmentManagerLoaded()
        {
            return _fragmentManager != null;
        }

        private bool IsViewModelTypeAnActivity(MvxViewModelRequest request, out Type fragmentType)
        {
            return !_fragmentTypeLookup.TryGetFragmentType(request.ViewModelType, out fragmentType);
        }

        private void ShowFragment(Type fragmentType, MvxViewModelRequest request, bool addToBackStack)
        {
            var fragment = (MvxFragment)Activator.CreateInstance(fragmentType);
            fragment.ViewModel = ViewModelLoader.LoadViewModel(request, null);

            var transaction = _fragmentManager.BeginTransaction();

            if (addToBackStack)
                transaction.AddToBackStack(fragment.GetType().Name);

            if (fragment.GetType() == typeof(HistorieView))
            {
                fragment.ExitTransition = new Explode();
            }

            //transaction.SetCustomAnimations(Resource.Layout.enter_from_right, Resource.Layout.exit_to_right);

            transaction.Replace(Resource.Id.contentFrame, fragment).Commit();
        }

        public override Task<bool> Close(IMvxViewModel viewModel)
        {
            if (_fragmentManager.FindFragmentById(Resource.Id.contentFrame) is MvxFragment currentFragment && currentFragment.ViewModel == viewModel)
            {
                _fragmentManager.PopBackStackImmediate();
                return Task.FromResult(true);
            }

            return base.Close(viewModel);
        }
    }
}