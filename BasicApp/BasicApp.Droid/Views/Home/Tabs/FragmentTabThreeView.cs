using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using BasicApp.Business.ViewModels.Home.Tabs;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabThreeView : MvxFragment<FragmentTabTwoViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TabFragmentThree, null);
            return view;
        }
    }
}