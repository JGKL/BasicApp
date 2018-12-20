using System;

namespace BasicApp.Business.ViewModels.Shared
{
    public class MenuItemViewModel : BaseViewModel
    {
        public MenuItemViewModel(string label, Type navigationType, string icon = "")
        {
            Label = label;
            NavigationType = navigationType;
            Icon = icon;
        }

        public string Label { get; private set; }
        public Type NavigationType { get; private set; }
        public string Icon { get; private set; }
    }
}
