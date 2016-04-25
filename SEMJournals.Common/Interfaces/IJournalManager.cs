using System.Collections.Generic;

namespace SEMJournals.Common.Interfaces
{
    public interface IJournalManager
    {
        void DeleteAllJournalsForUser(int userId);
        void DeleteSpecificJournal(int journalId, int userId);
        void PublishJournal(IJournal journal);

        List<IJournal> GetAllJournals();
        List<IJournal> GetJournalsForUser(int userId);
    }
}