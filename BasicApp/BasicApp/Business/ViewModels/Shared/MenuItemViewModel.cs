using System;

namespace BasicApp.Business.ViewModels.Shared
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel(string displayName, Type viewModelType, string icon = "")
        {
            DisplayName = displayName;
            ViewModelType = viewModelType;
            Icon = icon;
        }

        public string DisplayName { get; private set; }
        public Type ViewModelType { get; private set; }
        public string Icon { get; private set; }
    }
}
