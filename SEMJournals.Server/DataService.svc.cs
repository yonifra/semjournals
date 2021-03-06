﻿using System;
using System.Collections.Generic;
using SEMJournals.Common.Interfaces;
using SEMJournals.Common.Models;

namespace SEMJournals.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IJournal GetJournalById(int documentId)
        {
            return JournalManager.GetJournal(documentId);
        }

        public List<IJournal> GetJournalsByUserId(string username)
        {
            return JournalManager.GetJournalsForUser(username);
        }

        public List<IJournal> GetAllJournals()
        {
            return JournalManager.GetAllJournals();
        }

        public void SaveJournal(IJournal journal)
        {
            JournalManager.PublishJournal(journal);
        }

        public void DeleteJournal(int journalId, string username)
        {
            JournalManager.DeleteSpecificJournal(journalId, username);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void AddUser(string username, UserType type)
        {
            UsersManager.AddUser(username, type);
        }

        public void RemoveUser(string username)
        {
            UsersManager.RemoveUser(username);
        }

        public User GetUserByUsername(string username)
        {
            return UsersManager.GetUserByUsername(username);
        }
    }
}
