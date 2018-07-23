namespace FileManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents User with an exctra permissions
    /// </summary>
    public class Admin : User
    {
        /// <summary>
        /// A string describing the permissions
        /// </summary>
        public new const string Permissions = "Admin";

        /// <summary>
        /// Sets File Repository object
        /// </summary>
        private new FileRepository FileRepository { get; set; }

        /// <summary>
        /// Sets User Repository object
        /// </summary>
        private UserRepository UserRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the Admin class 
        /// </summary>
        public Admin()
        {
            this.FileRepository = new FileRepository(Permissions);
            this.UserRepository = new UserRepository();
        }
    }
}
