using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class User
    {
        internal const string Permissions = "User";
        internal enum Genders
        {
            Male = 1,
            Female
        }

        internal int ID { get; set; }
        internal string Login { get; set; }
        internal string Password { get; set; }
        internal string Email { get; set; }
        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal Genders Gender { get; set; }

        internal FileRepository FileRepository;

        internal User()
        {
            FileRepository = new FileRepository(Permissions);
        }
    }
}
