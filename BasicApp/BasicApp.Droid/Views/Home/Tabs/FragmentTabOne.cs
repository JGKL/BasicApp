﻿using BasicApp.Business.ViewModels.Home.Tabs;
using Android.Views;
using Android.OS;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabOne : BaseFragment<FragmentTabOneViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.TabFragmentOne, null);
            return view;
        }
    }
}