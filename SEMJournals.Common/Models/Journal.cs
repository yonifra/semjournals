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

        public Journal()
        {
            PublishTime = DateTime.Now;
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime PublishTime { get; private set; }
    }
}
