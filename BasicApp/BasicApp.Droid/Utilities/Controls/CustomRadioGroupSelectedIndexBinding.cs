using System;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid.Target;

namespace BasicApp.Droid.Utilities.Controls
{
    public class CustomRadioGroupSelectedIndexBinding : MvxAndroidTargetBinding
    {
        private bool _stopListeningCheckChanged = false;

        private int _selectedIndex = -2;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value != _selectedIndex)
                {
                    _selectedIndex = value;
                    FireValueChanged(SelectedIndex);
                }
            }
        }

        public static void Register(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<RadioGroup>("SelectedIndex", radioGroup => new CustomRadioGroupSelectedIndexBinding(radioGroup));
        }

        public CustomRadioGroupSelectedIndexBinding(RadioGroup radioGroup) : base(radioGroup)
        {
            if (radioGroup == null)
                return;

            radioGroup.CheckedChange += CheckedChange;
            radioGroup.ChildViewAdded += RadioGroupOnChildViewAdded;
        }

        private void RadioGroupOnChildViewAdded(object sender, ViewGroup.ChildViewAddedEventArgs childViewAddedEventArgs)
        {
            var radioGroup = Target as RadioGroup;
            if (_selectedIndex == radioGroup.ChildCount - 1)
            {
                _stopListeningCheckChanged = true;
                radioGroup.Check(radioGroup.GetChildAt(_selectedIndex).Id);
                _stopListeningCheckChanged = false;
            }
        }

        private void CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            if (_stopListeningCheckChanged)
                return;

            var radioGroup = Target as RadioGroup;
            var checkedId = e.CheckedId;

            if (checkedId == View.NoId)
            {
                SelectedIndex = -1;
                return;
            }

            for (var i = radioGroup.ChildCount - 1; i >= 0; i--)
            {
                if (checkedId == radioGroup.GetChildAt(i).Id)
                {
                    SelectedIndex = i;
                    return;
                }
            }
            SelectedIndex = -1;
        }

        public override void SetValue(object value)
        {
            var radioGroup = Target as RadioGroup;
            if (radioGroup == null)
                return;

            _stopListeningCheckChanged = true;

            if (value == null)
                return;

            _selectedIndex = (int) value;
            if (_selectedIndex < 0 || _selectedIndex >= radioGroup.ChildCount)
            {
                radioGroup.ClearCheck();
            }
            else
            {
                radioGroup.Check(radioGroup.GetChildAt(_selectedIndex).Id);
            }
            _stopListeningCheckChanged = false;
        }

        public override Type TargetType
        {
            get { return typeof(object); }
        }

        protected override void SetValueImpl(object target, object value)
        {
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var radioGroup = Target as RadioGroup;
                if (radioGroup != null)
                {
                    radioGroup.CheckedChange -= CheckedChange;
                    radioGroup.ChildViewAdded -= RadioGroupOnChildViewAdded;
                }
            }
            base.Dispose(isDisposing);
        }
    }
}