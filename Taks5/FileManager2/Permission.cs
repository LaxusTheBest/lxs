using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class Permission
    {
        public string Key { get; set; }
        public Delegate Method { get; set; }
    }
}
