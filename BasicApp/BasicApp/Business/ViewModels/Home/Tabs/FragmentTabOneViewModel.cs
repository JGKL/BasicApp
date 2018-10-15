using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace BasicApp.Business.ViewModels.Home.Tabs
{
    public class FragmentTabOneViewModel : BaseViewModel
    {
        public FragmentTabOneViewModel()
        {
            Items = new List<RecyclerViewItem>
            {
                new RecyclerViewItem { Title = "One" },
                new RecyclerViewItem { Title = "One" },
                new RecyclerViewItem { Title = "Two" },
                new RecyclerViewItem { Title = "Three" },
                new RecyclerViewItem { Title = "Four" },
                new RecyclerViewItem { Title = "Five" },
                new RecyclerViewItem { Title = "Six" },
                new RecyclerViewItem { Title = "Seven" },
                new RecyclerViewItem { Title = "Eight" },
                new RecyclerViewItem { Title = "Nine" },
                new RecyclerViewItem { Title = "Ten" },
                new RecyclerViewItem { Title = "Eleven" },
                new RecyclerViewItem { Title = "Twelve" },
            };
        }

        public List<RecyclerViewItem> Items { get; set; }

        public IMvxCommand Click
        {
            get
            {
                return new MvxCommand(() => { });
            }
        }
    }

    public class RecyclerViewItem : BaseViewModel
    {
        public string SubTitle { get; set; }
        public string Base64Image { get; set; }
    }
}
