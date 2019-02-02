using System;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using BasicApp.Business.ViewModels.Shared;
using BasicApp.Droid.Utilities.Adapters;
using BasicApp.Droid.Utilities.Presenter;
using BasicApp.Interfaces;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Presenters;

namespace BasicApp.Droid.Views
{
    public abstract class MenuBaseActivity : BaseActivity
    {
        private ActionBarDrawerToggle _drawerToggle;
        private MvxListView _drawerListView;
        private DrawerLayout _drawerLayout;
        private Bundle _bundle;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _bundle = bundle;

            SetContentView(Resource.Layout.FragmentContainer);

            _drawerListView = FindViewById<MvxListView>(Resource.Id.drawerListView);
            _drawerListView.Adapter = new MenuAdapter(this, (MvxAndroidBindingContext)BindingContext);
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (_bundle == null || (_bundle != null && SupportFragmentManager?.BackStackEntryCount == 0))
            {
                var presenter = (CustomPresenter)Mvx.IoCProvider.Resolve<IMvxAndroidViewPresenter>();
                presenter.RegisterFragmentManager(SupportFragmentManager, GetInitialViewModelType());
                //presenter.RegisterTransitionManager(ContentTransitionManager);
            }

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.DrawerOpen, Resource.String.DrawerClosed)
            {
                DrawerIndicatorEnabled = true
            };
            _drawerLayout.AddDrawerListener(_drawerToggle);
            _drawerListView.ItemClick = new MvxCommand<object>((sender) =>
            {
                if (sender is MenuItemViewModel)
                {
                    _drawerLayout.CloseDrawer(_drawerListView);

                    if (ViewModel is INavigationModel viewModel)
                    {
                        viewModel.NavigationCommand.Execute(sender);
                    }
                }
            });
            _drawerToggle.SyncState();
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            switch (item.ItemId)
            {
                case (Android.Resource.Id.Home):
                    if (SupportFragmentManager.BackStackEntryCount > 0)
                        OnBackPressed();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected abstract Type GetInitialViewModelType();
    }
}