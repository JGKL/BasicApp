using System.Collections.Generic;
using MvvmCross.Commands;

namespace BasicApp.Business.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";

            ToolbarItems = new List<ToolbarItemViewModel>
            {
                new ToolbarItemViewModel("fa-info-circle", "Info", "IconOne", "Info :-)")
            };
        }

        public IMvxCommand BeginButtonCommand
        {
            get
            {
                return new MvxCommand(() => { });
            }
        }
    }
}
