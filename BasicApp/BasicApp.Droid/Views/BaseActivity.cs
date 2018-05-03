using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Widget;
using Acr.UserDialogs;
using Android.Views;
using BasicApp.Business.Models;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Plugin.Iconize.Droid.Controls;
using System.Collections.Generic;

namespace BasicApp.Droid.Views
{
    public class BaseActivity : MvxAppCompatActivity
    {
        private int _toolbarItemCount;
        private readonly IMvxAndroidCurrentTopActivity _topActivity;
        private List<ToolbarItem> _toolbarItems = null;

        public BaseActivity()
        {
            _topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }

        public void RemoveToolbarItems()
        {
            var toolbarLayout = FindViewById<RelativeLayout>(Resource.Id.toolbar_layout);
            _toolbarItemCount = 0;
            toolbarLayout.RemoveAllViews();
        }

        public void CreateToolbarItemView(List<ToolbarItem> toolbarItems)
        {
            RemoveToolbarItems();

            foreach (var item in toolbarItems)
            {
                var toolbarLayout = FindViewById<RelativeLayout>(Resource.Id.toolbar_layout);

                _toolbarItemCount++;

                var icon = new IconDrawable(_topActivity.Activity, item.Icon);
                var image = new ImageView(this);

                switch (_toolbarItemCount)
                {
                    case 0:
                        image.SetTag(Resource.Id.ToolbarItemOne, item.Identifier);
                        break;
                    case 1:
                        image.SetTag(Resource.Id.ToolbarItemTwo, item.Identifier);
                        break;
                    case 2:
                        image.SetTag(Resource.Id.ToolbarItemThree, item.Identifier);
                        break;
                }

                var layoutParams = new RelativeLayout.LayoutParams(120, 120) { AlignWithParent = true };
                layoutParams.AddRule(LayoutRules.AlignParentRight);

                layoutParams.RightMargin = 70 * _toolbarItemCount;

                if (_toolbarItemCount == 1)
                    layoutParams.RightMargin = 70;
                else if (_toolbarItemCount == 2)
                    layoutParams.RightMargin = 240;

                image.LayoutParameters = layoutParams;
                image.Visibility = ViewStates.Visible;
                image.TextAlignment = TextAlignment.ViewEnd;

                image.SetMaxHeight(2147483647);
                image.SetMaxWidth(2147483647);
                image.SetImageDrawable(icon);
                image.Click += (sender, args) =>
                {
                    RemoveToolbarItems();
                    UserDialogs.Instance.Toast("Toolbar items verwijderd");
                };

                toolbarLayout.AddView(image);
            }
        }
    }
}