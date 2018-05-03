using Android.OS;
using Android.Views;
using BasicApp.Business.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace BasicApp.Droid.Views.Item
{
    public class ItemView : BaseFragment<ItemViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.ItemView, null);

            var baseViewModel = ViewModel as ItemViewModel;

            return view;
        }
    }
}