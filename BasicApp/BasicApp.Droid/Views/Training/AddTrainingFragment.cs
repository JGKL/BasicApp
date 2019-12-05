using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Views.InputMethods;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Enum;
using BasicApp.Core.Business.ViewModels;
using BasicApp.Droid.Utilities.Controls;
using BasicApp.Droid.Utilities.FontAwesome;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using System;
using static Android.Views.View;

namespace BasicApp.Droid.Views.Training
{
    [MvxFragmentPresentation(typeof(MenuViewModel), Resource.Id.contentFrame, AddToBackStack = true)]
    public class AddTrainingFragment : MvxFragment<AddTrainingViewModel>, IOnFocusChangeListener
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.AddTrainingView, null);

            var datumTextInputEditText = view.FindViewById<TextInputEditText>(Resource.Id.datumTextInputEditText);
            datumTextInputEditText.FocusChange += (object sender, View.FocusChangeEventArgs args) =>
            {
                if (args.HasFocus)
                {
                    var fragment = CustomDatePickerDialog.NewInstance(delegate (DateTime time)
                    {
                        ViewModel.Datum = time;
                        datumTextInputEditText.ClearFocus();
                    }, delegate {
                        datumTextInputEditText.ClearFocus();
                    });

                    fragment.Show(ChildFragmentManager, "DatePicker");
                }
            };

            var programmaTextInputEditText = view.FindViewById<TextInputEditText>(Resource.Id.programmaTextInputEditText);
            programmaTextInputEditText.OnFocusChangeListener = this;

            var dateIcon = new IconDrawable(Context, '\uf2b9', FontModule.FontAwesomeRegular);
            dateIcon.SizeDp(24);
            dateIcon.Color(Resource.Color.darkRed);
            datumTextInputEditText.SetCompoundDrawablesWithIntrinsicBounds(null, null, dateIcon, null);

            return view;
        }

        public void OnFocusChange(View view, bool hasFocus)
        {
            if (!hasFocus)
            {
                HideKeyboard(view);
            }
        }

        private void HideKeyboard(View view)
        {
            var imm = Activity.GetSystemService(Context.InputMethodService) as InputMethodManager;
            imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }
    }
}