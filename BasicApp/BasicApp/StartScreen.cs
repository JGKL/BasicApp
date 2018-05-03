using BasicApp.Business.ViewModels;
using MvvmCross.Core.ViewModels;

namespace BasicApp
{
    public class StartScreen : MvxNavigatingObject, IMvxAppStart
    {
        public StartScreen()
        {
            Start();
        }

        public void Start(object hint = null)
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}
