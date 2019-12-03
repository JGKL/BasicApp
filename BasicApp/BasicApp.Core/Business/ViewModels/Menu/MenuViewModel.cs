using System;
using System.Collections.Generic;
using BasicApp.Business.ViewModels.Shared;
using BasicApp.Core.Business.ViewModels;
using BasicApp.Interfaces;
using MvvmCross.Commands;

namespace BasicApp.Business.ViewModels
{
    public class MenuViewModel : BaseViewModel, INavigationModel
    {
        List<object> _menuItems;
        public List<object> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                RaisePropertyChanged(() => MenuItems);
            }
        }

        public MenuViewModel()
        {
            Title = string.Empty;
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuItems = new List<object>
            {
                new MenuHeaderViewModel("Jesse Klamer", string.Empty),
                new MenuItemViewModel("Mijn team", new TeamViewModel()),
                new MenuItemViewModel("Instellingen", new InstellingenViewModel())
            };
        }

        public IMvxCommand NavigationCommand
        {
            get
            {
                return new MvxCommand<object>((e) =>
                {
                    if (e is MenuItemViewModel menuItem)
                    {
                        Navigate(menuItem.ViewModel);
                    }
                });
            }
        }

        public Type InitialViewModelType => typeof(HomeViewModel);
        public Dictionary<string, string> InitialViewModelParameters => new Dictionary<string, string>();
    }
}
