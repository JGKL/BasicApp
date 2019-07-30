using System.Collections.Generic;
using Android.App;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace BasicApp.Droid.Views.Menu
{
    [Activity]
    public class MenuActivity : MenuBaseActivity, IMvxAndroidSharedElements
    {
        public IDictionary<string, View> FetchSharedElementsToAnimate(MvxBasePresentationAttribute attribute, MvxViewModelRequest request)
        {
            IDictionary<string, View> sharedElements = new Dictionary<string, View>();

            var iconAnim = CreateSharedElementPair(Resource.String.transition_list_item_icon);
            if (iconAnim != null)
                sharedElements.Add(iconAnim.GetValueOrDefault());

            return sharedElements;
        }

        private KeyValuePair<string, View>? CreateSharedElementPair(int tagStringResourceId)
        {
            var controlTag = Resources.GetString(tagStringResourceId);
            var control = FindViewById(Android.Resource.Id.Content).FindViewWithTag(controlTag);
            if (control != null)
            {
                control.Tag = null;
                return new KeyValuePair<string, View>(controlTag, control);
            }

            return null;
        }
    }
}