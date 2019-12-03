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
using BasicApp.Droid.Utilities.FontAwesome;
using BasicApp.Core.Business.Enum;
using MvvmCross.ViewModels;
using BasicApp.Core.Business.ViewModels;

namespace BasicApp.Droid.Views.Home
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame, IsCacheableFragment = true)]
    public class HomeFragment : MvxFragment<HomeViewModel>, TabLayout.IOnTabSelectedListener
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
            _tabLayout.SetSelectedTabIndicatorColor(ContextCompat.GetColor(Activity, Resource.Color.primaryColor));
            _tabLayout.SetTabTextColors(ContextCompat.GetColor(Activity, Resource.Color.lightGrey), ContextCompat.GetColor(Activity, Resource.Color.primaryColor));

            _tabLayout.GetTabAt(0).SetIcon(new IconDrawable(Activity, '\uf0ae', FontModule.FontAwesomeSolid).Color(ContextCompat.GetColor(Activity, Resource.Color.primaryColor)).SizeDp(30));
            _tabLayout.GetTabAt(1).SetIcon(new IconDrawable(Context, '\uf2b9', FontModule.FontAwesomeSolid).Color(ContextCompat.GetColor(Context, Resource.Color.white)).SizeDp(30));

            _tabLayout.AddOnTabSelectedListener(this);

            return view;
        }

        public void OnTabReselected(TabLayout.Tab tab) { }

        public void OnTabSelected(TabLayout.Tab tab)
        {
            var activatedIcon = tab.Icon as IconDrawable;
            activatedIcon.Color(ContextCompat.GetColor(Activity, Resource.Color.primaryColor));
        }

        public void OnTabUnselected(TabLayout.Tab tab)
        {
            var nonActiveIcon = tab.Icon as IconDrawable;
            nonActiveIcon.Color(ContextCompat.GetColor(Activity, Resource.Color.lightGrey));
        }
    }
}