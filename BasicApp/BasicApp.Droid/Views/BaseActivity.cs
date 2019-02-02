using Android.Widget;
using Acr.UserDialogs;
using Android.Views;
using Plugin.Iconize.Droid.Controls;
using System.Collections.Generic;
using BasicApp.Business.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android;
using MvvmCross;
using Android.Support.V4.Content;
using Android.Util;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views.Animations;
using System;
using Android.Support.Transitions;

namespace BasicApp.Droid.Views
{
    public class BaseActivity : MvxAppCompatActivity
    {
        private int _toolbarItemCount;
        private readonly IMvxAndroidCurrentTopActivity _topActivity;

        public BaseActivity()
        {
            _topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
        }

        protected override void OnStart()
        {
            base.OnStart();

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //var startButton = FindViewById<FloatingActionButton>(Resource.Id.startButton);
            //var drawable = new IconDrawable(this, "fa-plus").Color(ContextCompat.GetColor(this, Resource.Color.primaryColor));
            //drawable.SetBounds(0, 0, 150, 150);
            //startButton.SetImageDrawable(drawable);
        }

        public void RemoveToolbarItems()
        {
            var toolbarLayout = FindViewById<RelativeLayout>(Resource.Id.toolbar_layout);
            _toolbarItemCount = 0;
            toolbarLayout.RemoveAllViews();
        }

        public void CreateToolbarItemView(List<ToolbarItemViewModel> toolbarItems)
        {
            RemoveToolbarItems();

            foreach (var item in toolbarItems)
            {
                var toolbarLayout = FindViewById<RelativeLayout>(Resource.Id.toolbar_layout);

                _toolbarItemCount++;

                TypedValue typedValue = new TypedValue();
                Theme.ResolveAttribute(Resource.Attribute.colorControlNormal, typedValue, true);
                var color = ContextCompat.GetColor(this, typedValue.ResourceId);
                var icon = new IconDrawable(_topActivity.Activity, item.Icon);
                icon.Color(color);

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

                var layoutParams = new RelativeLayout.LayoutParams(110, 110) { AlignWithParent = true };
                layoutParams.AddRule(LayoutRules.AlignParentRight);

                layoutParams.RightMargin = 40 * _toolbarItemCount;

                if (_toolbarItemCount == 1)
                    layoutParams.RightMargin = 40;
                else if (_toolbarItemCount == 2)
                    layoutParams.RightMargin = 180;

                layoutParams.TopMargin = 50;

                image.LayoutParameters = layoutParams;
                image.Visibility = ViewStates.Visible;
                image.TextAlignment = TextAlignment.ViewEnd;

                image.SetMaxHeight(2147483647);
                image.SetMaxWidth(2147483647);
                image.SetImageDrawable(icon);
                image.Click += (sender, args) =>
                {
                    UserDialogs.Instance.Toast(item.ToastText);
                };

                toolbarLayout.AddView(image);
            }
        }
    }
}