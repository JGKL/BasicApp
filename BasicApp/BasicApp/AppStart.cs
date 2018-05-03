using BasicApp.Business.ViewModels;
using MvvmCross.Core.ViewModels;

namespace BasicApp
{
    /// <summary>
    /// A class that implements the IMvxAppStart interface and can be used to customise
    /// the way an application is initialised
    /// </summary>
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        /// <summary>
        /// Start is called on startup of the app
        /// Hint contains information in case the app is started with extra parameters
        /// </summary>
        public void Start(object hint = null)
        {
            ShowViewModel<MainViewModel>();
        }
    }
}
