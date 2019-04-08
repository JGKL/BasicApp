using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using BasicApp.Core.Business.ViewModels.Historie;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Historie
{
    public class HistorieView : MvxFragment<HistorieViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HistorieView, null);

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.trainingen);
            recyclerView.Adapter = new TrainingenRecyclerViewAdapter((IMvxAndroidBindingContext) BindingContext);

            return view;
        }
    }

    public class TrainingenRecyclerViewAdapter : MvxRecyclerAdapter
    {
        public TrainingenRecyclerViewAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext) { }

        public int ItemNumber = 0;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            ItemNumber++;

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = this.InflateViewForHolder(parent, viewType, itemBindingContext);

            var myViewHolder = new MyViewHolder(view, itemBindingContext, ItemNumber)
            {
                Click = ItemClick
            };

            return myViewHolder;
        }
    }

    public class MyViewHolder : MvxRecyclerViewHolder
    {
        public MyViewHolder(View itemView, IMvxAndroidBindingContext context, int itemNumber) : base(itemView, context)
        {
            itemView.TransitionName = $"training_{itemNumber}";
        }
    }
}