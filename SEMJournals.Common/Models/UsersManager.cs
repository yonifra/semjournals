using System.Collections.Generic;
using System.Linq;

namespace SEMJournals.Common.Models
{
    public static class UsersManager
    {
        public static void AddUser(string username, UserType type)
        {
            AddUser(new User(username) { Journals = new List<Journal>(), Type = type });
        }


        public static void AddUser(User user)
        {
            if (user == null) return;

            using (var db = new JournalsContext())
            {
                db.Users.Add(user);
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
                    RemoveUser(userToDelete);
                }
            }
        }

        public static void RemoveUser(User user)
        {
            if (user == null) return;

            using (var db = new JournalsContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public static User GetUserByUsername(string username)
        {
            User foundUser = null;

            using (var db = new JournalsContext())
            {
                if (db.Users.Any())
                {
                    foundUser = db.Users.FirstOrDefault(u => u.Username == username);
                }
            }

            return foundUser;
        }
    }
}
