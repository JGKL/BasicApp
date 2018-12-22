using Android.OS;
using Android.Views;
using BasicApp.Business.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;

namespace BasicApp.Droid.Views
{
    public class BaseFragment<TViewModel> : MvxFragment<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public BaseFragment()
        {
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var baseViewModel = ViewModel as BaseViewModel;
            if (baseViewModel != null && !string.IsNullOrWhiteSpace(baseViewModel.Title))
            {
                Activity.Title = baseViewModel.Title;
            }

            RetainInstance = true;
        }
    }
}