using Android.OS;
using Android.Views;
using BasicApp.Core.Business.ViewModels.Overzicht;
using Com.Airbnb.Lottie;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Overzicht
{
    public class OverzichtFragment : MvxFragment<OverzichtViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.OverzichtView, null);

            var animationView = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.SetAnimation("loader.json");
            animationView.Loop(true);
            animationView.PlayAnimation();

            return view;
        }
    }
}