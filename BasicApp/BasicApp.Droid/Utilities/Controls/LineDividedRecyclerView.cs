using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using BasicApp.Droid.Utilities.Extensions;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace BasicApp.Droid.Utilities.Controls
{
    [Register("mvvmcross.droid.support.v7.recyclerview.LineDividedRecyclerView")]
    public sealed class LineDividedRecyclerView : MvxRecyclerView
    {
        public LineDividedRecyclerView(Context context, IAttributeSet attrs) : this(context, attrs, 0, new MvxRecyclerAdapter()) { }

        public LineDividedRecyclerView(Context context, IAttributeSet attrs, int defStyle) : this(context, attrs, defStyle, new MvxRecyclerAdapter()) { }

        public LineDividedRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(context, attrs, defStyle, adapter)
        {
            Setup(context);
        }

        private void SetDivider(Context context, Drawable drawable)
        {
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(context);
            SetLayoutManager(linearLayoutManager);

            var dividerItemDecoration = new DividerItemDecoration(context, 1);
            dividerItemDecoration.SetDrawable(drawable);
            AddItemDecoration(dividerItemDecoration);
        }

        private void Setup(Context context)
        {
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(context);
            SetLayoutManager(linearLayoutManager);

            SetDivider(context, AppCompatExtensions.GetDrawable(Resource.Drawable.transparant_divider_shape).Mutate());
        }
    }
}