using System;
using MvvmCross.Core.ViewModels;

namespace BasicApp.Business.Models
{
    public class ToolbarItem
    {
        public ToolbarItem(string icon, string text, string identifier, string toastText)
        {
            Icon = icon;
            Text = text;
            Identifier = identifier;
            ToastText = toastText;
        }

        public string Icon { get; set; }
        public string Text { get; set; }
        public string Identifier { get; set; }
        public string ToastText { get; set; }
    }
}
