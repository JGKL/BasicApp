using System.Collections.Generic;
using Android.Support.V4.App;

namespace BasicApp.Droid.Utilities.Adapters
{
    public class HomeFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly List<Fragment> _fragments;

        public HomeFragmentPagerAdapter(FragmentManager fm, List<Fragment> fragments) : base(fm)
        {
            _fragments = fragments;
        }

        public override int Count => _fragments.Count;

        public override Fragment GetItem(int position)
        {
            return _fragments[position];
        }
    }
}