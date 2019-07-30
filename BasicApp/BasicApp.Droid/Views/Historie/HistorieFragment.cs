using System;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BasicApp.Core.Business.ViewModels.Historie;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace BasicApp.Droid.Views.Historie
{
    public class HistorieFragment : MvxFragment<HistorieViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HistorieView, null);

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.trainingen);
            if (recyclerView != null)
            {
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);
                var adapter = new SelectedItemRecyclerAdapter(BindingContext as IMvxAndroidBindingContext);
                adapter.OnItemClick += AdapterOnItemClick;
                recyclerView.Adapter = adapter;
            }

            return view;
        }

        private void AdapterOnItemClick(object sender, SelectedItemRecyclerAdapter.SelectedItemEventArgs e)
        {
            RelativeLayout itemLogo = e.View.FindViewById<RelativeLayout>(Resource.Id.img_date);
            itemLogo.Tag = Activity.Resources.GetString(Resource.String.transition_list_item_icon);
            ViewModel.SelectItemExecution(e.DataContext as Core.Business.Models.Training);
        }
    }

    public partial class SelectedItemRecyclerAdapter : MvxRecyclerAdapter
    {
        public event EventHandler<SelectedItemEventArgs> OnItemClick;

        public SelectedItemRecyclerAdapter(IMvxAndroidBindingContext bindingContext)
              : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            View view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new SelectedItemViewHolder(view, itemBindingContext, OnClick)
            {
                Click = ItemClick,
                LongClick = ItemLongClick
            };
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RelativeLayout itemLogo = holder.ItemView.FindViewById<RelativeLayout>(Resource.Id.img_date);
            ViewCompat.SetTransitionName(itemLogo, "img_date" + position);

            base.OnBindViewHolder(holder, position);
        }

        private void OnClick(int position, View view, object dataContext)
            => OnItemClick?.Invoke(this, new SelectedItemEventArgs(position, view, dataContext));
    }

    public partial class SelectedItemRecyclerAdapter
    {
        public class SelectedItemViewHolder : MvxRecyclerViewHolder
        {
            private readonly Action<int, View, object> _listener;

            public SelectedItemViewHolder(View itemView, IMvxAndroidBindingContext context, Action<int, View, object> listener)
                : base(itemView, context)
            {
                _listener = listener;
                ItemView.Click += ItemView_Click;
            }

            private void ItemView_Click(object sender, EventArgs e)
                => _listener(AdapterPosition, ItemView, DataContext);

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    ItemView.Click -= ItemView_Click;

                base.Dispose(disposing);
            }
        }
    }

    public partial class SelectedItemRecyclerAdapter
    {
        public class SelectedItemEventArgs : EventArgs
        {
            public SelectedItemEventArgs(int position, View view, object dataContext)
            {
                Position = position;
                View = view;
                DataContext = dataContext;
            }

            public int Position { get; }
            public View View { get; }
            public object DataContext { get; }
        }
    }
}