using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class User
    {
        public const string Permissions = "User";
        public enum Genders
        {
            Male = 1,
            Female
        }

        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Genders Gender { get; set; }

        public FileRepository FileRepository;

        public User()
        {
            FileRepository = new FileRepository(Permissions);
        }
    }
}
