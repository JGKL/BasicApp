using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V4;
using Android.Support.V4.Content;
using System.Collections.Generic;
using BasicApp.Business.ViewModels;
using Android.Support.Design.Widget;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using BasicApp.Droid.Views.Overzicht;
using BasicApp.Droid.Views.Historie;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;
using BasicApp.Core.Business.ViewModels;
using Android.Graphics;

namespace BasicApp.Droid.Views.Home
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame, IsCacheableFragment = true)]
    public class HomeFragment : MvxFragment<HomeViewModel>
    {
        private TabLayout _tabLayout;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            var fragments = new List<MvxViewPagerFragmentInfo>
            {
                new MvxViewPagerFragmentInfo("Trainingen", "tab1", typeof(HistorieFragment), new MvxViewModelRequest(typeof(HistorieViewModel))),
                new MvxViewPagerFragmentInfo("Programma", "tab2", typeof(OverzichtFragment), new MvxViewModelRequest(typeof(HistorieViewModel))),
            };
            var viewPagerAdapter = new MvxCachingFragmentStatePagerAdapter(Context, ChildFragmentManager, fragments);
            viewPager.Adapter = viewPagerAdapter;
            viewPager.SetCurrentItem(0, false);

            _tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabLayout);
            _tabLayout.SetupWithViewPager(viewPager);

            var darkGrey = ContextCompat.GetColor(Activity, Resource.Color.darkGrey);

            _tabLayout.SetSelectedTabIndicatorColor(darkGrey);
            _tabLayout.SetTabTextColors(ContextCompat.GetColor(Activity, Resource.Color.lightGrey), darkGrey);
            _tabLayout.SetBackgroundColor(new Color(ContextCompat.GetColor(Activity, Resource.Color.primaryColor)));

            return view;
        }
    }
}