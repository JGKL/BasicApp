using System;
using Android.App;
using BasicApp.Business.ViewModels;

namespace BasicApp.Droid.Views.Menu
{
    [Activity]
    public class MenuView : MenuBaseActivity
    {
        protected override Type GetInitialViewModelType()
        {
            return typeof(HomeViewModel);
        }
    }
}