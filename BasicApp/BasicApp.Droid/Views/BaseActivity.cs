using MvvmCross.Droid.Support.V7.AppCompat;
using Android.OS;
using Android.Views;

namespace BasicApp.Droid.Views
{
    public class BaseActivity : MvxAppCompatActivity
    {
        public BaseActivity() { }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.SetSoftInputMode(SoftInput.AdjustPan);
        }

        protected override void OnStart()
        {
            base.OnStart();

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
    }
}