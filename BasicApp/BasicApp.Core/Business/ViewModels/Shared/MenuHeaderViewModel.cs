namespace BasicApp.Business.ViewModels.Shared
{
    public class MenuHeaderViewModel
    {
        public MenuHeaderViewModel(string title, string subtitle)
        {
            Title = title;
            Subtitle = subtitle;
        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
