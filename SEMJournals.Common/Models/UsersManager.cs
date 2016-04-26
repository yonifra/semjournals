using System.Collections.Generic;
using System.Linq;

namespace SEMJournals.Common.Models
{
    public static class UsersManager
    {
        public static void AddUser(string username, UserType type)
        {
            using (var db = new JournalsContext())
            {
                db.Users.Add(new User(username) { Journals = new List<Journal>(), Type = type });
                db.SaveChanges();
            }
        }

        public static void RemoveUser(string username)
        {
            using (var db = new JournalsContext())
            {
                var userToDelete = db.Users.FirstOrDefault(u => u.Username == username);

                if (userToDelete != null)
                {
                    db.Users.Remove(userToDelete);
                    db.SaveChanges();
                }
            }
        }

        public static User GetUserByUsername(string username)
        {
            User foundUser;

            using (var db = new JournalsContext())
            {
                foundUser = db.Users.FirstOrDefault(u => u.Username == username);  
            }

            return foundUser;
        }
    }
}
