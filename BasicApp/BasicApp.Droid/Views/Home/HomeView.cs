using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using BasicApp.Business.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Graphics;
using Android.Support.V4.App;
using BasicApp.Droid.Utilities.Controls;

namespace BasicApp.Droid.Views.Home
{
    public class HomeView : BaseFragment<HomeViewModel>
    {
        private FragmentTabHost mTabHost;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HomeView, null);

            mTabHost = view.FindViewById<FragmentTabHost>(Resource.Id.tabhost);
            mTabHost.Setup(Activity, ChildFragmentManager, Resource.Id.tabcontent);

            mTabHost.AddTab(mTabHost.NewTabSpec("tab1").SetIndicator("Tab 1", null), Java.Lang.Class.FromType(typeof(FragmentTab)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("tab2").SetIndicator("Tab 2", null), Java.Lang.Class.FromType(typeof(FragmentTab)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("tab3").SetIndicator("Tab 3", null), Java.Lang.Class.FromType(typeof(FragmentTab)), null);

            AssetManager assets = Application.Context.Assets;
            var font = Typeface.CreateFromAsset(assets, "fontawesome-webfont.ttf");

            var baseViewModel = ViewModel as HomeViewModel;
            ((BaseActivity)Activity).CreateToolbarItemView(baseViewModel.ToolbarItems);

            var textView = view.FindViewById<TextView>(Resource.Id.beginTitle);
            textView.SetTypeface(font, TypefaceStyle.Normal);

            return view;
        }
    }
}