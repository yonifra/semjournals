using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMJournals.Common.Interfaces
{
    public interface IJournal
    {
        string GetJournalPath();
        int GetJournalId();
        int GetAuthorId();
        string GetJournalName();
    }
}
