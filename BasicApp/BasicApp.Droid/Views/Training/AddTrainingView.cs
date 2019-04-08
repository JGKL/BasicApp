using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using BasicApp.Core.Business.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System;

namespace BasicApp.Droid.Views.Training
{
    public class AddTrainingView : BaseFragment<AddTrainingViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.AddTrainingView, null);

            var fontAwesomeTypeFace = Typeface.CreateFromAsset(Application.Context.Assets, "fontawesome-webfont.ttf");

            var datumButton = view.FindViewById<TextView>(Resource.Id.training_datum);
            datumButton.Click += (object sender, EventArgs e) =>
            {
                var fragment = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    ViewModel.Datum = time;
                });
                fragment.Show(ChildFragmentManager, "DatePicker");
            };
            datumButton.SetTypeface(fontAwesomeTypeFace, TypefaceStyle.Normal);

            var beginTitleTextView = view.FindViewById<TextView>(Resource.Id.beginTitle);
            beginTitleTextView.SetTypeface(fontAwesomeTypeFace, TypefaceStyle.Normal);

            return view;
        }
    }

    public class DatePickerFragment : Android.Support.V4.App.DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _dateSelectedHandler(selectedDate);
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month - 1,
                                                           currently.Day);
            return dialog;
        }
    }
}