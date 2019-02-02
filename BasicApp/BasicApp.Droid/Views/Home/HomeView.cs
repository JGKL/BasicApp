using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V4;
using Android.Support.V4.Content;
using System.Collections.Generic;
using BasicApp.Business.ViewModels;
using Plugin.Iconize.Droid.Controls;
using Android.Support.Design.Widget;
using BasicApp.Droid.Views.Home.Tabs;
using BasicApp.Business.ViewModels.Home.Tabs;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Home
{
    public class HomeView : BaseFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            ((BaseActivity)Activity).CreateToolbarItemView(ViewModel.ToolbarItems);

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            var fragments = new List<MvxViewPagerFragmentInfo>
            {
                new MvxViewPagerFragmentInfo(string.Empty, "tab1", typeof(FragmentTabOneView), typeof(FragmentTabOneViewModel)),
                new MvxViewPagerFragmentInfo(string.Empty, "tab2", typeof(FragmentTabTwoView), typeof(FragmentTabTwoViewModel)),
                new MvxViewPagerFragmentInfo(string.Empty, "tab3", typeof(FragmentTabThreeView), typeof(FragmentTabThreeViewModel))
            };
            var viewPagerAdapter = new MvxFragmentPagerAdapter(Context, ChildFragmentManager, fragments);
            viewPager.Adapter = viewPagerAdapter;
            viewPager.SetCurrentItem(1, false);

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);
            tabLayout.GetTabAt(0).SetIcon(new IconDrawable(Context, "fa-list").Color(ContextCompat.GetColor(Context, Resource.Color.primaryColor)));
            tabLayout.GetTabAt(1).SetIcon(new IconDrawable(Context, "fa-trophy").Color(ContextCompat.GetColor(Context, Resource.Color.primaryColor)));
            tabLayout.GetTabAt(2).SetIcon(new IconDrawable(Context, "fa-compass").Color(ContextCompat.GetColor(Context, Resource.Color.primaryColor)));

            return view;
        }
    }
}