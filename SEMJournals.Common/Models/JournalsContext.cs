using System.Data.Entity;

namespace SEMJournals.Common.Models
{
    public class JournalsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Journal> Journals { get; set; }
    }
}
