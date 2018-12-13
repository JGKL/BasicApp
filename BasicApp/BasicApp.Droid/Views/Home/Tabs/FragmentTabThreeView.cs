using Android.Views;
using Android.OS;
using MvvmCross.Droid.Support.V4;

namespace BasicApp.Droid.Views.Home.Tabs
{
    public class FragmentTabThreeView : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.TabFragmentThree, null);
            return view;
        }
    }
}