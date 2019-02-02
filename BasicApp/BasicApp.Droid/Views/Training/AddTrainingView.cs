using Android.App;
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

            var datumButton = view.FindViewById<Button>(Resource.Id.training_datum);
            datumButton.Click += (object sender, EventArgs e) =>
            {
                var fragment = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    datumButton.Text = time.ToLongDateString();
                });
                fragment.Show(ChildFragmentManager, "DatePicker");
            };

            var toolbar = Activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

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