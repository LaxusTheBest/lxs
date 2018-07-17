namespace FileManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents User with an exctra permissions
    /// </summary>
    internal class Admin : User
    {
        /// <summary>
        /// A string describing the permissions
        /// </summary>
        internal new const string Permissions = "Admin";

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
        internal Admin()
        {
            this.FileRepository = new FileRepository(Permissions);
            this.UserRepository = new UserRepository();
        }
    }
}
