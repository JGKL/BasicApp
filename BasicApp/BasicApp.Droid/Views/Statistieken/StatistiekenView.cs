using Android.OS;
using Android.Views;
using BasicApp.Core.Business.ViewModels.Statistieken;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Training
{
    public class StatistiekenView : BaseFragment<StatistiekenViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.StatistiekenView, null);
            return view;
        }
    }
}