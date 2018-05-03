using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;

namespace BasicApp.Droid.Views.Login
{
    [Activity(ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.KeyboardHidden | ConfigChanges.Orientation)]
    public class LoginView : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginView);
        }

        public override bool DispatchTouchEvent(Android.Views.MotionEvent ev)
        {
            if (ev.Action == Android.Views.MotionEventActions.Down)
            {
                var v = CurrentFocus;
                if (v is EditText)
                {
                    var outRect = new Rect();
                    v.GetGlobalVisibleRect(outRect);
                    if (!outRect.Contains((int)ev.RawX, (int)ev.RawY))
                    {
                        v.ClearFocus();
                    }
                }
            }
            else if (ev.Action == Android.Views.MotionEventActions.Up)
            {
                var v = CurrentFocus;
                if (!(v is EditText))
                {
                    var inputMethodManager = (InputMethodManager)BaseContext.GetSystemService(Context.InputMethodService);
                    inputMethodManager.HideSoftInputFromWindow(v.WindowToken, 0);
                }
            }
            return base.DispatchTouchEvent(ev);
        }
    }
}