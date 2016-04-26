using System;
using GalaSoft.MvvmLight;
using SEMJournals.Common.Models;

namespace SEMJournals.Win.ViewModels
{
    public class JournalViewModel : ViewModelBase
    {
        private int _journalId;
        private string _documentPath;
        private string _journalName;
        private string _authorName;
        private DateTime _creationTime;

        public JournalViewModel(int journalId)
        {
            _journalId = journalId;
        }

        public JournalViewModel(Journal journal)
        {
            Id = journal.Id;
            DocumentPath = journal.Path;
            JournalName = journal.Name;
            Author = journal.Author;
            CreationTime = journal.PublishTime;
        }

        public string DocumentPath
        {
            get { return _documentPath; }
            set
            {
                _documentPath = value;
                RaisePropertyChanged();
            }
        }

        public string JournalName
        {
            get { return _journalName; }
            set
            {
                _journalName = value;
                RaisePropertyChanged();
            }
        }

        public string Author
        {
            get { return _authorName; }
            set
            {
                _authorName = value;
                RaisePropertyChanged();
            }
        }

        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
                RaisePropertyChanged();
            }
        }

        public int Id
        {
            get { return _journalId; }
            private set
            {
                _journalId = value;
                RaisePropertyChanged();
            }
        }
    }
}
