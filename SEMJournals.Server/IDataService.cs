using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using SEMJournals.Common.Interfaces;
using SEMJournals.Common.Models;

namespace SEMJournals.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataService" in both code and config file together.
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        IJournal GetJournalById(int documentId);

        [OperationContract]
        List<IJournal> GetJournalsByUserId(string username);

        [OperationContract]
        List<IJournal> GetAllJournals();

        [OperationContract]
        void SaveJournal(IJournal journal);

        [OperationContract]
        void DeleteJournal(int journalId, string username);

        [OperationContract]
        void AddUser(string username, UserType type);

        [OperationContract]
        void RemoveUser(string username);

        [OperationContract]
        User GetUserByUsername(string username);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
