﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace BasicApp.Droid.Utilities.Extensions
{
    public class AppCompatExtensions
    {
        public static Color GetColor(int value)
        {
            var resource = ContextCompat.GetColor(Application.Context, Convert.ToInt32(value));
            return new Color(resource);
        }

        public static ColorStateList GetColorStateList(int value)
        {
            var resource = ContextCompat.GetColorStateList(Application.Context, Convert.ToInt32(value));
            return resource;
        }

        public static int GetDimension(int value)
        {
            var resource = Application.Context.Resources.GetDimension(value);
            return (int)resource;
        }

        public static Drawable GetDrawable(int value)
        {
            return ContextCompat.GetDrawable(Application.Context, value);
        }


        //public static float ConvertDpToPx(float valueInDp)
        //{
        //    var metrics = Application.Context.Resources.DisplayMetrics;
        //    return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        //}

        public static void SetTranslucentStatusBar(Window window)
        {
            if (window == null) return;
            var sdkInt = Build.VERSION.SdkInt;
            if (sdkInt >= BuildVersionCodes.Lollipop)
            {
                SetTranslucentStatusBarLollipop(window);
            }
            else if (sdkInt >= BuildVersionCodes.Kitkat)
            {
                SetTranslucentStatusBarKiKat(window);
            }
        }

        private static void SetTranslucentStatusBarLollipop(Window window)
        {
            window.SetStatusBarColor(GetColor(Resource.Color.primaryColor));
        }

        private static void SetTranslucentStatusBarKiKat(Window window)
        {
            window.AddFlags(WindowManagerFlags.TranslucentStatus);
        }
    }
}