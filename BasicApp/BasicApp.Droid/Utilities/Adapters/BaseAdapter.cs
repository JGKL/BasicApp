using Android.Content;
using Android.Views;
using BasicApp.Business.ViewModels.Shared;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace BasicApp.Droid.Utilities.Adapters
{
    public class BaseAdapter : MvxAdapter
    {
        public BaseAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {

        }

        protected override View GetBindableView(View convertView, object dataContext, ViewGroup parent, int templateId)
        {
            if (dataContext == null)
                return base.GetBindableView(convertView, dataContext, parent, templateId);

            if (dataContext is EmptyListViewModel)
                templateId = Resource.Layout.Item_EmptyList;
            return base.GetBindableView(convertView, dataContext, parent, templateId);
        }
    }
}