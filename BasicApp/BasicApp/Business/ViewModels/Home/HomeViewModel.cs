using System.Collections.Generic;
using BasicApp.Business.Models;
using MvvmCross.Core.ViewModels;

namespace BasicApp.Business.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";

            ToolbarItems = new List<ToolbarItemViewModel>
            {
                new ToolbarItemViewModel("fa-heart", "Heart", "IconOne", "Added to your favorites list!"),
                new ToolbarItemViewModel("fa-calendar", "Calendar", "IconTwo", "Added to your agenda!")
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
