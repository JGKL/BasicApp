using Fragment = Android.Support.V4.App.Fragment;
using MvvmCross.Binding.Droid.BindingContext;
using BasicApp.Droid.Utilities.Adapters;
using BasicApp.Droid.Views.Home.Tabs;
using BasicApp.Business.ViewModels;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Graphics;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.OS;
using Java.Lang;
using Android.Animation;

namespace BasicApp.Droid.Views.Home
{
    public class HomeView : BaseFragment<HomeViewModel>, ViewPager.IOnPageChangeListener, TabHost.IOnTabChangeListener, View.IOnClickListener
    {
        private readonly List<string> _tabs;

        private HomeFragmentPagerAdapter _homeFragmentPagerAdapter;
        private FragmentTabHost _fragmentTabHost;
        private ViewPager _viewPager;

        private Animator _animator;

        private readonly Typeface _fontAwesomeTypeFace;

        private int _currentTab;

        public HomeView()
        {
            _tabs = new List<string> {"tab1", "tab2", "tab3"};
            _currentTab = 0;

            var assets = Application.Context.Assets;
            _fontAwesomeTypeFace = Typeface.CreateFromAsset(assets, "fontawesome-webfont.ttf");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            var beginButton = view.FindViewById<FrameLayout>(Resource.Id.beginButton);
            beginButton.SetOnClickListener(this);

            _fragmentTabHost = view.FindViewById<FragmentTabHost>(Resource.Id.tabhost);
            _fragmentTabHost.SetOnTabChangedListener(this);
            var fragments = new List<Fragment>
            {
                Instantiate(Context, Class.FromType(typeof(FragmentTabOne)).Name),
                Instantiate(Context, Class.FromType(typeof(FragmentTabTwo)).Name),
                Instantiate(Context, Class.FromType(typeof(FragmentTabThree)).Name)
            };
            _homeFragmentPagerAdapter = new HomeFragmentPagerAdapter(ChildFragmentManager, fragments);

            _viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            _viewPager.AddOnPageChangeListener(this);
            _viewPager.Adapter = _homeFragmentPagerAdapter;

            _fragmentTabHost.Setup(Activity, ChildFragmentManager, Resource.Id.tabcontent);
            _fragmentTabHost.AddTab(_fragmentTabHost.NewTabSpec("tab1").SetIndicator(GetTabIndicator(inflater, "\uf200")), Class.FromType(typeof(FragmentTabOne)), null);
            _fragmentTabHost.AddTab(_fragmentTabHost.NewTabSpec("tab2").SetIndicator(GetTabIndicator(inflater, "\uf135")), Class.FromType(typeof(FragmentTabTwo)), null);
            _fragmentTabHost.AddTab(_fragmentTabHost.NewTabSpec("tab3").SetIndicator(GetTabIndicator(inflater, "\uf2dc")), Class.FromType(typeof(FragmentTabThree)), null);

            ((BaseActivity)Activity).CreateToolbarItemView(ViewModel.ToolbarItems);

            var beginTitleTextView = view.FindViewById<TextView>(Resource.Id.beginTitle);
            beginTitleTextView.SetTypeface(_fontAwesomeTypeFace, TypefaceStyle.Normal);

            return view;
        }

        private View GetTabIndicator(LayoutInflater inflater, string title)
        {
            var tabLayoutView = inflater.Inflate(Resource.Drawable.tab_layout, null);
            var textView = tabLayoutView.FindViewById<TextView>(Resource.Id.textView);
            textView.SetText(title.ToCharArray(), 0, title.Length);
            textView.SetTypeface(_fontAwesomeTypeFace, TypefaceStyle.Normal);
            return tabLayoutView;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels) { }

        public void OnPageScrollStateChanged(int state) { }

        public void OnPageSelected(int position)
        {
            if (position == _currentTab)
                return;

            _currentTab = position;

            var tag = _tabs[position];
            _fragmentTabHost.SetCurrentTabByTag(tag);
        }

        public void OnTabChanged(string tabId)
        {
            var index = _tabs.IndexOf(tabId);

            if (index == _currentTab)
                return;

            _currentTab = index;

            _viewPager.SetCurrentItem(index, true);
        }

        public void OnClick(View v)
        {
            _animator.Start();
        }

        public void OnAnimationUpdate(ValueAnimator animation)
        {
            var homeTopSide = View.FindViewById<RelativeLayout>(Resource.Id.homeTopSide);
            var val = (int) animation.AnimatedValue;
            ViewGroup.LayoutParams layoutParams = homeTopSide.LayoutParameters;
            layoutParams.Height = val;
            homeTopSide.LayoutParameters = layoutParams;
        }
    }
}