using Android.OS;
using Android.Views;
using BasicApp.Business.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Support.V4.App;

namespace BasicApp.Droid.Views.Settings
{
    public class SettingsView : BaseFragment<SettingsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.SettingsView, null);

            var x = FragmentManager.BeginTransaction();
            x.SetCustomAnimations(Resource.Layout.enter_from_right, Resource.Layout.exit_to_right);

            return view;
        }
    }
}