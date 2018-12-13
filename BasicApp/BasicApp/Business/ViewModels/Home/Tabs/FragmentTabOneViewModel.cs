using System.Collections.ObjectModel;

namespace BasicApp.Business.ViewModels.Home.Tabs
{
    public class FragmentTabOneViewModel : BaseViewModel
    {
        public FragmentTabOneViewModel()
        {
            Items = new ObservableCollection<TabViewItem>
            {
                new TabViewItem { Text = "Text 1" },
                new TabViewItem { Text = "Text 2" },
                new TabViewItem { Text = "Text 3" },
                new TabViewItem { Text = "Text 4" },
                new TabViewItem { Text = "Text 5" },
                new TabViewItem { Text = "Text 6" },
                new TabViewItem { Text = "Text 7" },
                new TabViewItem { Text = "Text 8" },
                new TabViewItem { Text = "Text 9" },
                new TabViewItem { Text = "Text 10" },
            };
        }

        public ObservableCollection<TabViewItem> Items { get; set; }
    }

    public class TabViewItem
    {
        public string Text { get; set; }
    }
}
