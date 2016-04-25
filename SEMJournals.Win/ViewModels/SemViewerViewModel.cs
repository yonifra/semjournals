using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace SEMJournals.Win.ViewModels
{
    public class SemViewerViewModel : ViewModelBase
    {
        private ObservableCollection<JournalViewModel> _journals;
        private JournalViewModel _selectedJournal;

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
                    Journals.Add(new JournalViewModel(1) { AuthorName = "Yoni Fraimorice", CreationTime = DateTime.Now, DocumentPath = @"C:\sample.pdf", JournalName = "Journal #" + i });
                }
            }
        }

        public SemViewerViewModel(ObservableCollection<JournalViewModel> journals)
        {
            Journals = journals;
        }
    }
}
