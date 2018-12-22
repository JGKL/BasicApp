using BasicApp.Business.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace BasicApp
{
    public class StartScreen : MvxAppStart
    {
        public StartScreen(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<MenuViewModel>();
        }
    }
}
