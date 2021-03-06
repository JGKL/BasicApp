﻿using Android.Content;
using Android.Views;
using BasicApp.Business.ViewModels.Shared;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Utilities.Adapters
{
    public class MenuAdapter : BaseAdapter
    {
        public MenuAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext) { }

        protected override View GetBindableView(View convertView, object dataContext, ViewGroup parent, int templateId)
        {
            if (dataContext == null)
                return base.GetBindableView(convertView, dataContext, parent, templateId);

            if (dataContext is MenuItemViewModel)
                templateId = Resource.Layout.Item_MenuItem;
            else if (dataContext is MenuHeaderViewModel)
                templateId = Resource.Layout.Item_MenuHeader;

            return base.GetBindableView(convertView, dataContext, parent, templateId);
        }

        public override bool IsEnabled(int position)
        {
            var item = GetRawItem(position);
            if (item is MenuHeaderViewModel || item is MenuTitleViewModel)
                return false;
            return true;
        }
    }
}