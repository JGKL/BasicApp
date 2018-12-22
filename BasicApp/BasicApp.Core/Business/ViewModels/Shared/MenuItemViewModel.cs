using MvvmCross.ViewModels;
using System;

namespace BasicApp.Business.ViewModels.Shared
{
    public class MenuItemViewModel : BaseViewModel
    {
        public MenuItemViewModel(string label, IMvxViewModel viewModel, string icon = "")
        {
            Label = label;
            ViewModel = viewModel;
            Icon = icon;
        }

        public string Label { get; private set; }
        public IMvxViewModel ViewModel { get; private set; }
        public string Icon { get; private set; }
    }
}
