using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V4;
using Android.Support.V4.Content;
using System.Collections.Generic;
using BasicApp.Business.ViewModels;
using Android.Support.Design.Widget;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using BasicApp.Core.Business.ViewModels.Historie;
using BasicApp.Core.Business.ViewModels.Overzicht;
using BasicApp.Droid.Views.Overzicht;
using BasicApp.Droid.Views.Historie;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using BasicApp.Droid.Utilities.FontAwesome;
using BasicApp.Core.Business.Enum;

namespace BasicApp.Droid.Views.Home
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame)]
    public class HomeFragment : MvxFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            var fragments = new List<MvxViewPagerFragmentInfo>
            {
                new MvxViewPagerFragmentInfo("Historie", "tab1", typeof(HistorieFragment), typeof(HistorieViewModel)),
                new MvxViewPagerFragmentInfo("Overzicht", "tab2", typeof(OverzichtFragment), typeof(OverzichtViewModel)),
            };
            var viewPagerAdapter = new MvxFragmentStatePagerAdapter(Context, ChildFragmentManager, fragments);
            viewPager.Adapter = viewPagerAdapter;
            viewPager.SetCurrentItem(1, false);

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);

            tabLayout.GetTabAt(0).SetIcon(new IconDrawable(Activity, '\uf0ae', FontAwesomeModule.Solid).Color(ContextCompat.GetColor(Activity, Resource.Color.white)).SizeDp(30));
            tabLayout.GetTabAt(1).SetIcon(new IconDrawable(Context, '\uf2b9', FontAwesomeModule.Solid).Color(ContextCompat.GetColor(Context, Resource.Color.primaryColor)).SizeDp(30));

            return view;
        }
    }
}