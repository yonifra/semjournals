using System;
using System.ComponentModel.DataAnnotations;
using SEMJournals.Common.Interfaces;

namespace SEMJournals.Common.Models
{
    public class Journal : IJournal
    {
        public Journal()
        {
            PublishTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string Author { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime PublishTime { get; private set; }
    }
}
