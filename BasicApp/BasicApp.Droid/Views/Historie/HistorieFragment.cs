using System;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BasicApp.Core.Business.Enum;
using BasicApp.Core.Business.ViewModels;
using BasicApp.Droid.Utilities.Controls;
using BasicApp.Droid.Utilities.FontAwesome;
using BasicApp.Droid.Views.Training;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Historie
{
    public class HistorieFragment : MvxFragment<HistorieViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HistorieView, null);

            var recyclerView = view.FindViewById<LineDividedRecyclerView>(Resource.Id.trainingen);
            if (recyclerView != null)
            {
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);
            }

            var floatingActionButton = view.FindViewById<FloatingActionButton>(Resource.Id.addTrainingFloatingActionButton);
            floatingActionButton.Click += OnFloatingActionButtonClick;

            var icon = new IconDrawable(Activity, '\uf067', FontModule.FontAwesomeSolid).Color(ContextCompat.GetColor(Activity, Resource.Color.primaryColor)).SizeDp(40);
            floatingActionButton.SetImageDrawable(icon);

            var filterMaandTextView = view.FindViewById<TextView>(Resource.Id.filterMaandTextView);
            filterMaandTextView.Click += OnFilterMaandClick;

            var calendarIcon = new IconDrawable(Context, '\uf133', FontModule.FontAwesomeSolid);
            calendarIcon.SizeDp(24);
            calendarIcon.Color(ContextCompat.GetColor(Activity, Resource.Color.filterItemDeselected));
            filterMaandTextView.SetCompoundDrawablesWithIntrinsicBounds(calendarIcon, null, null, null);

            return view;
        }

        private void OnFloatingActionButtonClick(object sender, EventArgs e)
        {
            ViewModel.Navigate<AddTrainingViewModel>();
        }

        private void OnFilterMaandClick(object sender, EventArgs e)
        {
            var builder = new AlertDialog.Builder(Context);
            builder.SetTitle("Selecteer een maand");
            builder.Show();
        }
    }
}