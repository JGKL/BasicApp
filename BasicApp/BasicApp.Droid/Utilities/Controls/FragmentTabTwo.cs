﻿using Android.Support.V4.App;
using Android.Views;
using Android.OS;

namespace BasicApp.Droid.Utilities.Controls
{
    public class FragmentTabTwo : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.TabFragmentTwo, null);

            return view;
        }
    }
}