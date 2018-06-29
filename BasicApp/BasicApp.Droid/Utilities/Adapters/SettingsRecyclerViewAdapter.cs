using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace BasicApp.Droid.Utilities.Adapters
{
    public class ViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; }

        public ViewHolder(TextView itemView) : base(itemView)
        {
            TextView = itemView;
        }
    }

    public class SettingsRecyclerViewAdapter : RecyclerView.Adapter
    {
        private readonly string[] _dataSet;

        public SettingsRecyclerViewAdapter(string[] dataSet)
        {
            _dataSet = dataSet;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = holder as ViewHolder;
            if (item == null)
                throw new ArgumentException();

            var displayTextCharArray = _dataSet[position].ToCharArray();
            item.TextView.SetText(displayTextCharArray, 0, displayTextCharArray.Length);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var textView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.SettingsRecyclerViewItem, parent, false) as TextView;
            if (textView == null)
                throw new ArgumentNullException();

            var viewHolder = new ViewHolder(textView);
            return viewHolder;
        }

        public override int ItemCount => _dataSet.Length;
    }
}