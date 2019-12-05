using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace BasicApp.Droid.Utilities.Controls
{
    public class CustomDatePickerDialog : Android.Support.V4.App.DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        Action<DateTime> _dateSelectedHandler = delegate { };
        Action _cancelHandler = delegate { };

        public static CustomDatePickerDialog NewInstance(Action<DateTime> onDateSelected, Action onCancel)
        {
            CustomDatePickerDialog frag = new CustomDatePickerDialog
            {
                _dateSelectedHandler = onDateSelected,
                _cancelHandler = onCancel
            };
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

        public override void OnCancel(IDialogInterface dialog)
        {
            _cancelHandler();
        }
    }
}