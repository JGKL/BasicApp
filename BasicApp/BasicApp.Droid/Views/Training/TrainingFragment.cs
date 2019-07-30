using Android.OS;
using Android.Support.Transitions;
using Android.Views;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace BasicApp.Droid.Views.Training
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame, true)]
    public class TrainingFragment : MvxFragment<TrainingViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                SharedElementEnterTransition = TransitionInflater.From(Activity).InflateTransition(Android.Resource.Transition.Move);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.TrainingView, null);

            Arguments.SetSharedElementsByTag(view);

            return view;
        }
    }
}
