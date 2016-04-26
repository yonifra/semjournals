using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SEMJournals.Common.Models;
using SEMJournals.Server;

namespace SEMJournals.Win.ViewModels
{
    public class SemViewerViewModel : ViewModelBase
    {
        private ObservableCollection<JournalViewModel> _journals;
        private JournalViewModel _selectedJournal;
        private RelayCommand _uploadCommand;
        private RelayCommand _showAllCommand;
        private RelayCommand _showMyJournalsCommand;

        public ObservableCollection<JournalViewModel> Journals
        {
            get { return _journals; }
            set
            {
                _journals = value;
                RaisePropertyChanged();
            }
        }

        public JournalViewModel SelectedJournal
        {
            get { return _selectedJournal; }
            set
            {
                if (_selectedJournal != value)
                {
                    _selectedJournal = value;
                    RaisePropertyChanged();
                }
            }
        }

        public SemViewerViewModel()
        {
            if (Journals == null)
            {
                // If we had a null list, this means we want to populate the list with dummy data
                Journals = new ObservableCollection<JournalViewModel>();

                for (var i = 1; i <= 20; i++)
                {
                    Journals.Add(new JournalViewModel(i) { Author = "yoni", CreationTime = DateTime.Now, DocumentPath = @"C:\sample.pdf", JournalName = "Journal #" + i });
                }
            }
        }

        public SemViewerViewModel(ObservableCollection<JournalViewModel> journals)
        {
            Journals = journals;
        }

        public RelayCommand UploadCommand
        {
            get { return _uploadCommand ?? (_uploadCommand = new RelayCommand(Upload)); }
        }

        public RelayCommand ShowAllCommand
        {
            get { return _showAllCommand ?? (_showAllCommand = new RelayCommand(ShowAll)); }
        }

        public RelayCommand ShowMyJournalsCommand
        {
            get { return _showMyJournalsCommand ?? (_showMyJournalsCommand = new RelayCommand(ShowMyJournals)); }
        }

        private static void Upload()
        {
            var openFileDialog = new OpenFileDialog { Filter = "PDF Files|*.pdf" };

            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;

                if (path != null)
                {
                    var journal = new Journal
                    {
                        Author = AuthenticationManager.Instance.CurrentUser,
                        Path = path,
                        Name = new Guid().ToString()
                    };

                    JournalManager.PublishJournal(journal);
                }
            }
        }

        private void ShowAll()
        {
            var service = new DataService();
            Journals.Clear();

            foreach (var item in service.GetAllJournals().Cast<Journal>())
            {
                Journals.Add(new JournalViewModel(item));
            }
        }

        private void ShowMyJournals()
        {
            var service = new DataService();
            Journals.Clear();

            var user = UsersManager.GetUserByUsername(AuthenticationManager.Instance.CurrentUser);

            if (user != null)
            {
                foreach (var item in service.GetJournalsByUserId(user.Username).Cast<Journal>())
                {
                    Journals.Add(new JournalViewModel(item));
                }
            }
        }
    }
}
