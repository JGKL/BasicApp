using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android;
using MvvmCross;
using Android.OS;

namespace BasicApp.Droid.Views
{
    public class BaseActivity : MvxAppCompatActivity
    {
        private readonly IMvxAndroidCurrentTopActivity _topActivity;

        public BaseActivity()
        {
            _topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            Window.SetSoftInputMode(Android.Views.SoftInput.AdjustPan);
        }

        protected override void OnStart()
        {
            base.OnStart();

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
    }
}