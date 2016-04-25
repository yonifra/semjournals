using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SEMJournals.Win.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private RelayCommand _loginCommand;
        private readonly MainViewModel _mainVm;

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
            return true;
            //TODO: Authenticate the user, return true if authenticated or false otherwise
        }
    }
}
