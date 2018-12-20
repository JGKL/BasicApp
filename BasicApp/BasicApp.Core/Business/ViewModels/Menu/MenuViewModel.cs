﻿using System;
using System.Collections.Generic;
using BasicApp.Business.Models;
using BasicApp.Business.ViewModels.Shared;
using BasicApp.Interfaces;
using MvvmCross.Core.ViewModels;

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
                new MenuItemViewModel("Home", typeof(HomeViewModel))
            };
        }

        private string _iconOne;
        public string IconOne
        {
            get => _iconOne;
            set
            {
                _iconOne = value;
                RaisePropertyChanged(() => IconOne);
            }
        }

        private string _iconTwo;
        public string IconTwo
        {
            get => _iconTwo;
            set
            {
                _iconTwo = value;
                RaisePropertyChanged(() => IconTwo);
            }
        }

        public IMvxCommand NavigationCommand
        {
            get
            {
                return new MvxCommand<object>((e) =>
                {
                    if (e is MenuItemViewModel menuItem)
                    {
                        ShowViewModel(menuItem.NavigationType);
                    }
                });
            }
        }

        public Type InitialViewModelType => typeof(HomeViewModel);
        public Dictionary<string, string> InitialViewModelParameters => new Dictionary<string, string>();
    }
}