using System;
using System.Collections.Generic;
using System.Reflection;
using BasicApp.Droid.Utilities.Helpers;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using BasicApp.Droid.Views.Settings;

namespace BasicApp.Droid.Utilities.Presenter
{
    public class CustomPresenter : MvxAndroidViewPresenter
    {
        private readonly IMvxViewModelLoader _viewModelLoader;
        private readonly IFragmentTypeLookup _fragmentTypeLookup;
        private Android.Support.V4.App.FragmentManager _fragmentManager;

        public CustomPresenter(IMvxViewModelLoader viewModelLoader, IFragmentTypeLookup fragmentTypeLookup) : base(new List<Assembly>())
        {
            _fragmentTypeLookup = fragmentTypeLookup;
            _viewModelLoader = viewModelLoader;
        }

        public void RegisterFragmentManager(Android.Support.V4.App.FragmentManager fragmentManager, Type viewModelType)
        {
            _fragmentManager = fragmentManager;

            Type fragmentType;
            _fragmentTypeLookup.TryGetFragmentType(viewModelType, out fragmentType);
            var viewModelRequest = new MvxViewModelRequest(viewModelType, null, null);
            ShowFragment(fragmentType, viewModelRequest, false);
        }

        public override void Show(MvxViewModelRequest request)
        {
            Type fragmentType;
            if (IsFragmentManagerLoaded() && !IsViewModelTypeAnActivity(request, out fragmentType))
            {
                ShowFragment(fragmentType, request, true);
                return;
            }

            base.Show(request);
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
            fragment.ViewModel = _viewModelLoader.LoadViewModel(request, null);

            var transaction = _fragmentManager.BeginTransaction();

            if (addToBackStack)
                transaction.AddToBackStack(fragment.GetType().Name);

            if(fragment.GetType() == typeof(SettingsView))
                transaction.SetCustomAnimations(Resource.Layout.enter_from_right, Resource.Layout.exit_to_right);

            transaction.Replace(Resource.Id.contentFrame, fragment).Commit();
        }

        public override void Close(IMvxViewModel viewModel)
        {
            var currentFragment = _fragmentManager.FindFragmentById(Resource.Id.contentFrame) as MvxFragment;
            if (currentFragment != null && currentFragment.ViewModel == viewModel)
            {
                _fragmentManager.PopBackStackImmediate();

                return;
            }

            base.Close(viewModel);
        }
    }
}