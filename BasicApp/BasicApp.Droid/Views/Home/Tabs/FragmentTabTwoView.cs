﻿using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using BasicApp.Business.ViewModels.Home.Tabs;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabTwoView : MvxFragment<FragmentTabThreeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TabFragmentTwo, null);
            return view;
        }
    }
}