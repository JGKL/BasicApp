using Android.OS;
using Android.Views;
using BasicApp.Core.Business.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Training
{
    public class TrainingView : BaseFragment<TrainingViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TrainingView, null);
            return view;
        }
    }
}
