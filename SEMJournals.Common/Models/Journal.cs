using System;
using SEMJournals.Common.Interfaces;

namespace SEMJournals.Common.Models
{
    public class Journal : IJournal
    {
        private string _journalPath;
        private int _id;
        private int _authorId;
        private string _journalName;
        private DateTime _publishTime;

        public string GetJournalPath()
        {
            return _journalPath;
        }

        public int GetJournalId()
        {
            return _id;
        }

        public int GetAuthorId()
        {
            return _authorId;
        }

        public string GetJournalName()
        {
            return _journalName;
        }
    }
}
