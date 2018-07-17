    using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class UserRepository
    {

        internal IEnumerable<User> GetAllUsers() { return null; }
        internal User GetUser(int id) { return null; }
        internal User GetUser(string login) { return null; }
        internal void RemoveUser(User user) { }
        internal void CreateUser() { }
        internal void SaveChanges(int id) { }
    }
}
