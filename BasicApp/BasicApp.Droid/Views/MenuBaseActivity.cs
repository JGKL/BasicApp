﻿using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using BasicApp.Business.ViewModels.Shared;
using BasicApp.Droid.Utilities.Adapters;
using BasicApp.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace BasicApp.Droid.Views
{
    public abstract class MenuBaseActivity : BaseActivity
    {
        private ActionBarDrawerToggle _drawerToggle;
        private MvxListView _drawerListView;
        private DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FragmentContainer);

            _drawerListView = FindViewById<MvxListView>(Resource.Id.drawerListView);
            _drawerListView.Adapter = new MenuAdapter(this, (MvxAndroidBindingContext)BindingContext);
        }

        protected override void OnStart()
        {
            base.OnStart();

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);

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
    }
}