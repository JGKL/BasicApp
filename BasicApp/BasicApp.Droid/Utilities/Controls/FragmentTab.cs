using Android.OS;
using BasicApp.Business.ViewModels;
using Android.Views;
using Android.Widget;
using BasicApp.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Graphics;
using Android.Content.Res;
using Android.App;

namespace BasicApp.Droid.Utilities.Controls
{
    public class FragmentTab : BaseFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.FragmentLayout, null);

            AssetManager assets = Application.Context.Assets;
            var font = Typeface.CreateFromAsset(assets, "fontawesome-webfont.ttf");

            return view;
        }
    }
}