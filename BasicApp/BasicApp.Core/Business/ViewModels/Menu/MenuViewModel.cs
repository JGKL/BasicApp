using System;
using System.Collections.Generic;
using BasicApp.Business.ViewModels.Shared;
using BasicApp.Core.Business.ViewModels;
using BasicApp.Core.Business.ViewModels.Programma;
using BasicApp.Core.Business.ViewModels.Statistieken;
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
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuItems = new List<object>
            {
                new MenuHeaderViewModel("Michael Scott", string.Empty),
                new MenuItemViewModel("Home", new HomeViewModel()),
                new MenuItemViewModel("Programma", new ProgrammaViewModel()),
                new MenuItemViewModel("Statistieken", new StatistiekenViewModel()),
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

        public IMvxCommand ShowAddTrainingViewModelCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Navigate<AddTrainingViewModel>();
                });
            }
        }

        public Type InitialViewModelType => typeof(HomeViewModel);
        public Dictionary<string, string> InitialViewModelParameters => new Dictionary<string, string>();
    }
}
