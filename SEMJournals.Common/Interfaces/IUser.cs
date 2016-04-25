using SEMJournals.Common.Models;

namespace SEMJournals.Common.Interfaces
{
    public interface IUser
    {
        int GetUserId();
        string GetUsername();
        UserType GetUserType();
    }
}