using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManager
{
    public class Tag
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public static IEnumerable<Tag> GetAllTags() { return null; }
    }
}