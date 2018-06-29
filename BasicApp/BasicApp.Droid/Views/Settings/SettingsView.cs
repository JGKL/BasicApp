using System.Linq;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using BasicApp.Business.ViewModels;
using BasicApp.Droid.Utilities.Adapters;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.ResourceHelpers;

namespace BasicApp.Droid.Views.Settings
{
    public class SettingsView : BaseFragment<SettingsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.SettingsView, null);

            var fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.SetCustomAnimations(Resource.Layout.enter_from_right, Resource.Layout.exit_to_right);

            var myRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.settingsRecyclerView);
            
            /* add this for perfomrance boost when the changes to the content of the recycler view
               won't affect the layout size of the recycler view */
            // myRecyclerView.HasFixedSize = true;

            var linearLayoutManager = new LinearLayoutManager(Context);
            myRecyclerView.SetLayoutManager(linearLayoutManager);

            var x = new string[55];
            for (var i = 1; i <= x.Length; i++)
            {
                var y = i - 1;
                x[y] = $"Dit is textview item {i}";
            }

            var recyclerViewAdapter = new SettingsRecyclerViewAdapter(x);
            myRecyclerView.SetAdapter(recyclerViewAdapter);

            return view;
        }
    }
}