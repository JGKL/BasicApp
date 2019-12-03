using Android.OS;
using Android.Views;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace BasicApp.Droid.Views.Training
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame, true)]
    public class TrainingFragment : MvxFragment<TrainingViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TrainingView, null);
            return view;
        }
    }
}
