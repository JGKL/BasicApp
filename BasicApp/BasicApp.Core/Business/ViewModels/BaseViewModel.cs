using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicApp.Business.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public BaseViewModel()
        {
            _navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        public Task<bool> Navigate(IMvxViewModel viewModel)
        {
            return _navigationService.Navigate(viewModel);
        }

        List<ToolbarItemViewModel> _toolbarItems;
        public List<ToolbarItemViewModel> ToolbarItems
        {
            get
            {
                return _toolbarItems;
            }
            set
            {
                _toolbarItems = value;
                RaisePropertyChanged(() => ToolbarItems);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        private bool _showCloseButton;
        public bool ShowCloseButton
        {
            get { return _showCloseButton; }
            set
            {
                _showCloseButton = value;
                RaisePropertyChanged(() => ShowCloseButton);
            }
        }
    }
}
