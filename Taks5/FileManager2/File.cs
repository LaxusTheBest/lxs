namespace FileManager
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the data of the file 
    /// </summary>
    public class File
    {
        /// <summary>
        /// Types of files
        /// </summary>
        public enum FileTypes
        {
            /// <summary>
            /// Image file including any image format
            /// </summary>
            Image = 0,

            /// <summary>
            /// Text file including Word and etc.
            /// </summary>
            TextDocument,

            /// <summary>
            /// Video file including any video file format
            /// </summary>
            Video,

            /// <summary>
            /// Audio file including any audio file format
            /// </summary>
            Audio,

            /// <summary>
            /// Binary file
            /// </summary>
            Binary,

            /// <summary>
            /// Database file including any database format
            /// </summary>
            DataBase
        }

        /// <summary>
        /// Gets/Sets file name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/Sets link to the file
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets/Sets publisher of the file
        /// </summary>
        public User Publisher { get; set; }

        /// <summary>
        /// Gets/Sets data of the file publication 
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Gets/Sets type of the file
        /// </summary>
        public FileTypes FileType { get; set; }

        /// <summary>
        /// Gets/Sets contains meta information about the file
        /// </summary>
        public FileMetaInformation MetaData { get; set; }

        /// <summary>
        /// Gets/Sets contain tags of the file
        /// </summary>
        public IEnumerable<Tag> Tags { get; set; }

        /// <summary>
        /// Gets/Sets identifier of the file
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets/Sets contains info if the file has public or private access
        /// </summary>
        private bool IsPublic { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the File class
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <param name="publisher">User object as the publisher</param>
        public File()
        {
        }
    }
}
