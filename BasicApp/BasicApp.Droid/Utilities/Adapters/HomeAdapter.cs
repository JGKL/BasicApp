using Android.Content;
using Android.Views;
using BasicApp.Business.Models;
using MvvmCross.Binding.Droid.BindingContext;

namespace BasicApp.Droid.Utilities.Adapters
{
    public class HomeAdapter : BaseAdapter
    {
        public HomeAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {

        }

        protected override View GetBindableView(View convertView, object dataContext, ViewGroup parent, int templateId)
        {
            if (dataContext is HomeItem)
                templateId = Resource.Layout.HomeItem;

            return base.GetBindableView(convertView, dataContext, parent, templateId);
        }


    }
}