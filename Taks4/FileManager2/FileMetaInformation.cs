using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManager
{
    internal class FileMetaInformation
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Encoding { get; set; }
        public DateTime ContentCreated { get; set; }
        public DateTime LastTimeSaved { get; set; }
    }
}