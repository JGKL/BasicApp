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

            HomeItems = new List<HomeItem>
            {
                new HomeItem("Home item één"),
                new HomeItem("Home item twee"),
                new HomeItem("Home item drie"),
                new HomeItem("Home item vier")
            };

            ToolbarItems = new List<ToolbarItem>
            {
                new ToolbarItem("fa-heart", "Heart", "IconOne"),
                new ToolbarItem("fa-calendar", "Calendar", "IconTwo")
            };
        }

        public IMvxCommand ItemClickCommand
        {
            get
            {
                return new MvxCommand<HomeItem>(homeItem =>
                {
                    ShowViewModel<ItemViewModel, HomeItem>(homeItem);
                });
            }
        }

        private List<HomeItem> _homeItems;
        public List<HomeItem> HomeItems
        {
            get
            {
                return _homeItems;
            }
            set
            {
                _homeItems = value;
                RaisePropertyChanged(() => HomeItems);
            }
        }
    }
}
