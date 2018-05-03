using MvvmCross.Core.ViewModels;

namespace BasicApp.Business.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Login view model";
        }

        string _server;
        public string Server
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
                RaisePropertyChanged(() => Server);
            }
        }

        string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public IMvxCommand LoginCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<MenuViewModel>();
                });
            }
        }
    }
}
