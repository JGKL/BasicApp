using Android.Views;
using Android.OS;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using BasicApp.Business.ViewModels.Home.Tabs;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabTwoView : MvxFragment<FragmentTabThreeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TabFragmentTwo, null);
            return view;
        }
    }
}