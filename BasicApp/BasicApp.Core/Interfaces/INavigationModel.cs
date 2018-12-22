using MvvmCross.Commands;
using System;
using System.Collections.Generic;

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
