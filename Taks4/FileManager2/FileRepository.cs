using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    internal class FileRepository
    {
        private static Permission[] UserPermissions = new Permission[]
        {
           new Permission()
           {
               Key = "Add new file",
               Method = new Action<File>(AddNewFile)
           },
           new Permission(){ Key="Remove File", Method = new Action<File[]>(RemoveFiles) },
           new Permission() {Key = "Get file by id" , Method = new Func<int,File>(GetFile) },
           new Permission() {Key = "Get file by link", Method = new Func<string,File>(GetFile)},
           new Permission() {Key = "My files", Method = new Func<User,IEnumerable<File>>(GetFiles) },
           new Permission() {Key = "My private files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "My internal files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
        };
        private static Permission[] AdminPermissons = new Permission[]
        {
           new Permission() {Key = "Add new file",Method = new Action<File>(AddNewFile)},
           new Permission() {Key= "Remove File", Method = new Action<File[]>(RemoveFiles) },
           new Permission() {Key = "Get file by id" , Method = new Func<int,File>(GetFile) },
           new Permission() {Key = "Get file by link", Method = new Func<string,File>(GetFile)},
           new Permission() {Key = "My files", Method = new Func<User,IEnumerable<File>>(GetFiles) },
           new Permission() {Key = "My private files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "My internal files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "User's files", Method= new Func<User,IEnumerable<File>>(GetFiles)},
           new Permission() {Key = "All internal files", Method = new Func<IEnumerable<File>>(GetAllPubFiles)},
           new Permission() {Key="All private files", Method = new Func<IEnumerable<File>>(GetAllPrivateFiles)},
        };

        internal Permission[] PermissionList;

        internal FileRepository(string premission)
        {
            if (premission == User.Permissions) { PermissionList = UserPermissions; }
            if (premission == Admin.Permissions) { PermissionList = UserPermissions; }
        }

        internal static IEnumerable<File> GetAllFiles() { return null; }
        internal static IEnumerable<File> GetFiles(User user) { return null; }
        internal static void RemoveFiles(params File[] Files) { }
        internal static void AddNewFile(File file) { }
        internal static File GetFile(int id) { return null; }
        internal static File GetFile(string link) => null;
        internal static IEnumerable<File> GetPubFiles(User user) { return null; }
        internal static IEnumerable<File> GetAllPubFiles() { return null; }
        internal static IEnumerable<File> GetPrivateFiles(User user) { return null; }
        internal static IEnumerable<File> GetAllPrivateFiles() { return null; }
    }
}
