using Fragment = Android.Support.V4.App.Fragment;
using MvvmCross.Binding.Droid.BindingContext;
using BasicApp.Droid.Utilities.Adapters;
using BasicApp.Droid.Utilities.Controls;
using BasicApp.Business.ViewModels;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.OS;
using Java.Lang;

namespace BasicApp.Droid.Views.Home
{
    public class HomeView : BaseFragment<HomeViewModel>, ViewPager.IOnPageChangeListener, TabHost.IOnTabChangeListener
    {
        private FragmentTabHost mTabHost;
        private ViewPager viewPager;
        private HomeFragmentPagerAdapter adapter;

        private List<string> tabs;
        private int currentTab;

        public HomeView()
        {
            tabs = new List<string> {"tab1", "tab2", "tab3"};
            currentTab = 0;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            mTabHost = view.FindViewById<FragmentTabHost>(Resource.Id.tabhost);
            mTabHost.SetOnTabChangedListener(this);

            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.AddOnPageChangeListener(this);

            var fragments = new List<Fragment>
            {
                Instantiate(Context, Class.FromType(typeof(FragmentTabOne)).Name),
                Instantiate(Context, Class.FromType(typeof(FragmentTabTwo)).Name),
                Instantiate(Context, Class.FromType(typeof(FragmentTabThree)).Name)
            };
            adapter = new HomeFragmentPagerAdapter(FragmentManager, fragments);
            viewPager.Adapter = adapter;

            mTabHost.Setup(Activity, ChildFragmentManager, Resource.Id.tabcontent);

            mTabHost.AddTab(mTabHost.NewTabSpec("tab1").SetIndicator("Tab 1", null), Class.FromType(typeof(FragmentTabOne)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("tab2").SetIndicator("Tab 2", null), Class.FromType(typeof(FragmentTabTwo)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("tab3").SetIndicator("Tab 3", null), Class.FromType(typeof(FragmentTabThree)), null);

            AssetManager assets = Application.Context.Assets;
            var font = Typeface.CreateFromAsset(assets, "fontawesome-webfont.ttf");

            var baseViewModel = ViewModel as HomeViewModel;
            ((BaseActivity)Activity).CreateToolbarItemView(baseViewModel.ToolbarItems);

            var textView = view.FindViewById<TextView>(Resource.Id.beginTitle);
            textView.SetTypeface(font, TypefaceStyle.Normal);

            return view;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            if (position == currentTab)
                return;

            currentTab = position;

            var tag = tabs[position];
            mTabHost.SetCurrentTabByTag(tag);
        }

        public void OnTabChanged(string tabId)
        {
            var index = tabs.IndexOf(tabId);

            if (index == currentTab)
                return;

            currentTab = index;

            viewPager.SetCurrentItem(index, true);
        }

        public void OnPageScrollStateChanged(int state) { }

        public void OnPageSelected(int position) { }
    }
}