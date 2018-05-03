using System;

namespace BasicApp.Business.Models
{
    public class MenuItem : DataObject
    {
        public MenuItem(string label, Type navigationType)
        {
            Label = label;
            NavigationType = navigationType;
        }

        public string Label { get; }
        public Type NavigationType { get; }
    }
}
