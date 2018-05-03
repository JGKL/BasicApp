using System;
using MvvmCross.Core.ViewModels;

namespace BasicApp.Business.Models
{
    public class ToolbarItem
    {
        public ToolbarItem(string icon, string text, string identifier)
        {
            Icon = icon;
            Text = text;
            Identifier = identifier;
        }

        public string Icon { get; set; }
        public string Text { get; set; }
        public string Identifier { get; set; }
    }
}
