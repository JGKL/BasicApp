using Android.Views;
using Android.OS;
using MvvmCross.Droid.Support.V4;
using BasicApp.Business.ViewModels.Home.Tabs;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabOneView : MvxFragment<FragmentTabOneViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TabFragmentOne, null);
            return view;
        }
    }
}