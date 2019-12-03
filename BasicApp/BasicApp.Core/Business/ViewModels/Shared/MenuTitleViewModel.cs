namespace BasicApp.Business.ViewModels.Shared
{
    public class MenuTitleViewModel
    {
        public MenuTitleViewModel(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
    }
}
