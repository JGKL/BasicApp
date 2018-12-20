using MvvmCross.Binding.Droid.BindingContext;
using BasicApp.Droid.Views.Home.Tabs;
using BasicApp.Business.ViewModels;
using MvvmCross.Droid.Support.V4;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Animation;
using Android.Widget;
using Android.Views;
using Android.OS;
using BasicApp.Business.ViewModels.Home.Tabs;
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.App;
using Plugin.Iconize.Droid.Controls;

namespace BasicApp.Droid.Views.Home
{
    public class HomeView : BaseFragment<HomeViewModel>, ValueAnimator.IAnimatorUpdateListener,
                                                         View.IOnClickListener,
                                                         View.IOnLayoutChangeListener
    {
        private ValueAnimator _animator;
        private Typeface _fontAwesomeTypeFace;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            ((BaseActivity)Activity).CreateToolbarItemView(ViewModel.ToolbarItems);

            _fontAwesomeTypeFace = Typeface.CreateFromAsset(Application.Context.Assets, "fontawesome-webfont.ttf");

            var beginButton = view.FindViewById<FrameLayout>(Resource.Id.beginButton);
            beginButton.SetOnClickListener(this);
            var beginTitleTextView = view.FindViewById<TextView>(Resource.Id.beginTitle);
            beginTitleTextView.SetTypeface(_fontAwesomeTypeFace, TypefaceStyle.Normal);

            var viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            var fragments = new List<MvxViewPagerFragmentInfo>
            {
                new MvxViewPagerFragmentInfo(string.Empty, "tab1", typeof(FragmentTabOneView), typeof(FragmentTabOneViewModel)),
                new MvxViewPagerFragmentInfo(string.Empty, "tab2", typeof(FragmentTabTwoView), typeof(FragmentTabTwoViewModel)),
                new MvxViewPagerFragmentInfo(string.Empty, "tab3", typeof(FragmentTabThreeView), typeof(FragmentTabThreeViewModel))
            };
            var viewPagerAdapter = new MvxFragmentPagerAdapter(Context, ChildFragmentManager, fragments);
            viewPager.Adapter = viewPagerAdapter;

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);

            tabLayout.GetTabAt(0).SetIcon(new IconDrawable(Context, "fa-percent"));
            tabLayout.GetTabAt(1).SetIcon(new IconDrawable(Context, "fa-comments"));
            tabLayout.GetTabAt(2).SetIcon(new IconDrawable(Context, "fa-compass"));
            tabLayout.GetTabAt(0).SetText("Title one");
            tabLayout.GetTabAt(1).SetText("Title two");
            tabLayout.GetTabAt(2).SetText("Title three");

            var homeTopSide = view.FindViewById<RelativeLayout>(Resource.Id.homeTopSide);
            homeTopSide.AddOnLayoutChangeListener(this);

            return view;
        }

        public void OnClick(View v)
        {
            _animator.Start();
        }

        public void OnAnimationUpdate(ValueAnimator animation)
        {
            var homeTopSide = View.FindViewById<RelativeLayout>(Resource.Id.homeTopSide);
            var val = (int)animation.AnimatedValue;
            ViewGroup.LayoutParams layoutParams = homeTopSide.LayoutParameters;
            layoutParams.Height = val;
            homeTopSide.LayoutParameters = layoutParams;
        }

        public void OnLayoutChange(View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
        {
            _animator = ValueAnimator.OfInt(v.Height, 300);
            _animator.AddUpdateListener(this);
            _animator.SetDuration(500);
        }
    }
}