using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SEMJournals.Common.Models
{
    public class AuthenticationManager
    {
        // Maps usernames to their passwords for authentication
        private static Dictionary<string, string> _users = new Dictionary<string, string>();
        private static AuthenticationManager _instance;

        private AuthenticationManager()
        {
            string json;

            using (var reader = new StreamReader(@"C:\users.json"))
            {
                json = reader.ReadToEnd();
            }

            _users = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static AuthenticationManager Instance
        {
            get { return _instance ?? (_instance = new AuthenticationManager()); }
        }

        public bool Authenticate(string username, string password)
        {
            // Disregard casing for username
            username = username.ToLower();

            if (_users.ContainsKey(username))
            {
                if (_users[username] == password)
                {
                    return true;
                }
            }

            return false;
        }

        public void Save(string filename = @"C:\users.json")
        {
            var json = JsonConvert.SerializeObject(_users);

            using (var writer = new StreamWriter(filename))
            {
                writer.Write(json);
            }
        }

        public bool AddUser(string username, string password)
        {
            if (username == null || password == null) return false;

            // Disregard casing for the username
            username = username.ToLower();

            if (_users.ContainsKey(username))
            {
                // User already exist
                return false;
            }

            _users.Add(username, password);
            Save();
            return true;
        }

        public bool DeleteUser(string username)
        {
            if (username == null) return false;

            username = username.ToLower();

            if (!_users.ContainsKey(username))
            {
                return false;
            }

            _users.Remove(username);
            Save();
            return true;
        }
    }
}
