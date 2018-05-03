using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace BasicApp.Interfaces
{
    public interface INavigationModel
    {
        List<object> MenuItems { get; set; }

        IMvxCommand NavigationCommand { get; }

        Type InitialViewModelType { get; }

        Dictionary<string, string> InitialViewModelParameters { get; }
    }
}
