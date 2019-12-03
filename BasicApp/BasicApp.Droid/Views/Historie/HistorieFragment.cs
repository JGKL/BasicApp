using System;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BasicApp.Core.Business.Enum;
using BasicApp.Core.Business.ViewModels;
using BasicApp.Droid.Utilities.Controls;
using BasicApp.Droid.Utilities.FontAwesome;
using BasicApp.Droid.Views.Training;
using Com.Airbnb.Lottie;
using Com.Airbnb.Lottie.Value;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using static Android.Views.View;

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
            filterMaandTextView.FocusChange += (object sender, View.FocusChangeEventArgs args) =>
            {
                if (args.HasFocus)
                {
                    var fragment = DatePickerFragment.NewInstance(delegate (DateTime time)
                    {
                        //ViewModel.Datum = time;
                        filterMaandTextView.ClearFocus();
                    }, delegate {
                        filterMaandTextView.ClearFocus();
                    });

                    fragment.Show(ChildFragmentManager, "DatePicker");
                }
            };

            var dateIcon = new IconDrawable(Context, '\uf2b9', FontModule.FontAwesomeRegular);
            dateIcon.SizeDp(24);
            dateIcon.Color(Resource.Color.darkRed);
            filterMaandTextView.SetCompoundDrawablesWithIntrinsicBounds(null, null, dateIcon, null);

            return view;
        }

        private void OnFloatingActionButtonClick(object sender, EventArgs e)
        {
            ViewModel.Navigate<AddTrainingViewModel>();
        }
    }
}