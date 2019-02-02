using Android.OS;
using Android.Views;
using BasicApp.Core.Business.ViewModels.Programma;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Training
{
    public class ProgrammaView : BaseFragment<ProgrammaViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.ProgrammaView, null);
            return view;
        }
    }
}