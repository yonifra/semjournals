using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SEMJournals.Common.Models;
using SEMJournals.Server;

namespace SEMJournals.Win.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private RelayCommand _loginCommand;
        private readonly MainViewModel _mainVm;
        private RelayCommand _signUpCommand;
        private bool _isPublisher;

        public LoginViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
        }

        private void Login()
        {
            if (Authenticate())
            {
                _mainVm.SelectedPage = new SemViewerViewModel();
            }
            else
            {
                // Login unsuccessful, display a message
                MessageBox.Show("Login failed, please check your credentials", "Login failed", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Password = "";
            }
        }

        public RelayCommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(Login)); }
        }

        public RelayCommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand(SignUp)); }
        }

        private void SignUp()
        {
            var userType = IsPublisher ? UserType.Publisher : UserType.User;

            var result = AuthenticationManager.Instance.AddUser(Username, Password);

            if (result)
            {
                UsersManager.AddUser(Username, userType);
            }

            MessageBox.Show(result ? "Signed up!" : "Error signing up");
        }

        public bool IsPublisher
        {
            get { return _isPublisher; }
            set
            {
                _isPublisher = value;
                RaisePropertyChanged();
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        private bool Authenticate()
        {
            return AuthenticationManager.Instance.Authenticate(Username, Password);
        }
    }
}
