using GalaSoft.MvvmLight;

namespace SEMJournals.Win.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentPage;

        public MainViewModel()
        {
            SelectedPage = new LoginViewModel(this);
        }

        public ViewModelBase SelectedPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
